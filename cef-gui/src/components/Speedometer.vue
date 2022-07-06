<template>
    <div class="speedometer container  bg-gradient-to-r from-lime-300 to-cyan-300 p-9">
        <p class="display">{{ speed }} km/h</p>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'Speedometer',
  props: {
    speed: Number,
  },
});
</script>

<style lang="css" scoped>
@import url('https://fonts.googleapis.com/css2?family=Chakra+Petch&display=swap');
.display {
    font-family: 'Chakra Petch';
}
</style>