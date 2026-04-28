using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] int initialGroundCount = 12;
    [SerializeField] Transform groundContainer;
    [SerializeField] float groundLength = 10f;
    List<GameObject> grounds = new List<GameObject>();
    [SerializeField] float moveSpeed = 8f;

    void Start()
    {
        SpawnGround();
    }

    void Update()
    {
        MoveGround();
    }

    void SpawnGround()
    {
        for (int i = 0; i < initialGroundCount; i++)
        {
            float spawnPosition = GroundSpawnPosition(i);
            Vector3 groundSpawnPosition = new Vector3(0, 0, spawnPosition);
            GameObject newGround = Instantiate(groundPrefab, groundSpawnPosition, Quaternion.identity, groundContainer);
            grounds[i] = newGround;
        }
    }

    float GroundSpawnPosition(int i)
    {
        float spawnPosition;
        if (i == 0)
        {
            spawnPosition = transform.position.z;
        }
        else
        {
            spawnPosition = transform.position.z + (i * groundLength);
        }

        return spawnPosition;
    }

    void MoveGround()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
        }
    }
}
