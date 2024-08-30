<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import KeepDetailsCard from '@/components/globals/KeepDetailsCard.vue';
import MainModal from '@/components/globals/MainModal.vue';
import VaultKeepDetails from '@/components/globals/VaultKeepDetails.vue';
import { VaultKeep } from '@/models/VaultKeep.js';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';


const vault = computed(() => AppState.activeVault)
// const vaultKeeps = computed(() => AppState.vaultKeeps)
const vaultKeepKeeps = computed(() => AppState.vaultKeepKeeps)

const route = useRoute()

const router = useRouter()

watch(() => route.params.vaultId, () => {
  getVaultById(route.params.vaultId)
  getKeepsInVault(route.params.vaultId)
}, { immediate: true })

defineProps({ vaultKeep: { type: VaultKeep, required: true } })

async function getVaultById(vaultId) {
  try {
    await vaultsService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.toast(error.response.data, 'error');
    router.push({ name: 'Home' })
  }
}

async function getKeepsInVault(vaultId) {
  try {
    await vaultsService.getKeepsInVault(vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>

  <section class="container">
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <div class="text-center">
          <img :src="vault?.img" alt="Vault cover image">
          <p class="fs-2">{{ vault?.name }}</p>
          <p>by {{ vault?.creator.name }}</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12 text-center fs-4 fw-bold">
        <p>{{ vaultKeepKeeps?.length }} Keeps</p>
      </div>
    </div>
    <div class="row">
      <div v-for="keep in vaultKeepKeeps" :key="keep.id" class="col-md-3">
        <!-- <pre><code>{{ JSON.stringify(keep, null, 2) }}</code></pre> -->
        <KeepCard :keepProp="keep" />
      </div>
    </div>
  </section>

  <MainModal modalId="keepModal" class="modal-xl">
    <template #modalBody>
      <VaultKeepDetails />
    </template>
  </MainModal>

</template>


<style lang="scss" scoped></style>