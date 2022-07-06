<template>
  <!-- Speedometer -->
  <div v-if="inCar" class="absolute right-2 bottom-2">
    <speedometer :speed="this.$speed"></speedometer>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Speedometer from '@/components/Speedometer.vue'; // @ is an alias to /src

export default defineComponent({
  name: 'GuiView',
  components: {
    Speedometer
  }, data() { return {
      inCar: true,
      speed: Number 
  }},

});
</script>

<style>

</style>
