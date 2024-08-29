<script setup>
import { ref } from 'vue';


const editableAccountData =  ref({
    name: '',
    picture:'',
    coverImg: ''

})

</script>


<template>

<form @submit.prevent="" class="p-2">
    <div class="mt-2 mb-4">
        <label for="name" class="mb-1">Name</label>
        <input v-model="editableAccountData.name" class="form-control" type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-4">
        <label for="description" class="mb-1">Picture</label>
        <input v-model="editableAccountData.picture" class="form-control" type="text" id="description" maxlength="1000" required>
    </div>
    <div class="mb-4">
        <label for="img" class="mb-1">Cover Image URL</label>
        <input v-model="editableAccountData.coverImg" class="form-control" type="text" id="img" maxlength="1000" required>
    </div>
    <div class="text-end p-2">
        <button type="submit" class="btn btn-info rounded-pill">Edit Account</button>
    </div>
</form>

</template>


<style lang="scss" scoped>

</style>