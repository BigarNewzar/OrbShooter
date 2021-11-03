
namespace TopDownGame
{
    /// <summary>
    /// Basically it will pefrom its task when it gets signal that player had hit any enemy
    /// </summary>
    public class EnemyPlayerCollisionResponder
    {
        public EnemyPlayerCollisionResponder()
        {            
        }

        /// <summary>
        /// it performs player's HitEnemy method which will decrease player Health by 1 (no matter what enemy)
        /// it will destroy the enemy no matter what type (as i set a very high collide damage value for player 
        /// + no invulnerability frame has been setup, so will player drain all enemy health almost instantly upon contact)
        /// </summary>
        /// <param name="player">Passes in player from Collision Detector</param>
        /// <param name="e">Passes in enemy from Collision Detector's enemylist</param>
        public void EnemyPlayerCollide(Player player, Enemy e)
        {
            player.HitEnemy();
            e.WasHit(player.CollideDamage); 
        }
    }
}
