<script lang="ts">
import GlassCard from "../library/components/GlassCard.svelte";
import { theme, themes } from "../library/stores/theme";
import { whatsNew } from "../library/stores/static-text";

let currentTheme = $derived(themes[$theme]);
</script>

<div class="w-full">
	<section id="splash" class="relative top-0 w-full h-50" style="color: {currentTheme.text}">
		<h1 class="text-[3rem] font-bold absolute top-12 left-10">Opendeck</h1>
		<p class="absolute top-32 left-12">v0.0.1</p>
	</section>
	<!-- What's New Section -->
	<section id="whats-new">
		<h1 class="text-[2rem] font-bold ml-10 mt-4" style="color: {currentTheme.text}">
			What's New?
		</h1>
		<div class="w-[90%] h-35 bg-black ml-10 mt-4 p-4 rounded-md overflow-auto" style="color: {currentTheme.text}">
			<ul>
				{#each whatsNew as item}
					<li>{item}</li>	
				{/each}
			</ul>
		</div> 
	</section>

	<section id="decks">
		<h1 class="text-[2rem] font-bold ml-10 mt-4" style="color: {currentTheme.text}">
			Decks
		</h1>

		<!-- This is a Mockup -->
		<div class="ml-10 mt-4">
			<GlassCard image="/RpiLogo.svg" title="Raspberry Pi 5" isEnabled={false}/>
		</div>
	</section>
</div>


<style>     
#splash {
	background-image: url("/Splash.jpg");
	background-size: cover;
	background-position: center;
	background-repeat: no-repeat;
}
</style>
