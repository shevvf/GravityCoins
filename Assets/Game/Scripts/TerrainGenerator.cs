using UnityEngine;
using UnityEngine.U2D;

/// <summary> Info used by TerrainGenerator</summary>
public class TerrainEdgeInfo
{
    public TerrainEdgeInfo(SpriteShapeController terrain, GameObject coin, GameObject claimTrigger, float maxShapeHeight, float edgeWidth, float distanceBeetwenShapes)
    {
        Terrain = terrain;
        Coin = coin;
        ClaimTrigger = claimTrigger;
        MaxShapeHeight = maxShapeHeight;
        DistanceBeetwenShapes = distanceBeetwenShapes;
        EdgeWidth = edgeWidth;
    }

    public SpriteShapeController Terrain;
    public GameObject Coin;
    public GameObject ClaimTrigger;
    public float MaxShapeHeight;
    public float EdgeWidth;
    public float DistanceBeetwenShapes;
};

public static class TerrainGenerator
{

    /// <summary> Extend SpriteShape and add shapes to it
    /// <para>Return edge corner position</para> </summary>
    public static Vector3 GenerateTerrainEdge(TerrainEdgeInfo edgeInfo)
    {
        if (edgeInfo.Terrain == null)
        {
            Debug.LogError("Got null terrain");
            return Vector3.zero;
        }

        Vector3 startPos = edgeInfo.Terrain.spline.GetPosition(edgeInfo.Terrain.spline.GetPointCount() - 2);

        MakeTerrainLonger(edgeInfo);

        GenerateShapes(edgeInfo, startPos);

        return edgeInfo.Terrain.spline.GetPosition(edgeInfo.Terrain.spline.GetPointCount() - 3);
    }

    private static void MakeTerrainLonger(TerrainEdgeInfo edgeInfo)
    {
        int cornerIndex = edgeInfo.Terrain.spline.GetPointCount() - 2;
        Vector3 topBorderPos = edgeInfo.Terrain.spline.GetPosition(cornerIndex);

        topBorderPos.x += edgeInfo.EdgeWidth;

        edgeInfo.Terrain.spline.SetPosition(cornerIndex, topBorderPos);

        Vector3 bottomBorderPos = edgeInfo.Terrain.spline.GetPosition(cornerIndex + 1);
        bottomBorderPos.x += edgeInfo.EdgeWidth;

        edgeInfo.Terrain.spline.SetPosition(cornerIndex + 1, bottomBorderPos);

    }

    private static void GenerateShapes(TerrainEdgeInfo edgeInfo, Vector3 startPos)
    {
        int currentIndex = edgeInfo.Terrain.spline.GetPointCount() - 2;

        float currentXPos = startPos.x;
        float lastYPos = startPos.y;
        int coinCounter = 0;

        while (currentXPos < startPos.x + edgeInfo.EdgeWidth)
        {
            currentXPos += edgeInfo.DistanceBeetwenShapes;

            if (currentXPos > startPos.x + edgeInfo.EdgeWidth)
                currentXPos = startPos.x + edgeInfo.EdgeWidth;

            Vector3 newPoint = new(currentXPos, startPos.y + Random.Range(edgeInfo.MaxShapeHeight * .1f, edgeInfo.MaxShapeHeight));
            Vector3 coinNewPoint = new(newPoint.x, newPoint.y + Random.Range(1f, 2f), newPoint.z);
            Vector3 triggerNewPoint = new(newPoint.x + 1f, newPoint.y, newPoint.z);

            if (currentIndex % 4 == 0)
            {
                Object.Instantiate(edgeInfo.Coin, coinNewPoint, edgeInfo.Coin.transform.rotation);
                coinCounter++;
                if (coinCounter >= 3)
                {
                    Object.Instantiate(edgeInfo.ClaimTrigger, triggerNewPoint, edgeInfo.ClaimTrigger.transform.rotation);
                    coinCounter = 0;
                }
            }

            edgeInfo.Terrain.spline.InsertPointAt(currentIndex, newPoint);

            currentIndex++;
        }
    }
}
