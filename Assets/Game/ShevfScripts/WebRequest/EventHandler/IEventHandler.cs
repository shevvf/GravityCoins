using System;

namespace Game.ShevfScripts
{
    public interface IEventHandler
    {
        Action OnSaved { get; set; }
        Action OnLoaded { get; set; }
        Action OnPlayersFetched { get; set; }
        Action OnError { get; set; }

        void Saved();
        void Loaded();
        void PlayersFetched();
        void Error();
    }
}