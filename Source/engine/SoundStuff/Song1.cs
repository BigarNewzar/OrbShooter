using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace TopDownGame
{
    /// <summary>
    /// Loads up song using its file's address and then plays it after determining volume and making repeat true
    /// used IAudio here to ensure it has play method 
    /// (note planned on using IAudio to make it into a dictionary first, but then decided to keep them seperate as i prefer keeping song and soundeffect seperate)
    /// </summary>
    public class Song1 : IAudio
    {
        private Song _song;//inbuilt Song variable to store songs

        /// <summary>
        /// loads the song from content file directory of game
        /// </summary>
        /// <param name="address">uses file location to make itself</param>
        /// <param name="game">uses game to call its content</param>
        public Song1(string address, Game game) 
        {            
            _song = game.Content.Load<Song>(address);
        }

        /// <summary>
        /// sets volume as low value and then plays the song and sets it on repeat
        /// </summary>
        public void Play() 
        {
            MediaPlayer.Volume = 0.25f;//setting the volume to 25 percent for all the music incase too loud
            MediaPlayer.Play(_song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
