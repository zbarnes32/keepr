<script setup>
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';


const editableVaultData =  ref({
    name: '',
    description:'',
    img: '',
    isPrivate: false
})

async function createVault(){
    try {
      await vaultsService.createVault(editableVaultData.value)
      Modal.getOrCreateInstance('#createVaultModal').hide()
      editableVaultData.value = {
        name: '',
        description: '',
        img: '',
        isPrivate: false
      }
      Pop.toast("You have successfully created a vault!")
    }
    catch (error){
      Pop.error(error);
    }
}

</script>


<template>

<form @submit.prevent="createVault()" class="p-2">
    <div class="mt-2 mb-4">
        <label for="name" class="mb-1">Name</label>
        <input v-model="editableVaultData.name" class="form-control" type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-4">
        <label for="description" class="mb-1">Description</label>
        <input v-model="editableVaultData.description" class="form-control" type="text" id="description" maxlength="1000" required>
    </div>
    <div class="mb-4">
        <label for="img" class="mb-1">Image URL</label>
        <input v-model="editableVaultData.img" class="form-control" type="text" id="img" maxlength="1000" required>
    </div>
    <div class="mb-4">
        <label for="isPrivate" class="mb-1 form-check-label">Want to make this vault private?</label>
        <input v-model="editableVaultData.isPrivate" class="form-check-input" type="checkbox" id="img">
    </div>
    <div class="text-end p-2">
        <button type="submit" class="btn btn-info rounded-pill">Create</button>
    </div>
</form>
</template>


<style lang="scss" scoped>



</style>