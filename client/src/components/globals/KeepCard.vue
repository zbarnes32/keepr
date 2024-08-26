<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({ keep: {type: Keep, required: true} })
</script>


<template>
    <h1>{{  keep.name }}</h1>
</template>


<style lang="scss" scoped>

</style>