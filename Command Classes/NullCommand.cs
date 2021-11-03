
namespace TopDownGame
{   /// <summary>
    /// Example of composition, using ICommands mainly to add it to dictionary in keyboardController
    /// Basically, here i am using it as placeholder for strategy pattern
    /// it isnt going to do anything at all
    /// </summary>
    public class NullCommand : ICommands
    {
        public NullCommand()
        {
        }
        public void Execute()
        {
        }
    }
}
