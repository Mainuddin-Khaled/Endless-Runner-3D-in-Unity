using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] Transform groundPosition;
    [SerializeField] int groundInstantiateAmount = 12;
    [SerializeField] float groundLenght = 10f;
    List<GameObject> grounds = new List<GameObject>();
    [SerializeField] float groundMoveSpeed = 8f;

    void Start()
    {
        InstantiateGround();
    }

    void Update()
    {
        MoveGrounds();
    }

    void InstantiateGround()
    {
        for (int i = 0; i < groundInstantiateAmount; i++)
        {
            SpawnGround();
        }
    }

    private void SpawnGround()
    {
        float spawnPosition_z = SpawnPosition_Z();
        Vector3 groundSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPosition_z);
        GameObject newGround = Instantiate(groundPrefab, groundSpawnPosition, Quaternion.identity, groundPosition);
        grounds.Add(newGround);
    }

    float SpawnPosition_Z()
    {
        float spawnPosition_z;
        if (grounds.Count == 0)
        {
            spawnPosition_z = transform.position.z;
        }
        else
        {
            spawnPosition_z = grounds[grounds.Count - 1].transform.position.z + groundLenght;
        }

        return spawnPosition_z;
    }

    void MoveGrounds()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            GameObject ground = grounds[i];
            ground.transform.Translate(-transform.forward * (groundMoveSpeed * Time.deltaTime));

            if (ground.transform.position.z <= Camera.main.transform.position.z - groundLenght)
            {
                grounds.Remove(ground);
                Destroy(ground);
                SpawnGround();
            }
        }
    }
}
