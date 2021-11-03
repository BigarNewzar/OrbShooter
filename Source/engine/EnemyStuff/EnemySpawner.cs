using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// utilizing concept from factory pattern to make spawner class that randomly decides on what to spawn
    /// It also decided when to remove the enemy as well! 
    /// (the "add to different list and then remove from original list" idea was obtained from fruit slasher program that was shown in lecture in the early weeks)
    /// </summary>
    public class EnemySpawner
    {
        private EnemyNormal _enemyNormal;
        private EnemyHoming _enemyHoming;
        private List<Enemy> _enemyList;
        private List<Enemy> _removeEnemy;
        private Game _game;
        private double _oldSpawnTime;//checks old spawn time to determine to spawn new one or not

        /// <summary>
        /// creates list (enemy list) to add enemies to, and another list(remove enemy) to constantly remove every enemy stored in it
        /// also set starting spawn time as zero
        /// also allocated game to _game to to ensure i can make the enemy instances in this class
        /// </summary>
        /// <param name="game">passed from active logic to wherever it will be needed here using _game variable</param>
        public EnemySpawner(Game game) 
        {
            _enemyList = new List<Enemy>();
            _oldSpawnTime = 0;
            _removeEnemy = new List<Enemy> ();
            _game = game;
        }
        /// <summary>
        /// getter property in case any classes need to get it
        /// </summary>
        public List<Enemy> EnemyList
        {
            get { return _enemyList; }
        }

        /// <summary>
        /// Spawns a normal enemy not at the same player position and adds it to list of enemies
        /// (note it just ensures its not spawning directly on player, but it might still spawn within player touch distance and thus, if player in unlucky, he might lose a life without knowing it (unless he hears the enemy death sound))
        /// can be refactored to remove player, but then will make the update "if" heavy
        /// will probably use a dictionary instead for this next time
        /// </summary>
        /// <param name="x"> x position used to spawn enemy</param>
        /// <param name="y"> y position used to spawn enemy</param>
        /// <param name="player">passed in player from update</param>
        public void SpawnEnemyNormal(int x, int y, Player player)
        {
            if (x != player.Pos.X && y != player.Pos.Y)
            {
                _enemyNormal = new EnemyNormal(new Vector2(x, y), new Vector2(Global.enemyHeight, Global.enemyWidth), "pic\\EnemyTest",_game);

                _enemyList.Add(_enemyNormal);
            }
        }

        /// <summary>
        /// Spawns a normal enemy not at the same player position and adds it to list of enemies
        /// (note it just ensures its not spawning directly on player, but it might still spawn within player touch distance and thus, if player in unlucky, he might lose a life without knowing it (unless he hears the enemy death sound))
        /// can be refactored to remove player, but then will make the update "if" heavy
        /// will probably use a dictionary instead for this next time
        /// </summary>
        /// <param name="x"> x position used to spawn enemy</param>
        /// <param name="y"> y position used to spawn enemy</param>
        /// <param name="player">passed in player from update</param>
        public void SpawnEnemyHoming(int x, int y,Player player)
        {
            if (x != player.Pos.X && y != player.Pos.Y)
            {
                _enemyHoming = new EnemyHoming(new Vector2(x, y), new Vector2(Global.enemyHeight, Global.enemyWidth), "pic\\EnemyHoming", _game);

                _enemyList.Add(_enemyHoming);
            }
        }

        /// <summary>
        /// spawns certain enemy at certain times randomly
        /// also says how to remove the enemy from enemyist and add to removeEnemy and then remove all enemyes in removeEnemy and also added 1 point to player as enemy got destroyed
        /// </summary>
        /// <param name="gameTime"> passes in gametime from avtice logic</param>
        /// <param name="player">passes in player from active logic</param>
        public void Update(GameTime gameTime, Player player) 
        {
            if (gameTime.TotalGameTime.TotalSeconds - _oldSpawnTime > Global.spawnTimeLimit)
            {
                _oldSpawnTime = gameTime.TotalGameTime.TotalSeconds;
                //use random to make it so that 50 percent time spawn normal, 50 percent time spawn homing enemy

                if (new Random().Next(0, 10) < 5)
                {
                    SpawnEnemyNormal(new Random().Next(120, 700), new Random().Next(120, 700), player);
                }
                else
                {
                    SpawnEnemyHoming(new Random().Next(120, 700), new Random().Next(120, 700), player);
                }
            }

            foreach (Enemy e in _enemyList)
            {
                e.Update(gameTime); 

                if (e.IsExpired)
                {
                    _removeEnemy.Add(e);
                    player.Point += 1;  //gives player 1 poit no matter what enemy he kills as i already made proper balancing to both enemies to even them out!
                }

            }

            foreach (Enemy e in _removeEnemy)
            {
                _enemyList.Remove(e);
            }            
        }

        /// <summary>
        /// draws all enemies present in enemylist
        /// </summary>
        public void Draw()
        {
            foreach (Enemy e in _enemyList)
            {
                e.Draw();
            }
        }
    }
}
