<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

const props = defineProps({ keepProp: { type: Keep, required: true } })

function setActiveKeep() {

    keepsService.getKeepById(props.keepProp.id)
}


async function destroyKeep(keepId) {
    try {
        const wantsToDestroy = await Pop.confirm(`Are you sure you want to delete the ${props.keepProp.name}?`)
        if (!wantsToDestroy) return
        await keepsService.destroyKeep(keepId)
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>


<template>
    <section>
        <div class="shadow" role="button" v-if="!keepProp.vaultKeepId">
            <div class="card bg-dark text-white" data-bs-toggle="modal" data-bs-target="#keepModal"
                @click="setActiveKeep()">
                <img :src="keepProp.img" class="card-img" :alt="keepProp.name">
                <div class="card-img-overlay">
                    <button v-if="account?.id == keepProp.creatorId" class="bg-danger rounded-pill"
                        @click="destroyKeep(keepProp.id)"><i class="mdi mdi-delete-forever text-light"></i>
                    </button>
                    <p class="fs-4 card-name">{{ keepProp.name }}</p>
                    <RouterLink :to="{ name: 'Profile', params: { profileId: keepProp.creatorId } }"
                        :title="`Click here to go to ${keepProp.creator.name}'s profile.'`">
                        <img :src="keepProp.creator.picture" :alt="keepProp.creator.name" class="creator-picture">
                    </RouterLink>
                </div>
            </div>
        </div>
        <div v-else>
            THIS IS A VK
        </div>
    </section>

</template>


<style lang="scss" scoped>
.card-name {
    position: absolute;
    bottom: 0;
    left: 0;
}

.creator-picture {
    height: 5vh;
    object-fit: cover;
    border-radius: 50%;
    position: absolute;
    bottom: 0;
    right: 0;
}
</style>