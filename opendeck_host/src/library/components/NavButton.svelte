<script lang="ts">
  import { theme, themes } from "../stores/theme.js";

  const currentTheme = $derived(themes[$theme]);

  let { iconPath, text, isActive, targetRoute } = $props();
</script>

<a
  href="{targetRoute}"
  class="btn-hover flex flex-row border-none w-[96%] h-[3.5rem] rounded-md p-3 items-center my-0.5 btn-hover"
  style="--btn-bg: {isActive
    ? currentTheme.backgroundLight
    : currentTheme.background}; --btn-bg-hover: { currentTheme.backgroundLight }"
>
  <img src={iconPath} alt="icon" class="w-4 mx-3" />
  <p class="text-lg" style="color: {currentTheme.text}">
    {text}
  </p>
</a>
