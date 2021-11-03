using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// Using inheritance/ template design where the projectile is giving basic idea of what all proejctile can do and know 
    /// but letting subclasses override it to decide what they should actually do
    /// (projectile class will determine all cases on whether an projectile is expired or not)
    /// </summary>
    public class Projectile : Entity
    {
        private int _damage;

        /// <summary>
        /// makes instance of itself using its parent
        /// </summary>
        /// <param name="position">passes position to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public Projectile(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {
        }

        /// <summary>
        /// if it hit enemy, then it will call this method which will make its epired value true
        /// </summary>
        public void HitEnemy()
        {
            base.IsExpired = true;
        }

        /// <summary>
        /// Property to get adn set damage values
        /// </summary>
        public int Damage { get {return _damage; } set { _damage = value; } }

        /// <summary>
        /// makes it remove projectile when hitting wall of picture
        /// otherwise makes it move in the direction of shot
        /// as long as not expired, it will use its parent class to update itself
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (base.Pos.X < 55 || base.Pos.X > 740 || base.Pos.Y < 65 || base.Pos.Y > 770)//added and remvoed 10 to increase projectile shoot distance so that even if player is at wall, he can still shoot properly
            {
                base.IsExpired = true;
            }

            if (base.IsExpired == false)
            {
                base.Update(gameTime);
                this.Pos -= base.Speed * this.Direction;
            }
        }

        /// <summary>
        ///  As long as it isnt expired, it will draw itself using its parent
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