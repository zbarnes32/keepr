<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';


const props = defineProps({ keepProp: {type: Keep, required: true} })

function setActiveKeep() {
    keepsService.setActiveKeep(props.keepProp)
}
</script>


<template>
    <section>
        <div class="shadow" role="button">
            <div class="card bg-dark text-white" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep()">
                <img :src="keepProp.img" class="card-img" :alt="keepProp.name">
            <div class="card-img-overlay">
                <p class="fs-4 card-name">{{ keepProp.name }}</p>
                <img :src="keepProp.creator.picture" class="creator-picture">
            </div>
            </div>
        </div>
    </section>

</template>


<style lang="scss" scoped>

.card-name{
    position: absolute;
    bottom: 0;
    left: 0;
}

.creator-picture {
    height: 5vh;
    object-fit: cover;
    border-radius: 50%;
    position: absolute;
    bottom: 0;
    right: 0;
}
</style>