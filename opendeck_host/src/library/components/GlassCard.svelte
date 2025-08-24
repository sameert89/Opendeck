<script lang="ts">
  import { theme, themes, accent } from "../stores/theme";

  let currentTheme = $derived(themes[$theme]);
  let { image, title, isEnabled } = $props();
  const activeBorderColor = accent;
</script>

<div
  class="flex flex-col items-center justify-center w-40 h-40 rounded-xl backdrop-blur-md shadow-lg transition-all duration-300 
         border btn-hover"
  style="
    border-color: {isEnabled ? activeBorderColor : 'rgba(75, 85, 99, 0)'};
    --btn-bg: {isEnabled ? currentTheme.backgroundLight : currentTheme.background};
    --btn-bg-hover: {currentTheme.backgroundLight};
  "
>
  <img
    src={image}
    alt={title}
    class="w-16 h-16 object-contain mb-2"
  />
  <p
    class="text-white font-semibold text-sm"
    style="color: {currentTheme.text}"
  >
    {title}
  </p>
</div>
