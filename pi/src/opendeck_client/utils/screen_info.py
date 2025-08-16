import pygame

def grab_screen_info() -> tuple[int, int]:
    info = pygame.display.Info()
    return (info.current_w, info.current_h)