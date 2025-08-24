<script lang="ts">
import { theme, themes } from "../stores/theme";
import NavButton from "./NavButton.svelte";

let currentTheme = $derived(themes[$theme]);
let isOpen = $state(true);

const handleMenuButtonPress = () => (isOpen = !isOpen);
</script>


<!-- Single sidebar container -->
<div
	class="flex flex-col h-screen items-center transition-all duration-300 ease-in-out"
	class:w-[20rem]={isOpen}
	class:w-[4rem]={!isOpen}
	style="background-color: {currentTheme.background}"
>

	<button
		aria-label="menu"
		class="w-8 btn-hover rounded-md mr-auto ml-4 mt-4"
		style="--btn-bg: {currentTheme.background}; --btn-bg-hover: {currentTheme.backgroundLight}"
		onclick={handleMenuButtonPress}
	>
		<img src="/Collapse.svg" class="w-6 mx-auto my-auto" alt="menu-icon" />
	</button>
	<div class="flex flex-col h-full mt-20 items-center w-full">
		<NavButton iconPath={"/Home.svg"} text={ isOpen ? "Home" : "" } isActive={true} targetRoute="/"/>
		<NavButton iconPath={"/Devices.svg"} text={ isOpen ? "Devices" : "" } isActive={false} targetRoute="/devices"/>
	</div>
	<div class="flex-1"></div>
	<NavButton iconPath={"/Settings.svg"} text={ isOpen ? "Settings" : "" } isActive={false} targetRoute="/settings"/>
</div>
