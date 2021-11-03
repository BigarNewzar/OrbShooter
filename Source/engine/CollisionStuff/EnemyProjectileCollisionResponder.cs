
namespace TopDownGame
{
    /// <summary>
    /// Basically it will pefrom its task when it gets signal that any projectile has hit any enemy
    /// </summary>
    public class EnemyProjectileCollisionResponder
    {
        public EnemyProjectileCollisionResponder()
        {
        }

        /// <summary>
        /// it will make projectile disappear upon contact and ensure enemy's health decrease 
        /// by the damage allocated to that projectile. It calls the projectile's hitenemy method 
        /// and passes its damage value to enemy's washit method
        /// </summary>
        /// <param name="p">Passes in projectile from Collision Detector's projectilelist</param>
        /// <param name="e">Passes in enemy from Collision Detector's enemylist</param>
        public void EnemyProjectileCollide(Projectile p, Enemy e)
        {
            p.HitEnemy();
            e.WasHit(p.Damage);
        }
    }
}
