using System;
using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public class SeparateTrigger : MonoBehaviour
    {
        [SerializeField]
        private Transform _rootObject;

        public event Action<SeparateTrigger, Collider> TriggerEnter;
        public event Action<SeparateTrigger, Collider> TriggerExit;

        private List<Collider> _colliders = new List<Collider>();

        public Collider[] IntersectingСolliders => _colliders.ToArray();

        public Transform RootObject => _rootObject;

        private void OnTriggerEnter(Collider other)
        {
            if (other.enabled == false)
            {
                return;
            }
            _colliders.Add(other);
            TriggerEnter?.Invoke(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (_colliders.Remove(other))
            {
                TriggerExit?.Invoke(this, other);
            }
        }
    }
}
