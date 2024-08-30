<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted, ref, watch } from 'vue';
import { RouterLink, useRoute } from 'vue-router';

const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)

const vaults = computed(() => AppState.myVaults)

const editableVaultData = ref({
  vaultId: 0,
  keepId: 0
})


async function createVaultKeep() {
  try {
    editableVaultData.value.keepId = keep.value.id
    await vaultKeepsService.createVaultKeep(editableVaultData.value)
    Pop.toast("Saved to vault")
  }
  catch (error) {
    Pop.error(error);
  }
}
// const props = defineProps({
//     keepProp: { type: Keep, required: true }
// })


// WE FIX THIS IN THE SERVICE
// async function getKeepById(keepId) {
//     try {
//       await keepsService.getKeepById(keepId)
//     }
//     catch (error){
//       Pop.error(error);
//     }
// }

</script>


<template>
  <div v-if="keep" class="container">
    <div class="row">
      <div class="col-md-6 p-0">
        <img :src="keep.img" class="img-fluid rounded-start keep-img" :alt="keep.name">
      </div>
      <div class="col-md-6">
        <div class="keep-body d-flex flex-column justify-content-between">
          <div class="d-flex justify-content-center gap-3 pt-4 gray-text">
            <p class="fs-5"><i class="mdi mdi-eye"></i> {{ keep.views }}</p>
            <p class="fs-5"><i class="mdi mdi-alpha-k-box-outline"></i> {{ keep.kept }}</p>
          </div>
          <div>
            <p class="keep-name text-center fs-1">{{ keep.name }}</p>
            <p class="keep-description gray-text">{{ keep.description }}</p>
          </div>
          <div class="d-flex justify-content-between">
            <div v-if="account">
              <div class="d-flex">
                <form @submit.prevent="createVaultKeep()" class="d-flex">
                  <select id="vaultId" v-model="editableVaultData.vaultId" class="form-select"
                    aria-label="Choose a Vault">
                    <option selected value="0" disabled>Choose a Vault</option>
                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">
                      {{ vault.name }}
                    </option>
                  </select>
                  <button type="submit" class="btn btn-info">Save</button>
                </form>

              </div>
            </div>

            <div class="d-flex align-items-center">
              <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creatorId }}" 
                    :title="`Click here to go to ${keep.creator.name}'s profile.'`">
                <img class="creator-img" :src="keep.creator.picture" :alt="keep.creator.name">
              </RouterLink>
              <p class="my-0 px-2">{{ keep.creator.name }}</p>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.keep-img {
  width: 100%;
  object-fit: cover;
}

.keep-body {
  height: 100%;
}

.gray-text {
  color: rgb(108, 108, 108);
}

.creator-img {
  height: 5vh;
  border-radius: 50%;
}
</style>