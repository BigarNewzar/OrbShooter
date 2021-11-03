using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownGame
{
    /// <summary>
    /// it will draw the object by using its position, dimension as a texture using game
    /// it will also let it determine if its expired or not and whether it should rotate or not and by how much
    /// </summary>
    public class DrawOnly
    {
        private Vector2 _pos;
        private Vector2 _dim;
        private Texture2D _texture;
        private float _rotation;
        private bool _isExpired;
        private Game1 _game;

        /// <summary>
        /// makes itself using its parameters and sets its expired as false from start
        /// </summary>
        /// <param name="position">passes it to _pos</param>
        /// <param name="dimension">passes it to _dim</param>
        /// <param name="address"> uses it to find where the file is in the content folder</param>
        /// <param name="game"> uses it to call its concent directory to load the file as texture2d. Also casting it as Game1 to call the spritebatch made inside Game1</param>
        public DrawOnly(Vector2 position, Vector2 dimension, string address, Game game)
        {
            _pos = position;
            _dim = dimension;
            _texture = game.Content.Load<Texture2D>(address);
            //to load the img of player from the file
            _isExpired = false;
            _game = (Game1)game;           
        }
        /// <summary>
        /// property for rotation for the object
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }

            set
            {
                _rotation = value;
            }
        }

        /// <summary>
        /// property for whether object has expired
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return _isExpired;
            }

            set
            {
                _isExpired = value;
            }
        }

        /// <summary>
        /// property for position of object
        /// </summary>
        public Vector2 Pos
        {
            get { return _pos; }

            set
            {
                _pos = value;
            }
        }

        /// <summary>
        /// property for dimension of object
        /// </summary>
        public Vector2 Dim
        {
            get { return _dim; }

            set
            {
                _dim = value;
            }
        }

        /// <summary>
        /// if texture is present, then draw it using the method given
        /// </summary>
        public virtual void Draw()
        {            
            if (_texture != null)
            {
                //takes in file, draws it as a rect with same position (casting its x and y position and dimensions as int)
                //and size as obj, no source rectangle,
                //and color white (no make sure no extra colour shade will apply to the drawings),
                //and rotation as rotation (so that other objects can set it)
                //sets origin as its width and height devided by 2 to draw from middle
                //currently set the layer depth as 0
               
                _game.SpriteBatch.Draw(_texture, new Rectangle((int)_pos.X, (int)_pos.Y, (int)_dim.X, (int)_dim.Y), null, Color.White, _rotation, new Vector2(_texture.Bounds.Width / 2, _texture.Bounds.Height / 2), new SpriteEffects(), 0);
            }

        }

    }
}
