 /* eslint-disable */

<template>
  <div class="hello">
    <h1>{{ speed }}</h1>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'SpeedometerItem',
  props: {
    speed: String
  }
})
</script>
