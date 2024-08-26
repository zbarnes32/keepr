<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import { computed } from 'vue';

const keep = computed(() => AppState.activeKeep)
// const props = defineProps({
//     keepProp: { type: Keep, required: true }
// })


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
            <div class="d-flex">
                <p class="text-danger">selectable vault form goes here</p>
                <button type="submit" class="btn btn-info">Save</button>
            </div>
            <div class="d-flex align-items-center">
                <img class="creator-img" :src="keep.creator.picture" :alt="keep.creator.name">
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