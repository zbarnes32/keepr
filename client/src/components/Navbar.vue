<script setup>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import MainModal from './globals/MainModal.vue';
import CreateKeepForm from './globals/CreateKeepForm.vue';
import CreateVaultForm from './globals/CreateVaultForm.vue';

const theme = ref(loadState('theme') || 'light')

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

</script>

<template>
  <nav class="navbar navbar-expand-sm navbar-light bg-light px-3 border-bottom">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column justify-content-center">
        <button role="button" class="fs-4 rounded-pill px-3">Home</button>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Create
          </a>
          <ul class="dropdown-menu dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
            <li><a class="dropdown-item" role="button" data-bs-toggle="modal" data-bs-target="#createKeepModal">New Keep</a></li>
            <li><a class="dropdown-item" role="button" data-bs-toggle="modal" data-bs-target="#createVaultModal">New Vault</a></li>
          </ul>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <div>
        <button class="btn text-light" @click="toggleTheme"
          :title="`Enable ${theme == 'light' ? 'dark' : 'light'} theme.`">
          <Icon :name="theme == 'light' ? 'weather-sunny' : 'weather-night'" />
        </button>
      </div>
      <Login />
    </div>
  </nav>

  <MainModal modalId="createKeepModal">
    <template #modalHeader>Create a Keep</template>
    <template #modalBody><CreateKeepForm /></template>
  </MainModal>

  <MainModal modalId="createVaultModal">
    <template #modalHeader>Create a Vault</template>
    <template #modalBody><CreateVaultForm /></template>
  </MainModal>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
