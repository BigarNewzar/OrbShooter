
namespace TopDownGame
{
    /// <summary>
    ///Used it to make it undertand all commands as single type of object (ie of ICommand type)
    ///and ensured they all had execute method that took no parameter and returned void
    ///this helped me make the dictionary and strategy pattern for keyboard controller
    /// </summary>
    public interface ICommands
    {
        void Execute();
    }
}
