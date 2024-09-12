using System;
using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public class GameCursor : MonoBehaviour
    {
        private static GameCursor instance;

        [Header("Mouse Cursor Settings")]
        [SerializeField]
        private bool cursorLockedDefault = true;
        [SerializeField]
        private bool cursorInputForLookDefault = true;

        private HashSet<GameObject> cursorUsers = new HashSet<GameObject>();
        private bool isCursorLocked;
        private bool isCursorInputForLook;

        public static bool IsCursorInputForLook => instance.isCursorInputForLook;

        public void Init()
        {
            instance = this;
            isCursorLocked = cursorLockedDefault;
            isCursorInputForLook = cursorInputForLookDefault;
        }

        public void Update()
        {
            List<GameObject> excludedObjects = new List<GameObject>(10);
            foreach (var user in cursorUsers)
            {
                if (user == null || user.activeInHierarchy == false)
                {
                    excludedObjects.Add(user);
                }
            }
            cursorUsers.ExceptWith(excludedObjects);

            UpdateCursor();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            ChangeCursorState();
        }

        private void ChangeCursorState()
        {
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public static void AddCursorUser(GameObject user)
        {
            instance.cursorUsers.Add(user);
            instance.UpdateCursor();
        }

        public static void RemoveCursorUser(GameObject user)
        {
            instance.cursorUsers.Remove(user);
            instance.UpdateCursor();
        }

        private void UpdateCursor()
        {
            if (cursorUsers.Count == 0)
            {
                isCursorLocked = cursorLockedDefault;
                isCursorInputForLook = cursorInputForLookDefault;
            }
            else
            {
                isCursorLocked = !cursorLockedDefault;
                isCursorInputForLook = !cursorInputForLookDefault;
            }
            ChangeCursorState();
        }
    }
}
