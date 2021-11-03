
namespace TopDownGame
{
    /// <summary>
    /// At first i did it to use to make a dictionary for both sing and soundeffect
    /// But it felt wrong to include both long music and short sound together
    /// 
    /// So for now, i just kept it to ensure that both soundeffect and song will have the play method that returns nothing
    /// just to make sure i dont forget to add "play" method to those classes while i am multitasking
    /// </summary>
    public interface IAudio
    {
        void Play();
    }
}
