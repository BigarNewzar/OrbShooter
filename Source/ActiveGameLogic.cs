using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownGame
{   
    /// <summary>
    /// Basically this is the main game part
    /// it mainly keeps track of player, mouse, keyboard, enemy, projectile positions and loads background picture and text for player health and point
    /// </summary>
    public class ActiveGameLogic
    {
        private Player _player;
        private KeyboardController _keyboardInputs;
        private EnemySpawner _enemySpawner;
        private CollisionDetector _collisionDetector;        
        private SoundPlayer _soundPlayer;
        private Game1 _game;

        private SpriteFont _font;
        private DrawOnly _gameScreen;
        private int _currentPlayerPoint;
        private int _currentPlayerHealth;

        //to move player via mouse
        private Vector2 _cursorPosition;
        private Vector2 _dPos;

        /// <summary>
        /// gets player's instance, makes new enemy spawner, soundplayer using game passed from MainMenu
        /// also makes new in collision detector 
        /// and makes new keybaord controller using player 
        /// also loads gamescreen picture 
        /// and font (using game's content's spritefont)
        /// </summary>
        /// <param name="game">used to pass to methods that need it. Also casted it as Game1 to set to _game</param>
        public ActiveGameLogic(Game game)
        {
            _player = Player.GetInstance(game);
            _enemySpawner = new EnemySpawner(game);
            _soundPlayer = new SoundPlayer(game);
            _collisionDetector = new CollisionDetector();
            _keyboardInputs = new KeyboardController(_player);

            _game = (Game1)game;
            _gameScreen = new DrawOnly(new Vector2(400, 400), new Vector2(800, 800), "pic\\activelogicscreen2", game);
            _font = game.Content.Load<SpriteFont>("pic\\Arial16");
        }

        /// <summary>
        /// if player isnt expired, then update enemyspawner, collision detector, player and keyboard
        /// store player's health and points in real time to current player health and current player point
        /// passes player to player face mouse method
        /// Also will check if button is being pressed or not and also check if its time to register shoot or not
        /// 
        /// else if player is expired, then also make gamescreen expire
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (_player.IsExpired == false)
            {
                _enemySpawner.Update(gameTime, _player);
                _collisionDetector.Detect(_player, _enemySpawner.EnemyList, _player.ProjectileManager.ProjectileList);
                _player.Update(gameTime);
                _keyboardInputs.Update();

                _currentPlayerPoint = _player.Point;
                _currentPlayerHealth = _player.Health;
                
                PlayerFaceMouse(_player);
                
                //here I decided that the game logic will check if button pressed or not and ensures that even if user keeps pressing down, player will only take the inputs after a certain delay to ensure no cheating
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    if ((gameTime.TotalGameTime.TotalSeconds - _player.LastShot) > Global.shootDelay)
                    {
                        _player.LastShot = gameTime.TotalGameTime.TotalSeconds;
                        _soundPlayer.PlaySoundEffect("playerShootSlow");
                        _player.ProjectileManager.SlowBullet(_player);
                    }
                }
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if ((gameTime.TotalGameTime.TotalSeconds - _player.LastShot) > Global.shootDelay)
                    {
                        _player.LastShot = gameTime.TotalGameTime.TotalSeconds;
                        _soundPlayer.PlaySoundEffect("playerShootNormal");
                        _player.ProjectileManager.NormalBullet(_player);
                    }
                }                
            }
            else 
            {
                _gameScreen.IsExpired = true;                
            }         
        }
        
        /// <summary>
        /// getter property for player
        /// </summary>
        public Player Player { get { return _player; } }


        /// <summary>
        /// to make player rotate with mouse
        /// It gets cursor position, finds difference in player and cursor position 
        /// and sets player's rotation (using math Atan2 to get the angle) and direction
        /// (casting as float to store them into the vector2 and as rotation is float variable but angle is returned as double)
        /// reference: https://docs.microsoft.com/en-us/dotnet/api/system.math.atan2?view=net-5.0
        /// </summary>
        /// <param name="player">to use its position and later to set its rotation and direction</param>
        public void PlayerFaceMouse(Player player)
        {
            _cursorPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            _dPos = player.Pos - _cursorPosition;
            player.Rotation = (float)Math.Atan2(_dPos.Y, _dPos.X);
            player.Direction = new Vector2((float)Math.Cos(player.Rotation), (float)Math.Sin(player.Rotation));
        }

        /// <summary>
        /// As long as gamescreen isnt expired, draw the picture and the text for point and health counter
        /// always draw player and enemyspawner (as other logic are present to remove their drawing)
        /// </summary>
        public void Draw()
        {
            if (_gameScreen.IsExpired == false)
            {
                _gameScreen.Draw(); //putting it first so that it will draw that, then it will draw the rest above it
                _game.SpriteBatch.DrawString(_font, "Point Counter:" + _currentPlayerPoint, new Vector2(110, 60), Color.Black, 0, new Vector2(0, 0), 1.5f, new SpriteEffects(), 0);
                _game.SpriteBatch.DrawString(_font, "Player Health:" + _currentPlayerHealth, new Vector2(410, 60), Color.Black, 0, new Vector2(0, 0), 1.5f, new SpriteEffects(), 0);               
            }
            _player.Draw();
            _enemySpawner.Draw();
        }
    }
}
