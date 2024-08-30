<script setup>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { Keep } from '@/models/Keep.js';
import { vaultsService } from '@/services/VaultsService.js';
import VaultCard from '@/components/globals/VaultCard.vue';
import { Vault } from '@/models/Vault.js';
import { RouterLink } from 'vue-router';
import { accountService } from '@/services/AccountService.js';

const account = computed(() => AppState.account)

const myKeeps = computed(() => AppState.myKeeps)

const myVaults = computed(() => AppState.myVaults)

const props = defineProps({
  keepProp: { type: Keep },
  vaultProp: { type: Vault }
})

const editableAccountData =  ref({
    name: '',
    picture:'',
    coverImg: ''
})

async function editAccount(){
  try {
    await accountService.editAccount(editableAccountData.value)
  }
  catch (error){
    Pop.error(error);
  }
}

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
            </span>
          </div>
          <div>

            <form @submit.prevent="editAccount()" class="p-2">
              <div class="mt-2 mb-4">
                <label for="name" class="mb-1">Name</label>
              <input v-model="editableAccountData.name" class="form-control" type="text" id="name" maxlength="255"
                required>
              </div>
              <div class="mb-4">
                <label for="description" class="mb-1">Picture</label>
                <input v-model="editableAccountData.picture" class="form-control" type="text" id="description"
                maxlength="1000" required>
            </div>
            <div class="mb-4">
              <label for="img" class="mb-1">Cover Image URL</label>
              <input v-model="editableAccountData.coverImg" class="form-control" type="text" id="img" maxlength="1000"
                required>
            </div>
            <div class="text-end p-2">
              <button type="submit" class="btn btn-info rounded-pill">Edit Account</button>
            </div>
          </form>
        </div>
          
          <img :src="account.picture" :alt="account.name" class="profile-picture">
          <p class="fs-2">{{ account.name }}</p>
          <p>{{ myVaults.length }} Vaults | {{ myKeeps.length }} Keeps</p>
        </div>
      </section>

      <section class="row">
        <p class="fs-3 fw-bold">Vaults</p>
        <div v-for="vault in myVaults" :key="vault.id" class="col-md-3">
          <RouterLink :to="{ name: 'Vault', params: { vaultId: vault.id } }">
            <VaultCard :vaultProp="vault" />
          </RouterLink>
        </div>
      </section>

      <section class="row">
        <p class="fs-3 fw-bold">Keeps</p>
        <div v-for="keep in myKeeps" :key="keep.id" class="col-md-3">
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
