<script lang="ts">
let { isActive, callback } = $props<{
	isActive: boolean;
	callback?: () => void;
}>();

import { accent, theme, themes } from "../stores/theme";
const currentTheme = $derived(themes[$theme]);

const handleToggle = () => {
	callback?.();
};

const handleKeydown = (e: KeyboardEvent) => {
	if (e.key === " " || e.key === "Enter") {
		e.preventDefault();
		callback?.();
	}
};

const trackBg = $derived(
	isActive ? accent : currentTheme.backgroundLight
);
</script>

	<button
	type="button"
	role="switch"
	aria-checked={isActive}
	class="group inline-flex select-none items-center focus:outline-none"
	onclick={handleToggle}
	onkeydown={handleKeydown}
>
	<!-- Track -->
	<div
		class="relative rounded-full transition-colors duration-200 ease-out
		shadow-inner ring-1 ring-black/10
		w-12 h-7"
		style="background-color: {trackBg};"
	>

		<!-- Thumb -->
		<div
			class="absolute top-1 left-1 h-5 w-5 rounded-full bg-white
			shadow-[0_1px_2px_rgba(0,0,0,0.15),_0_4px_8px_rgba(0,0,0,0.12)]
			transition-all duration-200 ease-out
			will-change-transform"
			style="
			transform: translateX({isActive ? 'calc(100% + 0.15rem)' : '0px'});
			"
		></div>

	</div>
</button>

<style>
@media (prefers-reduced-motion: reduce) {
	.transition-all,
	.transition-colors {
		transition: none !important;
	}
}
</style>
