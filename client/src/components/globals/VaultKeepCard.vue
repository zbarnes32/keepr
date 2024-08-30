<script setup>
import { AppState } from '@/AppState.js';
import { VaultKeep } from '@/models/VaultKeep.js';
import { computed } from 'vue';


const account = computed(() => AppState.account)

const props = defineProps({ vaultKeepProp: {type: VaultKeep}})

</script>


<template>
    <section>
        <div class="shadow" role="button">
            <div class="card bg-dark text-white" data-bs-toggle="modal" data-bs-target="#vaultKeepModal">
                <img :src="vaultKeepProp.img" class="card-img" :alt="vaultKeepProp.name">
                <div class="card-img-overlay">
                    <p class="fs-4 card-name">{{ vaultKeepProp.name }}</p>
                    <RouterLink :to="{ name: 'Profile', params: { profileId: vaultKeepProp.creatorId } }"
                        :title="`Click here to go to ${vaultKeepProp.creator.name}'s profile.'`">
                        <img :src="vaultKeepProp.creator.picture" :alt="vaultKeepProp.creator.name" class="creator-picture">
                    </RouterLink>
                </div>
            </div>
        </div>
    </section>

</template>


<style lang="scss" scoped>

</style>