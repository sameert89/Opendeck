<script lang="ts">
  import { theme, themes } from "../stores/theme";
  import NavButton from "./NavButton.svelte";

  let currentTheme = $derived(themes[$theme]);
</script>

<div
  class="flex flex-col w-[25%] h-full"
  style="background-color: {currentTheme.background }"
>
  <button aria-label="menu" class="absolute top-4 left-4 w-8 h-8">
    <img
      src="/Collapse.svg"
      class="w-8 "
      alt="menu-icon"
    />
  </button>
  <div class="flex flex-col h-full mt-28 items-center">
    <NavButton iconPath={"/Home.svg"} text={"Home"} isActive={true} />
    <NavButton iconPath={"/Devices.svg"} text={"Devices"} isActive={false} />
  </div>
  <NavButton iconPath={"/Settings.svg"} text={"Settings"} isActive={false} />
</div>