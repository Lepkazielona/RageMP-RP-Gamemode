<template>
  <speedometer-item :speed="text"></speedometer-item>
  <input type="text" v-model="text">
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import SpeedometerItem from './components/SpeedometerItem.vue'

export default defineComponent({
  name: 'App',
  components: {
    SpeedometerItem
  },
  data: function () {
    return {
      text: ''
    }
  }
})
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
