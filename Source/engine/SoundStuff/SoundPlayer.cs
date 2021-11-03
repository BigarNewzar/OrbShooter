using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace TopDownGame
{
    /// <summary>
    /// Making a SoundPlayer class using strategy/placeholder pattern to make dictionaries for song and soundeffects
    /// and being able to play song, or soundeffect or stop song
    /// </summary>
    public class SoundPlayer
    {
        private Song1 _mainMenu;
        private Song1 _activeGame;
        private Song1 _currentSong;
        private SoundEffect1 _playerShootNormal;
        private SoundEffect1 _playerShootSlow;
        private SoundEffect1 _enemyKilled;
        private SoundEffect1 _playerKilled;
        private Dictionary <string,Song1> _songLibrary;
        private Dictionary<string,SoundEffect1> _soundEffectsLibrary;

        /// <summary>
        /// making dictionaries for song and soundeffects, making individual song and sound effects and adding them to thier respective dictionaries using string to call them
        /// </summary>
        /// <param name="game">passes game to song adn sound effect classes to make themselves</param>
        public SoundPlayer(Game game)
        {
            _songLibrary = new Dictionary<string, Song1>();            
            _songLibrary.Add("mainMenu",_mainMenu = new Song1("audio\\MainMenuSuspenseMusic", game));
            _songLibrary.Add("activeGame",_activeGame = new Song1("audio\\LostInSoundDropBeat", game));

            //.wav file must be loaded as a SoundEffect, .mp3 file must be loaded as a Song
            _soundEffectsLibrary = new Dictionary<string, SoundEffect1>();        
            _soundEffectsLibrary.Add("playerShootNormal", _playerShootNormal = new SoundEffect1("audio\\LaserPew", game));
            _soundEffectsLibrary.Add("playerShootSlow", _playerShootSlow = new SoundEffect1("audio\\ProjectileSlow", game));
            _soundEffectsLibrary.Add("enemyKilled", _enemyKilled = new SoundEffect1("audio\\EnemyKilled", game));
            _soundEffectsLibrary.Add("playerKilled", _playerKilled = new SoundEffect1("audio\\PlayerKilled", game));        
        }

        /// <summary>
        /// looks though dictionary to find the song and play it
        /// </summary>
        /// <param name="smth">uses this string to compare with other stings in dictionary to find the song</param>
        public void PlaySong(string smth)
        {
              if (_songLibrary.ContainsKey(smth))
                {
                _currentSong = null;
                _currentSong = _songLibrary[smth];
                   
                _currentSong.Play();                   
              }            
        }

        /// <summary>
        /// looks though dictionary to find the soundeffect and play it
        /// </summary>
        /// <param name="smth">uses this string to compare with other stings in dictionary to find the soundeffect</param>
        public void PlaySoundEffect(string smth)
        {
            if (_soundEffectsLibrary.ContainsKey(smth))
            {
                _soundEffectsLibrary[smth].Play();                
            }
        }

        /// <summary>
        /// stops song being played
        /// </summary>
        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
