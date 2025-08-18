import { writable } from 'svelte/store';

interface ThemeColors {
    primary: string;
    background: string;
    backgroundLight: string;
    text: string;
}

export const theme = writable('dark');

export const themes: Record<string, ThemeColors> = {
    'dark': {
        primary: "#272727",
        background: "#202020",
        backgroundLight: "#2D2D2D",
        text: '#ffffff'
    }
};

export const accent: string = "#00B3FF";