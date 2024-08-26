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
    <div class="col-md-6">
      <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.name">
    </div>
    <div class="col-md-6">
      <div class="keep-body d-flex flex-column justify-content-between">
        <div>
            <p><i class="mdi mdi-eye"></i>{{ keep.views }}</p>
            <p><i class="mdi mdi-alpha-k-box-outline"></i>{{ keep.kept }}</p>
        </div>
        <div>
            <h2 class="keep-name">{{ keep.name }}</h2>
            <p class="keep-description">{{ keep.description }}</p>
        </div>
        <div>
            <p class="text-danger">selectable vault form goes here</p>
            <button type="submit" class="btn btn-info">Save</button>
        </div>
        
      </div>
    </div>
  </div>
</div>

</template>


<style lang="scss" scoped>

</style>