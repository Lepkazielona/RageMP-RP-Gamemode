import HelloWorld from './routes/HelloWorld.svelte'
import GoodbyeWorld from './routes/GoodbyeWorld.svelte'

const routes = [
    {
      name: '/',
      component: HelloWorld,
    },
    {
        name: '/bye',
        component: GoodbyeWorld
    }
]
  
export { routes }