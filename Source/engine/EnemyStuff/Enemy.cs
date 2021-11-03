using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// Using inheritance/ template design where the enemy is giving basic idea of what all enemy can do and know 
    /// but letting subclasses override it to decide what they should actually do
    /// (enemy class will determine all cases on whether an enemy is expired or not)
    /// </summary>
    public class Enemy : Entity
    {
        /// <summary>
        /// it is basically a template that every enemy will follow. Here all enemies know what to do if they are hit and how to update and draw themselves
        /// </summary>
        /// <param name="position">passes position (of spawning) to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public Enemy(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {            
        }

        /// <summary>
        /// it decrease its health depending on value of projectile damage or player collide damage passed to it
        /// then if its health is less or equal to zero, it will be expired and play soundeffect for enemykilled
        /// </summary>
        /// <param name="n"> the number passed from enemyprojectile collision and enemyplayer collision responder classes</param>
        public void WasHit(int n)
        {
            base.Health -= n;

            if (base.Health <= 0)
            {
                base.IsExpired = true;
                base.SoundPlayer.PlaySoundEffect("enemyKilled");
            }
        }

        /// <summary>
        /// as long as not expired, it will use its parent class to update itself
        /// </summary>
        /// <param name="gameTime">it will use gametime passed from enemy spawner to update itself</param>
        public override void Update(GameTime gameTime)
        {
            if (base.IsExpired == false)
            {
                base.Update(gameTime);
            }
        }
            
        /// <summary>
        /// As long as it isnt expired, it will draw itself using its parent
        /// </summary>
        public override void Draw()
        {
            if (base.IsExpired == false)
            {
                base.Draw();
            }           
        }
    }
}