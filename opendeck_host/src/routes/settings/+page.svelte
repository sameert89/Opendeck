<script lang="ts">
import { theme, themes } from "../../library/stores/theme";
import ToggleSwitch from "../../library/components/ToggleSwitch.svelte";

let currentTheme = $derived(themes[$theme]);

let isServerEnabled = $state(true);

const serverToggleCallback = () => {
	isServerEnabled = !isServerEnabled;
}

</script>

<div class="w-full pb-10">
	<section id="title" class="relative top-0 w-full h-35" style="color: {currentTheme.text}">
		<h1 class="text-[3rem] font-bold absolute top-12 left-10">Settings</h1>
	</section>
	<section id="server">
		<h1 class="text-[2rem] font-bold ml-10 mt-4" style="color: {currentTheme.text}">
			Server
		</h1>
		<div class="w-[90%] h-40 bg-black ml-10 mt-4 p-4 rounded-md overflow-auto" style="color: {currentTheme.text}">
		<div id="server-enabled-button" class="flex flex-row align-center w-full justify-between">
			Enable
			<ToggleSwitch isActive={isServerEnabled} callback={serverToggleCallback}/>
		</div>
		</div>
	</section>
	<section id="theme">
		<h1 class="text-[2rem] font-bold ml-10 mt-4" style="color: {currentTheme.text}">
			Theme
		</h1>
		<div class="w-[90%] h-40 bg-black ml-10 mt-4 p-4 rounded-md overflow-auto" style="color: {currentTheme.text}">

		</div>
	</section>
	<section id="debug-log mb">
		<h1 class="text-[2rem] font-bold ml-10 mt-4" style="color: {currentTheme.text}">
			Debug Log
		</h1>
		<div class="w-[90%] h-40 bg-black ml-10 mt-4 p-4 rounded-md overflow-auto" style="color: {currentTheme.text}">

		</div>
	</section>
</div>
