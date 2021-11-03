
namespace TopDownGame
{   /// <summary>
    /// Example of composition, using ICommands mainly to add it to dictionary in keyboardController
    /// basically does nothing other than exiting game
    /// </summary>
    public class QuitCommand : ICommands
    {
        
        public QuitCommand()
        {
        }
        /// <summary>
        /// exits game by calling game1's getinstance and exit 
        /// </summary>
        public void Execute()
        {
            Game1.GetInstance().Exit();
        }
    }
}
