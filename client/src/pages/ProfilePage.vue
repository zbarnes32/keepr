<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import VaultCard from '@/components/globals/VaultCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { profileService } from '@/services/ProfileService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';

const profile = computed(() => AppState.profile)

const profileKeeps = computed(() => AppState.profileKeeps)

const profileVaults = computed(() => AppState.profileVaults)

const route = useRoute()

watch(() => route.params.profileId, () => {
    logger.log("working??")
    getProfileById(route.params.profileId)
    getProfileKeeps(route.params.profileId)
    getProfileVaults(route.params.profileId)
}, {immediate: true})

// onMounted(getProfileKeeps)
// onMounted(getProfileVaults)

// REFERENCE https://github.com/CodeWorks-FullStack/summer24_art_terminal/blob/main/src/pages/ProfilePage.vue

async function getProfileById(profileId) {
    try {
      await profileService.getProfileById(profileId)
    }
    catch (error){
      Pop.error(error);
    }
}

async function getProfileKeeps(profileId) {
    try {
      await keepsService.getProfileKeeps(profileId)
    }
    catch (error){
      Pop.error(error);
    }
}

async function getProfileVaults(profileId) {
    try {
      await vaultsService.getProfileVaults(profileId)
    }
    catch (error){
      Pop.error(error);
    }
}


</script>


<template>
    <div v-if="profile">

        <div class="container">
            <section class="row text-center">
                <div class="col-12">
          <div>
            <img :src="profile.coverImg" alt="Cover Image">
          </div>
          <img :src="profile.picture" :alt="profile.name" class="profile-picture">
          <p class="fs-2">{{ profile.name }}</p>
          <p>{{ profileVaults.length }} Vaults | {{ profileKeeps.length }} Keeps</p>
        </div>
    </section>

    <section class="row">
        <p class="fs-3 fw-bold">Vaults</p>
        <div v-for="vault in profileVaults" :key="vault.id" class="col-md-3">
          <RouterLink :to="{ name: 'Vault', params: { vaultId: vault.id } }">
            <VaultCard :vaultProp="vault" />
          </RouterLink>
        </div>
    </section>
    
    <section class="row">
        <p class="fs-3 fw-bold">Keeps</p>
        <div v-for="keep in profileKeeps" :key="keep.id" class="col-md-3">
          <KeepCard :keepProp="keep" />
        </div>
      </section>
    </div>
</div>

    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
  </div>
</template>


<style lang="scss" scoped></style>