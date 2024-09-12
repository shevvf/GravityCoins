using System;

using UnityEngine;

namespace Game.ShevfScripts
{
    public class WebRequesterEventHandler : MonoBehaviour, IEventHandler
    {
        public Action OnSaved { get; set; }
        public Action OnLoaded { get; set; }
        public Action OnError { get; set; }
        public Action OnPlayersFetched { get; set; }

        public void Saved() => OnSaved?.Invoke();
        public void Loaded() => OnLoaded?.Invoke();
        public void Error() => OnError?.Invoke();
        public void PlayersFetched() => OnPlayersFetched?.Invoke();
    }
}