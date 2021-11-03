
namespace TopDownGame
{
    /// <summary>
    /// contains almost all the constants in the game (except the new binding conditions that have been added to match with picture given in active logic)
    /// </summary>
    public class Global
    {
        public const int screenHeight = 800;
        public const int screenWidth = 800;

        public const int projectileHeight = 20;
        public const int projectileWidth = 20;
        public const int projectileRotationVelocity = 3;
        public const int projectileLinearVelocity = 4;
        public const double shootDelay = 0.15;

        public const int projectileSlowDamage = 2;
        public const int projectileSlowSpeed = 5;

        public const int projectileNormalDamage = 1;
        public const int projectileNormalSpeed = 10;

        public const int enemyHeight = 50;
        public const int enemyWidth = 50;
        public const double moveTimeLimit = 2;
        public const double spawnTimeLimit = 1;
        public const float enemyNormalSpeed = 1;
        public const int enemyNormalHealth = 1;
        public const float enemyHomingSpeed = 0.005f;
        public const int enemyHomingHealth = 5;

        public const int playerHeight = 50;
        public const int playerWidth = 50;
        public const int playerSpeed = 2;
        public const int playerHealth = 5;
        public const int playerCollideDamage = 10;

        public const int objectTouchDistance = 50;
    }
}
