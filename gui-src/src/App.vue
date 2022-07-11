<template>
  <router-view/>
</template>

<script>
import store from '@/store/index'

export default {
  methods: {
    setInCar(toggle){
      this.$store.state.playerInfo.inVeh = toggle 
    },
  }
}
</script>
