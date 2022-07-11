import { createApp, mergeProps } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './assets/tailwind.css'
/**
 * 
 * 
 * 
 const app = new Vue({
     router,
     store,
    }).mount('#app')
    export default app;
    */
const app = createApp(App).use(store).use(router).mount('#app')
export default app;
//mp.events.add("set")