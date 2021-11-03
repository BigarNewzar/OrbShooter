
namespace TopDownGame
{
    /// <summary>
    /// Example of composition, using ICommands mainly to add it to dictionary in keyboardController
    /// </summary>
    public class UpCommand : ICommands
    {   
        private Player _player;

        /// <summary>
        /// basically allocated player to _player
        /// </summary>
        /// <param name="player">to use the player passed from keyboard controller</param>
        public UpCommand(Player player)
        {
            this._player = player;
        }

        /// <summary>
        /// setting condition to restrict when it can go up and if condition fulfilled, then tell player to call its GoUp method
        /// </summary>
        public void Execute()
        {
            if (_player.Pos.Y >110)
            {
                _player.GoUp();
            }
        }
    }
}
