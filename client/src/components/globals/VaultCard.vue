<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';



const account = computed(() => AppState.account)

const vault = computed(() => AppState.activeVault)

const props = defineProps({ vaultProp: {type: Vault, required: true} })

function setActiveVault() {
    vaultsService.setActiveVault(props.vaultProp)
}

async function destroyVault(vaultId){
    try {
      const wantsToDestroy = await Pop.confirm(`Are you sure that you want to delete ${vault.value.name}?`)
      if (!wantsToDestroy) return
      await vaultsService.destroyVault(vaultId)
    }
    catch (error){
      Pop.error(error);
    }
}

</script>


<template>

<section>
    <div class="shadow" role="button">
        <div class="card bg-dark text-white" @click="setActiveVault()">
                <img :src="vaultProp.img" class="card-img" :alt="vaultProp.name">
            <div class="card-img-overlay">
                <button v-if="account?.id == vaultProp.creatorId" class="bg-danger rounded-pill" @click="destroyVault(vaultProp.id)"><i class="mdi mdi-delete-forever text-light"></i>
                </button>
                <p class="fs-4 card-name">{{ vaultProp.name }}</p>
                <img :src="vaultProp.creator.picture" class="creator-picture">
            </div>
        </div>
    </div>
</section>

</template>


<style lang="scss" scoped>

</style>