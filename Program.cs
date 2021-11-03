using System;

namespace TopDownGame
{
    public static class Program
    {
        [STAThread]
        /// <summary>
        /// Will call game that has been set up as singleton class and run it
        /// </summary>
        static void Main()
        {                         
            Game1 game = Game1.GetInstance();            
            game.Run();            
        }
    }
}
