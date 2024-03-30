using SFML.Graphics;

namespace Space_Invaders
{
    public class TextureManager
    {
        private const string ASSETS_PATH = "/Users/pavelpavlovic/Desktop/C#/Space Invader/Space Invader/Assets";
        private const string BACKGROUND_TEXTURE_PATH = "/Backgrounds/blueBG.png";
        private const string PLAYER_TEXTURE_PATH = "/Ships/playerShip1_red.png";
        private const string ENEMY_TEXTURE_PATH = "/Enemies/enemyBlack5.png";

        public static Texture BackgroundTexture;
        public static Texture PlayerTexture;
        public static readonly Texture EnemyTexture;
        public static readonly SpriteAtlas ExplosionAtlas;

        private static readonly SpriteAtlasSettings ExplosionAtlasSettings =
            new(ASSETS_PATH + "/Explosions/explosionsAtlas.png", 4, 4);

        static TextureManager()
        {
            BackgroundTexture = new Texture(ASSETS_PATH + BACKGROUND_TEXTURE_PATH);
            PlayerTexture = new Texture(ASSETS_PATH + PLAYER_TEXTURE_PATH);
            EnemyTexture = new Texture(ASSETS_PATH + ENEMY_TEXTURE_PATH);
            ExplosionAtlas = new SpriteAtlas(ExplosionAtlasSettings);
        }
    }
}