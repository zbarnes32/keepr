<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { Keep } from '@/models/Keep.js';
import { vaultsService } from '@/services/VaultsService.js';
import VaultCard from '@/components/globals/VaultCard.vue';
import { Vault } from '@/models/Vault.js';

const account = computed(() => AppState.account)

// FIXME update this to use mykeeps
const myKeeps = computed(() => AppState.myKeeps)

const myVaults = computed(() => AppState.myVaults)

const props = defineProps({
  keepProp: { type: Keep },
  vaultProp: { type: Vault }
})

// onMounted(getKeeps)
// onMounted(getMyVaults)

// REVIEW a better approach is use the authservice
// async function getKeeps(){
//   try {
//     await keepsService.getKeeps()
//   }
//   catch (error){
//     Pop.error(error);
//   }
// }

// async function getMyVaults(){
//   try {
//     await vaultsService.getMyVaults()
//   }
//   catch (error){
//     Pop.error(error);
//   }
// }

</script>

<template>
  <div class="about container">
    <div v-if="account">
      <section class="row text-center">
        <div class="col-12">
          <div>
            <img :src="account.coverImg" alt="Cover Image">
            <span>
              <i class="mdi mdi-dots-horizontal fs-4"></i>
              <!-- TODO keep it simple just add the form account edit form  -->
            </span>
          </div>
          <img :src="account.picture" :alt="account.name" class="profile-picture">
          <p class="fs-2">{{ account.name }}</p>
          <p>{{ myVaults.length }} Vaults | {{ myKeeps.length }} Keeps</p>
        </div>
      </section>

      <section class="row">
        <p class="fs-3 fw-bold">Vaults</p>
        <!-- FIXME: Currently showing all vaults -->
        <div v-for="vault in myVaults" :key="vault.id" class="col-md-3">
          <VaultCard :vaultProp="vault" />
        </div>
      </section>

      <section class="row">
        <p class="fs-3 fw-bold">Keeps</p>
        <div v-for="keep in myKeeps" :key="keep.id" class="col-md-3">
          <!-- FIXME: Only show the cards that you are the creator of. -->
          <!-- <div v-if="account?.id == keepProp.creatorId"> -->
          <KeepCard :keepProp="keep" />
          <!-- </div> -->
        </div>

      </section>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
img {
  max-width: 100px;
}
</style>
