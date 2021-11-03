using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    /// it inherits from drawonly and gives direction, speed, health adn loads soundplayer for things that need it
    /// can be taken as a template that will be heavily modified by its children
    /// </summary>
    public class Entity:DrawOnly
    {
        private Vector2 _direction;
        private float _speed;
        private int _health;
        private SoundPlayer _baseSoundPlayer;

        /// <summary>
        /// loads a new soundplayer that takes in current game parameter
        /// </summary>
        /// <param name="position">passes position (of spawning) to parent class</param>
        /// <param name="dimension">passes dimension (ie its size) to parent class</param>
        /// <param name="address">passes picture file location to parent class</param>
        /// <param name="game">passes game to parent class</param>
        public Entity(Vector2 position, Vector2 dimension, string address, Game game): base(position, dimension, address, game)
        {
            _baseSoundPlayer = new SoundPlayer(game);
        }

        /// <summary>
        /// property for speed
        /// </summary>
        public float Speed
        {
            get 
            { 
                return _speed; 
            }
            set
            {
                _speed = value;
            }
        }

        /// <summary>
        /// property for Health
        /// </summary>
        public int Health
        {
            get 
            { 
                return _health; 
            }
            set
            {
                _health = value;
            }
        }

        /// <summary>
        /// property for SoundPlayer
        /// </summary>
        public SoundPlayer SoundPlayer
        {
            get
            {
                return _baseSoundPlayer;
            }
            set
            {
                _baseSoundPlayer = value;
            }
        }

        /// <summary>
        /// property for direction
        /// </summary>
        public Vector2 Direction
        {
            get 
            { 
                return _direction;
            }
            set 
            { 
                _direction = value; 
            }
        }

        /// <summary>
        /// basically does nothing child classes will override it to do something
        /// </summary>
        /// <param name="gameTime">does nothing, child classes will do stuff with it</param>
        public virtual void Update(GameTime gameTime)
        {
            //made it as a template that all child can override it
        }
    }
}

