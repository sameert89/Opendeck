import pygame
import sys
from utils.screen_info import grab_screen_info

pygame.init()

SCREEN_WIDTH, SCREEN_HEIGHT = grab_screen_info()
FPS = 60

WHITE = (255, 255, 255)
BLACK = (0, 0, 0)
RED = (255, 0, 0)
GREEN = (0, 255, 0)
BLUE = (0, 0, 255)

class Game:
    def __init__(self):
        self.screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
        pygame.display.set_caption("Simple Pygame Scene")
        self.clock = pygame.time.Clock()
        self.running = True
        
        # Game variables
        self.player_x = SCREEN_WIDTH // 2
        self.player_y = SCREEN_HEIGHT // 2
        self.player_size = 50
        
    def handle_events(self):
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                self.running = False
            elif event.type == pygame.KEYDOWN:
                if event.key == pygame.K_ESCAPE:
                    self.running = False
    
    def update(self):
        keys = pygame.key.get_pressed()
        speed = 5
        
        if keys[pygame.K_LEFT] or keys[pygame.K_a]:
            self.player_x -= speed
        if keys[pygame.K_RIGHT] or keys[pygame.K_d]:
            self.player_x += speed
        if keys[pygame.K_UP] or keys[pygame.K_w]:
            self.player_y -= speed
        if keys[pygame.K_DOWN] or keys[pygame.K_s]:
            self.player_y += speed
            
        self.player_x = max(0, min(SCREEN_WIDTH - self.player_size, self.player_x))
        self.player_y = max(0, min(SCREEN_HEIGHT - self.player_size, self.player_y))
    
    def draw(self):
        self.screen.fill(WHITE)
        
        player_rect = pygame.Rect(self.player_x, self.player_y, self.player_size, self.player_size)
        pygame.draw.rect(self.screen, RED, player_rect)
        
        pygame.draw.rect(self.screen, BLACK, (0, 0, SCREEN_WIDTH, SCREEN_HEIGHT), 2)
        
        pygame.display.flip()
    
    def run(self):
        while self.running:
            self.handle_events()
            self.update()
            self.draw()
            self.clock.tick(FPS)
        
        pygame.quit()
        sys.exit()