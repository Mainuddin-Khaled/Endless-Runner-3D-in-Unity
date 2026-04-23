using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDistance = 30f;
    public float spawnInterval = 2f;
    public float laneDistance = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);

        float xPosition = 0;

        if (lane == 0)
            xPosition = -laneDistance;
        else if (lane == 2)
            xPosition = laneDistance;

        float zPosition = player.position.z + spawnDistance;

        Vector3 spawnPosition = new Vector3(xPosition, 1f, zPosition);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}