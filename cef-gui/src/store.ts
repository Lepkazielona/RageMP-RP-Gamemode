import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        player:{
            inVehicle: false,
        }
	},
});
export default store;