using System;
using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public interface IDestroy
    {
        public event Action Destroyed;
    }
}
