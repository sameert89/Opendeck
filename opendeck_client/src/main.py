import logging
from config.settings import Settings
from scenes.main_scene import Game

# configure logging
logging.basicConfig(level=Settings.log_level)

if __name__ == "__main__":
    Game().run()