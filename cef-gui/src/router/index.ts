import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'
import GuiView from '../views/GuiView.vue'
import LoginView from '../views/LoginView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/gui',
    name: 'gui',
    component: GuiView
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
