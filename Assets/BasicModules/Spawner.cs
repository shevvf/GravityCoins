using System.Collections;
using UnityEngine;

namespace BasicModules
{
    public class Spawner : MonoBehaviour
    {
        public GameObject Prefab;
        public float RespawnTime = 5;

        private IDestroy currentObject;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var obj = Instantiate(Prefab, transform.position, Quaternion.identity);
            currentObject = obj.GetComponent<IDestroy>();
            currentObject.Destroyed += CurrentObject_Destroyed;
        }

        private void CurrentObject_Destroyed()
        {
            currentObject.Destroyed -= CurrentObject_Destroyed;
            currentObject = null;
            StartCoroutine(SpawnIn(RespawnTime));
        }

        private IEnumerator SpawnIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Spawn();
        }
    }
}
