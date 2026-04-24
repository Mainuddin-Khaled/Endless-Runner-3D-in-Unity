using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform player;
    public Transform[] groundTiles;

    public float tileLength = 10f;

    void Update()
    {
        RecycleTiles();
    }

    void RecycleTiles()
    {
        foreach (Transform tile in groundTiles)
        {
            if (player.position.z - tile.position.z > tileLength)
            {
                MoveTileToFront(tile);
            }
        }
    }

    void MoveTileToFront(Transform tile)
    {
        float farthestZ = GetFarthestTileZ();

        tile.position = new Vector3(
            tile.position.x,
            tile.position.y,
            farthestZ + tileLength
        );
    }

    float GetFarthestTileZ()
    {
        float maxZ = groundTiles[0].position.z;

        foreach (Transform tile in groundTiles)
        {
            if (tile.position.z > maxZ)
            {
                maxZ = tile.position.z;
            }
        }

        return maxZ;
    }
}