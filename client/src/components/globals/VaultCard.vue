<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';



const account = computed(() => AppState.account)

const vault = computed(() => AppState.activeVault)

const props = defineProps({ vaultProp: {type: Vault, required: true} })


// function setActiveVault() {
//     vaultsService.setActiveVault(props.vaultProp)
// }

async function destroyVault(vaultId){
    try {
      const wantsToDestroy = await Pop.confirm(`Are you sure that you want to delete?`)
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
    <div class="shadow m-2" role="button">
        <!-- TODO add a routerlink to go the vault page by its id -->
        <div class="card vault-card bg-dark text-white">
            <img :src="vaultProp.img" class="card-img" :alt="vaultProp.name">
            <div class="card-img-overlay">
                <button v-if="account?.id == vaultProp.creatorId" class="bg-danger rounded-pill" @click="destroyVault(vaultProp.id)"><i class="mdi mdi-delete-forever text-light"></i>
                </button>
                <p class="fs-2 card-name">{{ vaultProp.name }}</p>
            </div>
        </div>
    </div>
</section>

</template>


<style lang="scss" scoped>

.vault-card {
    height: 15vh;
}

.card-img {
    max-height: 15vh;
    aspect-ratio: 1/1;
    object-fit: cover;
    object-position: center;
    
}

.card-name{
    position: absolute;
    bottom: 0;
    left: 0;
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}


</style>