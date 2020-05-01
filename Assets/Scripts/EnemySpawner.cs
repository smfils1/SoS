using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float roundStartTime;

    int spawnTableCounter = 0;
    float[,] spawnTable = new float[,]
    {
        //spawn_time, x_pos, y_pos, z_pos
        { 2f, 0f, 0f, 4.12f },
        { 4f, 0f, 0f, 4.12f },
        { 6f, 0f, 0f, 4.12f },
        { 8f, 0f, 0f, 4.12f },
        { 10f, 0f, 0f, 4.12f },
        { 12f, 0f, 0f, 4.12f },
    };

    // Start is called before the first frame update
    void Start()
    {
        //tmp round start time, set to current time at start of round
        roundStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTableCounter < spawnTable.GetLength(0) && (Time.time - roundStartTime) > spawnTable[spawnTableCounter, 0])
        {
            Vector3 spawnPoint = new Vector3(
                spawnTable[spawnTableCounter, 1],
                spawnTable[spawnTableCounter, 2],
                spawnTable[spawnTableCounter, 3]
            );
            Instantiate(enemyPrefab).transform.position = spawnPoint;
            spawnTableCounter++;
        }
    }
}
