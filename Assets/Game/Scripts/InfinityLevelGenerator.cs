using UnityEngine;
using UnityEngine.U2D;

public class InfinityLevelGenerator : MonoBehaviour
{
    [SerializeField]
    private SpriteShapeController shapeController;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject claimTrigger;
    [SerializeField]
    private float edgeWidth;
    [SerializeField]
    private float maxShapeHeight;
    [SerializeField]
    private float distanceBetweenShapes;

    private TerrainEdgeInfo edgeInfo;

    private void Start()
    {
        edgeInfo = new TerrainEdgeInfo(shapeController, coin, claimTrigger, maxShapeHeight, edgeWidth, distanceBetweenShapes);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = TerrainGenerator.GenerateTerrainEdge(edgeInfo);
    }
}
