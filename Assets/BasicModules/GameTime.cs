using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public class GameTime
    {
        private static bool _pause;
        private static float _timeScale = 1;

        private static HashSet<GameObject> pauseUsers = new HashSet<GameObject>();

        public static bool Pause => _pause;
        public static float TimeScale { get => _timeScale; set => SetTimeScalse(value); }

        public static void AddPauseUser(GameObject user)
        {
            pauseUsers.Add(user);
            UpdatePauseState();
        }

        public static void RemovePauseUser(GameObject user)
        {
            pauseUsers.Remove(user);
            UpdatePauseState();
        }

        private static void UpdatePauseState()
        {
            if (pauseUsers.Count == 0)
            {
                _pause = false;
                Time.timeScale = _timeScale;
                //AudioListener.pause = false;
            }
            else
            {
                _pause = true;
                Time.timeScale = 0;
                //AudioListener.pause = true;
            }
        }

        private static void SetTimeScalse(float timeScale)
        {
            _timeScale = timeScale;
            if (!_pause)
            {
                Time.timeScale = _timeScale;
            }
        }
    }
}
