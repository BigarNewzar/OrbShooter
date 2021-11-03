using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// logic related projectileSlow 
    /// </summary>
    public class ProjectileSlow: Projectile
    {
        /// <summary>
        /// basically sets the speed and damage of the projectile
        /// </summary>
        /// <param name="position">passes position to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public ProjectileSlow(Vector2 position, Vector2 dimension, string address, Game game)
          : base(position, dimension, address, game)
        {
            base.Damage = Global.projectileSlowDamage;
            base.Speed = Global.projectileSlowSpeed;
        }
    }
}