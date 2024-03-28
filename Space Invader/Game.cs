using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders
{
    public class Game
    {
        private readonly RenderWindow _window;
        private readonly Sprite _background;
        private readonly Player _player;
        private readonly EnemyManager _enemyManager;
        private readonly CollisionHandler _collisionHandler;
        private readonly SpriteAnimation _animation;

        public Game(GameConfiguration gameConfiguration)
        {
            var mode = new VideoMode((uint) gameConfiguration.Width, (uint) gameConfiguration.Height);
            _window = new RenderWindow(mode, gameConfiguration.Title);
            
            _window.SetVerticalSyncEnabled(true);
            _window.Closed += (_, _) => _window.Close();
            
            _background = new Sprite(TextureManager.BackgroundTexture);

            _player = CreatePlayer(gameConfiguration);
            var screenSize = new Vector2f(gameConfiguration.Width, gameConfiguration.Height);
            _enemyManager = new EnemyManager(gameConfiguration.EnemySpawnCooldown, gameConfiguration.EnemySpeed, screenSize);
            _collisionHandler = new CollisionHandler(_player, _enemyManager);
            var position = new Vector2f(10,10);
            _animation = new SpriteAnimation(position, TextureManager.ExplosionAtlas, 0.2f);
        }
        private Player CreatePlayer(GameConfiguration gameConfiguration)
        {
            var shootingCooldown = gameConfiguration.PlayerSettings.ShootingCooldown;
            var shootingManager = new ShootingManager(gameConfiguration.BulletSpeed, gameConfiguration.BulletRadius,
                shootingCooldown);
            var playerSpawnPosition = GetPlayerSpawnPosition(gameConfiguration, TextureManager.PlayerTexture);
            var playerMovement = new PlayerMovement(gameConfiguration.PlayerSettings);
            var shootingButton = gameConfiguration.PlayerSettings.ShootingButton;
            return new Player(shootingManager, shootingButton, TextureManager.PlayerTexture,
                playerSpawnPosition, playerMovement);
        }
        private Vector2f GetPlayerSpawnPosition(GameConfiguration gameConfiguration, Texture texture)
        {
            var screenCenter = new Vector2f(gameConfiguration.Width / 2f, gameConfiguration.Height / 2f);
            var playerSpawnPosition = screenCenter - (Vector2f) texture.Size / 2f;
            return playerSpawnPosition;
        }
        public void Run()
        {
            while (_window.IsOpen && !_player.IsPlayerDead)
            {
                HandleEvents();
                Update();
                Draw();
            }
        }
        public void ShowGameOverScreen()
        {
            while (_window.IsOpen)
            {
                HandleEvents();
                _window.Clear(Color.Black);
                _window.Display();
            }
        }
        private void HandleEvents()
        {
            _window.DispatchEvents();
        }
        private void Update()
        {
            _animation.Update();
            _player.Update();
            _enemyManager.Update();
            _collisionHandler.Update();
            
        }
        private void Draw()
        {
            _window.Draw(_background);
            _animation.Draw(_window);
            _player.Draw(_window);
            _enemyManager.Draw(_window);
            
            
            _window.Display();
        }
    }
}