using Microsoft.Xna.Framework;

namespace TopDownGame
{
    /// <summary>
    ///  makes all objects present in Menu screen and also its song
    ///  note: can be improved by using gamestate design pattern
    /// </summary>
    public class MainMenu
    {
        private Game _game;
        private Button _start;
        private Button _quit;
        private DrawOnly _gameMenuScreen;
        private SoundPlayer _soundPlayer;
        private ActiveGameLogic _newGameLogic;
        private EndScreen _endScreen;
        private bool _gameTrigger;

        /// <summary>
        /// sets game to _game so that it can be passed to things that need it
        /// makes new soundplayer using the game to call mainmenu song
        /// then loads menu screen picture, start and quit buttons and sets game trigger to be false
        /// </summary>
        /// <param name="game"></param>
        public MainMenu(Game game) 
        {
            _game = game;
            _soundPlayer = new SoundPlayer(game);
            _soundPlayer.PlaySong("mainMenu");

            _gameMenuScreen = new DrawOnly(new Vector2(400, 400), new Vector2(700, 700), "pic\\MenuScreen1", game);
            _start = new Button(new Vector2(150, 500), new Vector2(150, 150), "pic\\start2", game);
            _quit = new Button(new Vector2(150, 600), new Vector2(150, 150), "pic\\quit2", game);

            _gameTrigger = false;
        }

        /// <summary>
        /// chckes if start and quit button has been clicked or not, constantly
        /// If the game trigger is false, then see if start or quit has been pressed
        /// if start, make activelogic and play its song, and if quit then exit game
        /// if active logic is loaded, then update it, and make everything else expired and set game trigger as true
        /// if player dies in activelogic, then stop music and load endscreen
        /// if end screen is loaded, then update it
        /// note: 
        /// keeping buttons outside as when they have been expired, no matter how much players selects the same position, nothing will happen, so not really needed to keep them inside if statements (as it has already been done to make their expired = true)
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            _start.ButtonClick();
            _quit.ButtonClick();

            if (_newGameLogic != null)
            {
                _newGameLogic.Update(gametime);
                _start.IsExpired = true;
                _quit.IsExpired = true;
                _gameMenuScreen.IsExpired = true;
                _gameTrigger = true;


                if (_newGameLogic.Player != null && _newGameLogic.Player.IsExpired)
                {
                    _soundPlayer.StopMusic();
                    _endScreen = new EndScreen(_game, _newGameLogic.Player);                   
                }
            }

            if (_endScreen != null)
            {
                _endScreen.Update();
            }    
         
            if (_gameTrigger == false)
            {
                if (_start.ButtonSelect == true)
                {
                    _newGameLogic = new ActiveGameLogic(_game);
                    _soundPlayer.PlaySong("activeGame");

                }
                if (_quit.ButtonSelect == true)
                {
                    _game.Exit();
                }
            }   
        }
        /// <summary>
        /// if game screen or activelogic or defeatscreen is not expired then draw them respectively,
        /// keeping buttons outside as they will only be drawn if not expired 
        /// </summary>
        public void Draw()
        {
            if (_gameMenuScreen.IsExpired == false)
            { 
                _gameMenuScreen.Draw();
            }
            _start.Draw();
            _quit.Draw();

            if (_newGameLogic != null)
            {
                _newGameLogic.Draw();
            }
            if (_endScreen != null)
            {
                _endScreen.Draw();
            }
        }
    }
}
