<script setup>
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';


const editableKeepData =  ref({
    name: '',
    description:'',
    img: ''
})

async function createKeep(){
    try {
      await keepsService.createKeep(editableKeepData.value)
      Modal.getOrCreateInstance('#createKeepModal').hide()
      editableKeepData.value = {
        name: '',
        description: '',
        img: ''
      }
    }
    catch (error){
      Pop.error(error);
    }
}

</script>


<template>

<form @submit.prevent="createKeep()" class="p-2">
    <div class="mt-2 mb-4">
        <label for="name" class="mb-1">Name</label>
        <input v-model="editableKeepData.name" class="form-control" type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-4">
        <label for="description" class="mb-1">Description</label>
        <input v-model="editableKeepData.description" class="form-control" type="text" id="description" maxlength="1000" required>
    </div>
    <div class="mb-4">
        <label for="img" class="mb-1">Image URL</label>
        <input v-model="editableKeepData.img" class="form-control" type="text" id="img" maxlength="1000" required>
    </div>
    <div class="text-end p-2">
        <button type="submit" class="btn btn-info rounded-pill">Create</button>
    </div>
</form>
</template>


<style lang="scss" scoped>



</style>