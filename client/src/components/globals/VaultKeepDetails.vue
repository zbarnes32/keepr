<script setup>
import { AppState } from '@/AppState.js';
import { VaultKeep } from '@/models/VaultKeep.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)
// const vaultKeep = computed(() => AppState.vaultKeeps)

// defineProps({ vaultKeepProp: { type: VaultKeep, required: true}})

// REVIEW: Why is this not waiting for my Pop.confirm before running???
async function removeKeepFromVault(vaultKeepId) {
  try {
    // debugger
    const wantsToDelete = await Pop.confirm("Are you sure that you want to delete?")
    if(!wantsToDelete) return
    await vaultKeepsService.removeKeepFromVault(vaultKeepId)
    Modal.getOrCreateInstance('#vaultKeepModal').hide()
  }
  catch (error) {
    Pop.error(error);
  }
}
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
            <div>
              <!-- {{ keep }} -->

             
              <button class="btn btn-danger-outline" @click="removeKeepFromVault(keep.vaultKeepId)"><i
                  class="mdi mdi-cancel"></i>
                Remove</button>
            </div>
            <div class="d-flex align-items-center">
              <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creatorId } }"
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