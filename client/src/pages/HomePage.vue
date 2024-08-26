<script setup>
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';



onMounted(getKeeps)

async function getKeeps(){
  try {
    await keepsService.getKeeps()
  }
  catch (error){
    Pop.error(error);
  }
}
</script>

<template>
  <h1>Keeps</h1>
</template>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
