using System;
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// Made it as a singleton classs as only one player will exist in a game
    /// </summary>
    public class Player : Entity
    {
        private int _collideDamage;
        private static Player _playerInstance;//must keep static here as singleton class
        private double _lastShot;
        private ProjectileManager _projectileManager;
        private int _point;

        /// <summary>
        /// sets its speed, health, collision damage and last shot time
        /// Also sets its direction using its rotation and cos and sin functions (casting them as float)
        /// and instantiates projectile manager (as player is shooting stuff)
        /// and loads a new soundplayer using game
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimension"></param>
        /// <param name="address"></param>
        /// <param name="game"></param>
        public Player(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {
            base.Speed = Global.playerSpeed;            
            base.Health = Global.playerHealth;
            _collideDamage = Global.playerCollideDamage;        //collision will kill all enemy it collides with, but at price of health (see in EnemyPlayerCollisionResponder for details)

            _lastShot = 0.0f;

            this.Direction = new Vector2((float)Math.Cos(this.Rotation), (float)Math.Sin(this.Rotation));

            _projectileManager = new ProjectileManager(game);
            base.SoundPlayer = new SoundPlayer(game);
        }

        /// <summary>
        /// property for lastshot
        /// </summary>
        public double LastShot 
        { 
            get { return _lastShot; } 
            set { _lastShot = value; } 
        }

        /// <summary>
        /// property for collideDamage
        /// </summary>
        public int CollideDamage
        {
            get { return _collideDamage; }
            set { _collideDamage = value; }
        }

        /// <summary>
        /// getter property for projectile manager
        /// </summary>
        public ProjectileManager ProjectileManager 
        {
            get { return _projectileManager; }
        }

        /// <summary>
        /// property for point
        /// </summary>
        public int Point 
        {
            get { return _point; }
            set { _point = value; }
        }

        /// <summary>
        /// when player hits enemy, call this function
        /// it will reduce players health by 1
        /// if player's health is zero of less, play player killed soundeffect and make it expired = true
        /// </summary>
        public void HitEnemy()
        {
            base.Health -= 1;
            if (base.Health <= 0)
            {
                base.SoundPlayer.PlaySoundEffect("playerKilled");
                base.IsExpired = true;
            }
        }

        /// <summary>
        /// makes player go right using its speed
        /// </summary>
        public void GoRight()
        {               
            base.Pos = new Vector2(base.Pos.X + base.Speed, base.Pos.Y);
        }

        /// <summary>
        /// makes player go left using its speed
        /// </summary>
        public void GoLeft()
        {
            base.Pos = new Vector2(base.Pos.X - base.Speed, base.Pos.Y);            
        }

        /// <summary>
        /// makes player go down using its speed
        /// </summary>
        public void GoDown()
        {
            base.Pos = new Vector2(base.Pos.X, base.Pos.Y + base.Speed);
        }

        /// <summary>
        /// makes player go up using its speed
        /// </summary>
        public void GoUp()
        {
            base.Pos = new Vector2(base.Pos.X, base.Pos.Y - base.Speed);
        }

        /// <summary>
        /// as long as player is not expired, update itself using its base and also update its projectileManager
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            if (base.IsExpired == false)
            {
                _projectileManager.Update(gameTime);                
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// aslong as player isnt expired, draw it and its projectile manager
        /// </summary>
        public override void Draw()
        {
            if (base.IsExpired == false)
            {
                _projectileManager.Draw();
                base.Draw();
            }
        }

        /// <summary>
        /// used to make the singleton class
        /// </summary>
        /// <returns>instance of Player</returns>
        public static Player GetInstance(Game game)
        {
            if (_playerInstance == null)
            {
                _playerInstance = new Player(new Vector2(300, 300), new Vector2(Global.playerHeight, Global.playerWidth), "pic\\playerBetter",game);//must give it .xnb file!();
            }
            return _playerInstance;
        }
    }
}