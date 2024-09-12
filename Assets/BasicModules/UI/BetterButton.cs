using UnityEngine;
using UnityEngine.UI;

namespace BasicModules
{
    public class BetterButton : Button
    {
        public bool IsButtonPressed => IsPressed();
    }
}
