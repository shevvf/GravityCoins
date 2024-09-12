using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BasicModules
{
    public class InGameConsole : MonoBehaviour
    {
        //private static InGameConsole instance;
        //private static Queue<string> messages = new Queue<string>();

        //private RectTransform field;

        //[SerializeField] private GameObject messagePrefab;
        //public int MaxMessages = 10;

        //private Queue<GameObject> messageObjects = new Queue<GameObject>();


        //private static void CreateInstance()
        //{
        //    var prefab = Resources.Load<GameObject>("DebugCanvas");
        //    var obj = Instantiate(prefab);
        //    instance = obj.GetComponent<InGameConsole>();
        //    DontDestroyOnLoad(obj);

        //    instance.field = (RectTransform)instance.transform.Find("Console");
        //}

        //public static void Log(string inputText)
        //{
        //    if (Application.isPlaying == false)
        //        return;

        //    messages.Enqueue(inputText);
        //    if (messages.Count > )
        //    {
                
        //    }

        //    var note = Instantiate(instance.messagePrefab, instance.field);
        //    instance.messageObjects.Enqueue(note);
        //    if (instance.messageObjects.Count > instance.MaxMessages)
        //    {
        //        var obj = instance.messageObjects.Dequeue();
        //        Destroy(obj);
        //    }

        //    var tmpText = note.GetComponentInChildren<TextMeshProUGUI>();
        //    tmpText.text = inputText;
        //}
    }
}