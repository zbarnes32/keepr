<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({ keep: {type: Keep, required: true} })
</script>


<template>
    <section>
        <div class="shadow">
            <div class="card bg-dark text-white">
                <img :src="keep.img" class="card-img" :alt="keep.name">
            <div class="card-img-overlay">
                <p class="fs-4 card-name">{{ keep.name }}</p>
                <img :src="keep.creator.picture" class="creator-picture">
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