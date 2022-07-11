/*

  Main Gui Here, root route

*/

<template>
  <div class="home">
    <speedometer></speedometer>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Speedometer from '@/components/Speedometer.vue';

export default defineComponent({
  name: 'MainView',
  components: {
    Speedometer
  },
});
</script>
