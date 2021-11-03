using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TopDownGame
{
    /// <summary>
    /// made it as a seperate classes so that i can set all button stuff from one class
    /// (note: can be modified later to add more functonality to buttons, like a box or hover effect thing)
    /// </summary>
    public class Button: DrawOnly
    {
        private bool _buttonSelect;
        private Vector2 _cursorPosition;//inbuilt vector2 class, used to utilize x,y position of mouse

        /// <summary>
        /// uses parent class to make and draw itself
        /// Also sets button select as false from start
        /// </summary>
        /// <param name="position">passes position to parent</param>
        /// <param name="dimension">passes dimension (ie size) to parent</param>
        /// <param name="address">passes location of picture file to parent</param>
        /// <param name="game">passes game to parent</param>
        public Button(Vector2 position, Vector2 dimension, string address, Game game) : base(position, dimension, address, game)
        {
            _buttonSelect = false;
        }

        /// <summary>
        /// Property to get whether button select is true or false
        /// </summary>
        public bool ButtonSelect 
        {
            get { return _buttonSelect; }
        }
        /// <summary>
        /// if not expired, uses base to draw itself
        /// </summary>
        public override void Draw()
        {
            if (base.IsExpired == false)
            {
                base.Draw();
            }           
        }
        /// <summary>
        /// it takes in position of cursor as a vector. Then it checkes whether the position is really in the boundaries of the button and if clikced with left button or not. If so, it makes button select as true
        /// </summary>
        public void ButtonClick()
        {
            _cursorPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
           
            if (_cursorPosition.X > base.Pos.X - base.Dim.X/2 && _cursorPosition.X < base.Pos.X + base.Dim.X/2 && _cursorPosition.Y > base.Pos.Y - base.Dim.Y/2 && _cursorPosition.Y < base.Pos.Y + base.Dim.Y/2 && Mouse.GetState().LeftButton == ButtonState.Pressed)//condition used to set up button's boundary box
            {
                
                _buttonSelect = true;
            }
        }
    }
}
