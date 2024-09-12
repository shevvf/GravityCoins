using BasicModules;

using UnityEngine;

namespace Game
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        public BetterButton gas;
        public BetterButton stop;
        public BetterButton left;
        public BetterButton right;
        public BetterButton menu;

        public float horizontalAxis;
        public float verticalAxis;

        public static InputManager Instance => _instance;

        private void Awake()
        {
            _instance = this;
            menu.onClick.AddListener(OnMenuClick);
        }

        public void Update()
        {
            verticalAxis = Input.GetAxisRaw("Vertical");
            if (verticalAxis == 0)
            {
                verticalAxis += gas.IsButtonPressed ? 1f : 0f;
                verticalAxis += stop.IsButtonPressed ? -1f : 0f;
            }

            horizontalAxis = Input.GetAxis("Horizontal");
            if (horizontalAxis == 0)
            {
                horizontalAxis += right.IsButtonPressed ? 1f : 0f;
                horizontalAxis += left.IsButtonPressed ? -1f : 0f;
            }
        }

        private void OnMenuClick()
        {
            UIMainManager.instance.OpenMenu();
        }
    }
}