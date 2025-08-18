<script lang="ts">
  import { theme, themes } from "../stores/theme.js";

  const currentTheme = $derived(themes[$theme]);

  let { iconPath, text, isActive: isSelected } = $props();
</script>

<button
  class="flex flex-row border-none w-[96%] h-[4rem] rounded-md p-3 items-center my-1"
  style={`background-color:${isSelected ? currentTheme.backgroundLight : currentTheme.background}`}
>
  <img src={iconPath} alt="icon" class="w-5 mx-3" />
  <p class="text-xl" style="color: {currentTheme.text}">{text}</p>
</button>
