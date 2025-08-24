<script lang="ts">
	import '../app.css';
	import NavBar from "../library/components/NavBar.svelte";
	import { theme, themes } from "../library/stores/theme";

	let currentTheme = $derived(themes[$theme]);
	
	let { children } = $props();
</script>

<div
  class="flex w-full h-screen"
  style="background-color: {currentTheme.primary};"
>
  <NavBar />

  <div class="flex-1 overflow-y-auto">
    {@render children()}
  </div>
</div>
