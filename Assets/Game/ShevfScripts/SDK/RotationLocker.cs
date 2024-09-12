using System.Collections;
using System.Linq;

using Cinemachine;

using UnityEngine;

namespace Game.ShevfScripts
{
    public class RotationLocker : MonoBehaviour
    {
        [field: SerializeField] private GameObject SDKCanvas { get; set; }
        [field: SerializeField] private GameObject RotationLock { get; set; }
        [field: SerializeField] private CinemachineVirtualCamera CinemachineVirtualCamera { get; set; }
        [field: SerializeField] private Orientation Orientation { get; set; }

        private readonly bool[] pauseLayers = new bool[
            System.Enum.GetValues(typeof(PauseType)).Length
        ];

        private bool Pause
        {
            get => pauseLayers.Any(x => x);
            set
            {
                AudioListener.pause = value;
                //Time.timeScale = value ? 0.001f : 1.000f;
            }
        }

        private void Start()
        {
            StartCoroutine(AsyncUpdate());
        }

        private void SetPause(bool value, PauseType pauseType = PauseType.ByRotation)
        {
            if (pauseLayers[(int)pauseType] == value) return;
            else pauseLayers[(int)pauseType] = value;

            Pause = pauseLayers.Any(x => x);
            // SDKCanvas.SetActive(false);
            //RotationLock.SetActive(false);
            CinemachineVirtualCamera.m_Lens.OrthographicSize = 12;

            if (pauseLayers[(int)PauseType.ByRotation])
            {
                // SDKCanvas.SetActive(true);
                CinemachineVirtualCamera.m_Lens.OrthographicSize = 5;
                // RotationLock.SetActive(true);
            }
            else if (pauseLayers[(int)PauseType.ByGame])
            {

            }
        }

        private IEnumerator AsyncUpdate()
        {
            while (true)
            {
                SetPause(Orientation switch
                {
                    Orientation.Everything => false,
                    Orientation.Portrait => Screen.width > Screen.height,
                    Orientation.Landscape => Screen.width < Screen.height,
                    _ => false
                }, PauseType.ByRotation);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}