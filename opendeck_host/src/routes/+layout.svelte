<script lang="ts">
	import '../app.css';
	import NavBar from "../library/components/NavBar.svelte";
	import { theme, themes } from "../library/stores/theme";

	let currentTheme = $derived(themes[$theme]);
	
	let { children } = $props();
</script>

<div
  class="flex flex-row w-full h-full"
  style="background-color: {currentTheme.primary};"
>
  <NavBar />
  {@render children()}
</div>


