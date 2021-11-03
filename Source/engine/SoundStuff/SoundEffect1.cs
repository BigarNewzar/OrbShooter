using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace TopDownGame
{
    /// <summary>
    /// Loads up song using its file's address and then plays it after determining volume and making repeat true
    /// used IAudio here to ensure it has play method 
    /// (note planned on using IAudio to make it into a dictionary first, but then decided to keep them seperate as i prefer keeping song and soundeffect seperate)
    /// </summary>
    public class SoundEffect1: IAudio
    {
        private SoundEffect _soundEffect;//inbuilt Soundeffect variable to store soundeffects

        /// <summary>
        /// loads the soundeffect from content file directory of game
        /// </summary>
        /// <param name="address">uses file location to make itself</param>
        /// <param name="game">uses game to call its content</param>
        public SoundEffect1(string address, Game game)
        {
            _soundEffect = game.Content.Load<SoundEffect>(address);
        }

        /// <summary>
        /// Plays the sound effect using inbuilt SoundEffect class' play method
        /// </summary>
        public void Play()
        {
            _soundEffect.Play();
        }
    }
}
