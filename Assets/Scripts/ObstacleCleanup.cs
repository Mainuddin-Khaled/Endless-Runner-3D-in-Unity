using UnityEngine;

public class ObstacleCleanup : MonoBehaviour
{
    private Transform player;
    public float destroyDistance = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        if (player.position.z - transform.position.z > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}