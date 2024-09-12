using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace BasicModules
{
    public class LoadSceneOnClick : MonoBehaviour, IPointerClickHandler
    {
        public string SceneName;

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}