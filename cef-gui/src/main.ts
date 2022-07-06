import { createApp, VueElement } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/tailwind.css'
import GuiView from "./views/GuiView.vue"
//import Vue from 'vue'

const app = createApp(App).use(router).mount('#app')


//GuiView.prototype.$speed = 0
//App.prototype.$speed = 0;
/*
function setSpeed(speed: Number){
    GuiView.prototype.$speed = speed;
}
*/
