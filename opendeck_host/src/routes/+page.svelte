<script lang="ts">
  import { theme, themes } from "../library/stores/theme";
  import NavBar from "../library/components/NavBar.svelte";

  let currentTheme = $derived(themes[$theme]);
</script>

<div class="w-[75%]">
  <div id="splash" class="relative top-0 w-full h-70" style="color: {currentTheme.text}">
    <h1 >Opendeck</h1>
    <p>v0.0.1</p>
  </div>
</div>

<style>
  #splash {
    background-image: url("/Splash.jpg");
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
  }
</style>
