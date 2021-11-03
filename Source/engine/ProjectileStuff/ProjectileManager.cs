using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// utilizing concept from factory pattern to make manager class for projectile that decides on what to spawn and where
    /// It also decided when to remove the projectile as well! 
    /// (the "add to different list and then remove from original list" idea was obtained from fruit slasher program that was shown in lecture in the early weeks)
    /// </summary>
    public class ProjectileManager
    {
        private Game _game;
        private ProjectileSlow _projectileSlow;
        private ProjectileNormal _projectileNormal;        
        private List<Projectile> _projectileList;
        private List<Projectile> _removeProjectile;

        /// <summary>
        /// creates list (projectile list) to add enemies to, and another list(remove projectile) to constantly remove every projectile stored in it
        /// also allocated game to _game to to ensure i can make the projectile instances in this class
        /// </summary>
        /// <param name="game">passed from active logic to wherever it will be needed here using _game variable</param>
        public ProjectileManager(Game game)
        {
            _projectileList = new List<Projectile>();
            _removeProjectile = new List<Projectile>();
            _game = game;
        }

        /// <summary>
        /// getter property for projectilelist
        /// </summary>
        public List<Projectile> ProjectileList 
        {
            get { return _projectileList; }
        }

        /// <summary>
        /// makes a normal projectile, makes its direction same as player and stores it in projectile list
        /// </summary>
        /// <param name="player"> to set initial position and direction of player to the projectile</param>
        public void NormalBullet(Player player)
        {
            _projectileNormal = new ProjectileNormal(player.Pos, new Vector2(Global.projectileHeight, Global.projectileWidth), "pic\\orb1", _game);
            _projectileNormal.Direction = player.Direction;
            //kept both as this as i am looking for player pos and direction

            _projectileList.Add(_projectileNormal);// adding the projectile to the list of  projectiles
        }

        /// <summary>
        /// makes a slow projectile, makes its direction same as player and stores it in projectile list
        /// </summary>
        /// <param name="player"> to set initial position and direction of player to the projectile</param>
        public void SlowBullet(Player player)
        {
            _projectileSlow = new ProjectileSlow(player.Pos, new Vector2(Global.projectileHeight, Global.projectileWidth), "pic\\OrbSlow", _game);
            _projectileSlow.Direction = player.Direction;
            //kept both as this as i am looking for player pos and direction

            _projectileList.Add(_projectileSlow);// adding the projectile to the list of projectiles        
        }

        /// <summary>
        /// if projectile is expired, then remove it from this list ad add it to remvoe projectile list and remove everything present in removeProjectile list
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
             foreach (Projectile p in _projectileList)
             {
                p.Update(gameTime);
                if (p.IsExpired) 
                { 
                    _removeProjectile.Add(p); 
                }

             }
             foreach (Projectile p in _removeProjectile)
             {
                    _projectileList.Remove(p);
             }            
        }

        /// <summary>
        /// draws all projectiles present in projectile list
        /// </summary>
        public void Draw()
        {            
            foreach (Projectile p in _projectileList)
            {
                p.Draw(); 
            }
        }
    }
}
