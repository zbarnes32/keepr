<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const keeps = computed(() => AppState.keeps)

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
  <section class="container">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-md-3">
        <KeepCard :keep="keep" />
      </div>
    </div>
  </section>
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
