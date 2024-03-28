using SFML.Graphics;
using SFML.System;

namespace Space_Invaders
{
    public class Enemy
    {
        private readonly float _enemySpeed; 
        private readonly Sprite _sprite;

        public Enemy(float enemySpeed, Texture texture, Vector2f spawnPosition)
        {
            _enemySpeed = enemySpeed;
            _sprite = new Sprite(texture);
            _sprite.Position = spawnPosition;
        }
        public void Update()
        {
            Move();
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
        }
        public FloatRect GetGlobalBounds()
        {
            return _sprite.GetGlobalBounds();
        }
        private void Move()
        {
            _sprite.Position += new Vector2f(0, _enemySpeed);
        }
    }
}