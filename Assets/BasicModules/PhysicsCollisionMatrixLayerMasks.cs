using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollisionMatrixLayerMasks : MonoBehaviour
{
    private static Dictionary<int, int> _masksByLayer;

    public static void Init()
    {
        _masksByLayer = new Dictionary<int, int>();
        for (int i = 0; i < 32; i++)
        {
            int mask = 0;
            for (int j = 0; j < 32; j++)
            {
                if (!Physics.GetIgnoreLayerCollision(i, j))
                {
                    mask |= 1 << j;
                }
            }
            _masksByLayer.Add(i, mask);
        }
    }

    public static int GetMaskForLayer(int layer)
    {
        return _masksByLayer[layer];
    }
}
