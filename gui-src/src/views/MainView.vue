/*

  Main Gui Here, root route

*/

<template>
  <div>
    <speedometer></speedometer>
    <p>{{$store.state.playerInfo.inVeh}}</p>
  </div>
</template>

<script lang="ts">
import store from "@/store/index"
import { defineComponent } from 'vue';
import Speedometer from '@/components/Speedometer.vue';

export default defineComponent({
  name: 'MainView',
  components: {
    Speedometer
  },
  computed: {
    
  },
  methods: {
    function(){
      alert("bsbdajbsbdjabsdbajsbjdbajs")
    }
  }
});
</script>
