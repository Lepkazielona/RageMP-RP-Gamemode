import { createStore } from 'vuex'

export default createStore({
  state: {
    playerInfo: {
      inVeh: false,
      vehSpeed: 0,
    }
  },
  getters: {
  },
  mutations: {
    setVehSpeed(state, speed){
      state.playerInfo.vehSpeed = speed;
    },
    togglePlayerInVeh(state, toggle){
      state.playerInfo.inVeh = toggle;
    },
  },
  actions: {
  },
  modules: {
  }
})
