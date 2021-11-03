using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// Utilizing observer/ detector/ responder pattern to see if collision took place between player and enemy or enemy and projectile and if so, do needed tasks
    /// </summary>
    public class CollisionDetector
    {   
        private EnemyPlayerCollisionResponder _enemyPlayerCollideResponder;
        private EnemyProjectileCollisionResponder _enemyProjectileCollideResponder;

        /// <summary>
        /// make instances of the two types of responder
        /// </summary>
        public CollisionDetector()
        {
            _enemyPlayerCollideResponder = new EnemyPlayerCollisionResponder();
            _enemyProjectileCollideResponder = new EnemyProjectileCollisionResponder();
        }

        /// <summary>
        /// detect what had happened for all projectile and enemies and call certain functions from responder if in touch distance
        /// </summary>
        /// <param name="player">passes player from activeGameLogic to responder for player enemy collision</param>
        /// <param name="enemyList">passes list of enemies from activeGameLogic to responder for player enemy collision,
        /// and enemy and projectile collision</param>
        /// <param name="projectileList">passes list of projectiles from activeGameLogic to responder for projectile enemy collision</param>
        public void Detect(Player player, List<Enemy> enemyList, List<Projectile> projectileList)
        {
            foreach (Enemy e in enemyList)
            {
                if (Vector2.Distance(player.Pos, e.Pos) <= Global.objectTouchDistance)//basically when distance between them is 50 or less
                {
                    _enemyPlayerCollideResponder.EnemyPlayerCollide(player, e);
                }

                foreach (Projectile p in projectileList)
                {
                    if (Vector2.Distance(p.Pos, e.Pos) <= Global.objectTouchDistance)//basically when distance between them is 50 or less
                    {
                        _enemyProjectileCollideResponder.EnemyProjectileCollide(p, e);                        
                    }
                }
            }

        }
    }
}
