using System;
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// logic related enemynormal movement and draw
    /// </summary>
    public class EnemyNormal : Enemy
    {
        private float _x;
        private float _y;
        private double _oldMoveTime;//checks old move time for movement condition

        /// <summary>
        /// basically set up the logic for how homing enemy will move itself 
        /// (it will draw using parent so not placing it here)
        /// Also setting its speed and health using global values
        /// Also setting its oldmovetime to 0 to set up random move condition
        /// and passing the current game to active logic so that it can track the "player" in the active logic and find its position
        /// <param name="position">passes position (of spawning) to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public EnemyNormal(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {
            base.Speed = Global.enemyNormalSpeed;
            base.Health = Global.enemyNormalHealth;
            _oldMoveTime = 0;

        }
        /// <summary>
        /// changes x and y value to random float between -5 to 5
        /// </summary>
        public void CalcuateNewMove()
        {
            //create a random x and y values to be passed to position
            _x = new Random().Next(-5, 5);
            _y = new Random().Next(-5, 5);
        }

        /// <summary>
        /// sees if enemy hits screen (altered it to match picture + keep space for extra game text at the top during game)
        /// or not
        /// </summary>
        /// <returns> if hits screen then true, else false</returns>
        public bool EnemyHitScreen()
        {           
             if ((this.Pos.Y <= 110) || (this.Pos.Y >= 760) || (this.Pos.X <= 60) || (this.Pos.X >= 730))
             {
                return true;
             }
            else { return false; }
        }

        /// <summary>
        /// says the general enemy movement
        /// Sets condition to switch movement after certain period of time
        /// (also store the gametime now into oldmovetime to recalculate later on)
        /// Also if it hits the wall, it will bounce back in the opposite direction
        ///  made sure it also updates its parent after overriding itself incase parent has had any extra logic that it wants to impliment as well (just to be on safe side)
        /// </summary>
        /// <param name="gameTime">passes gametime to parent class</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //condition to switch enemy movement
            if (gameTime.TotalGameTime.TotalSeconds - _oldMoveTime > Global.moveTimeLimit)
            {
                _oldMoveTime = gameTime.TotalGameTime.TotalSeconds;
                CalcuateNewMove();
            }

            this.Pos += new Vector2(_x, _y) * Speed;  //enemy movement in general

            if (EnemyHitScreen())
            {
                _x = -_x;
                _y = -_y;
            }            
        }    
    }
}