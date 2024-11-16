<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import KeepDetailsCard from '@/components/globals/KeepDetailsCard.vue';
import MainModal from '@/components/globals/MainModal.vue';
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
        <KeepCard :keepProp="keep" />
      </div>
    </div>
  </section>

  <MainModal modalId="keepModal" class="modal-xl">
        <template #modalBody><KeepDetailsCard/></template>
  </MainModal>
</template>

<style scoped lang="scss">

</style>
