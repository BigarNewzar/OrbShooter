using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownGame
{
    /// <summary>
    /// makes all objects present in end screen and also uses the point value allocated to the player
    /// note:
    /// currently keeping it silent as only single end screen instead of victory and defeat screen
    /// Also silence seemed to make the player's death soundeffect standout more
    /// </summary>
    public class EndScreen
    {
        private Game1 _game;
        private Button _quit;
        private SpriteFont _font;//inbuilt class to set a font that will be used to draw the string
        private Player _player;
        private DrawOnly _gameScreen;

        /// <summary>
        /// Takes in game, casts it as Game1 to use its spritebatch later on
        /// Store player as _player to call its point value
        /// draw an image saying gameover, a button for quit and selects font to say the player's point line
        /// </summary>
        /// <param name="game"></param>
        /// <param name="player"></param>
        public EndScreen(Game game, Player player) 
        {
            _game = (Game1)game;

            _player = player;
            
            _gameScreen = new DrawOnly(new Vector2(400, 400), new Vector2(800, 800), "pic\\Gameover", game);
            _quit = new Button(new Vector2(200, 650), new Vector2(100, 100), "pic\\quit2", game);
            _font = game.Content.Load<SpriteFont>("pic\\Arial16");


        }

        /// <summary>
        /// continuously checked if button has been clicked or not
        /// and if it has then exits game
        /// </summary>
        public void Update()
        {
            _quit.ButtonClick();//checks the button click condition and determines whether buttonselect should change

            if (_quit.ButtonSelect == true)
            {
                _game.Exit();
            }
            
        }

        /// <summary>
        /// draws the game screen picture first
        /// then it draws the line to say no of points player got in the preselected font
        /// then sets its position, colour, origin, spriteeffect and layer depth
        /// mainly used this overload to maximize the font so kept o for origin and depth and just made a new sprite effect to ensure the string can be drawn without having any effect whatsoever
        /// </summary>
        public void Draw()
        {            
            _gameScreen.Draw();
            _game.SpriteBatch.DrawString(_font, "You have obtained: " + _player.Point +" points!", new Vector2(150, 500), Color.White, 0, new Vector2(0,0), 2, new SpriteEffects(), 0);//made origin 0,0 just for ease of use and thus only need to change position
            _quit.Draw();
        }
    }
}
