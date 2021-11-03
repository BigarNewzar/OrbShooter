using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;


namespace TopDownGame
{
    /// <summary>
    ///making a strategy pattern to hotbind keys to commands
    /// </summary>
    public class KeyboardController 
    {   
        private KeyboardState _keyboardState;//inbuilt class to call the keys
        private Player _player;
        private ICommands _currentCommand;
        private Dictionary<Keys, ICommands> _commandLibrary;

        /// <summary>
        /// making a dictionary binding keys to their respective commands using the strategy pattern
        /// </summary>
        /// <param name="player">Passing player received from ActiveGameLogic to the commands</param>
        public KeyboardController(Player player)
        {
            this._player = player;
            _commandLibrary = new Dictionary<Keys, ICommands>();
            _commandLibrary.Add(Keys.W, _currentCommand = new UpCommand(_player));
            _commandLibrary.Add(Keys.Up, _currentCommand = new UpCommand(_player));
            _commandLibrary.Add(Keys.S, _currentCommand = new DownCommand(_player));
            _commandLibrary.Add(Keys.Down, _currentCommand = new DownCommand(_player));
            _commandLibrary.Add(Keys.A, _currentCommand = new LeftCommand(_player));
            _commandLibrary.Add(Keys.Left, _currentCommand = new LeftCommand(_player));
            _commandLibrary.Add(Keys.D, _currentCommand = new RightCommand(_player));
            _commandLibrary.Add(Keys.Right, _currentCommand = new RightCommand(_player));
            _commandLibrary.Add(Keys.Q, _currentCommand = new QuitCommand());
        }

        /// <summary>
        /// updating the command received
        /// setting it first as null then taking keyboard state and looking through dictionary to find and execute the command
        /// </summary>
        public void Update()
        {
            _currentCommand = new NullCommand(); 
            _keyboardState = Keyboard.GetState();
            foreach (Keys key in _keyboardState.GetPressedKeys())
            {
                if (_commandLibrary.ContainsKey(key))
                {
                    _currentCommand = _commandLibrary[key];
                    _currentCommand.Execute();
                }
            }
        }
    }
}
