
using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// logic related enemyhoming movement and draw
    /// </summary>
    public class EnemyHoming : Enemy
    {     
        private ActiveGameLogic _active;//the active logic will tell the homing enemy of the player's position and thus help it "home" to the player

        /// <summary>
        /// basically set up the logic for how homing enemy will move itself 
        /// (it will draw using parent so not placing it here)
        /// Also setting its speed and health using global values
        /// and passing the current game to active logic so that it can track the "player" in the active logic and find its position
        /// <param name="position">passes position (of spawning) to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public EnemyHoming(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {
            base.Speed = Global.enemyHomingSpeed;
            base.Health = Global.enemyHomingHealth;

            _active = new ActiveGameLogic(game);
        }

        /// <summary>
        /// made a funny homing movement + made sure it also updates its parent after overriding itself incase parent has had any extra logic that it wants to impliment as well (just to be on safe side)
        /// </summary>
        /// <param name="gameTime">passes gametime to parent class</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Pos += (_active.Player.Pos - this.Pos) * Speed;//finds difference in position vector2 and multiplies with speed. Thus if far away, enemy runs towards player, if close, enemy moves slowly to player. This ensures player has a decent chance to kill the homing one as it has high health
        }

    }
}