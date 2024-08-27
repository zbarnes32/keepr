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

<form @submit.prevent="createKeep()">
    <div class="mb-2">
        <label for="name">Name</label>
        <input v-model="editableKeepData.name" type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-2">
        <label for="description">Description</label>
        <input v-model="editableKeepData.description" type="text" id="description" maxlength="1000" required>
    </div>
    <div class="mb-2">
        <label for="img">Image URL</label>
        <input v-model="editableKeepData.img" type="text" id="img" maxlength="1000" required>
    </div>
    <div class="text-end p-2">
        <button type="submit" class="btn btn-info rounded-pill">Create</button>
    </div>
</form>
</template>


<style lang="scss" scoped>

</style>