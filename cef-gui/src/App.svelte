<script lang="ts">
  //import logo from './assets/svelte.png'
  //import Counter from './lib/Counter.svelte'
  import { Router } from 'svelte-router-spa'
  import { routes } from './routes'
</script>

<p class="text-3xl font-bold underline">Hello World</p>
<a href="/bye">Goodbye</a>

<Router {routes} />