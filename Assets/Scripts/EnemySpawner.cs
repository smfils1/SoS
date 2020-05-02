using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Vector2 StageSize;

    public float RoundStartTime;

    int spawnTableCounter = 0;
    float[] spawnTable = new float[]
    {
        //spawn_times
        2f, 4f, 6f, 8f, 10f, 12f, 14f, 16f, 18f, 20f,
    };

    // Start is called before the first frame update
    void Start()
    {
        //tmp round start time, set to current time at start of round
        RoundStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTableCounter < spawnTable.Length && (Time.time - RoundStartTime) > spawnTable[spawnTableCounter])
        {
            Instantiate(EnemyPrefab).transform.position = GetSpawnPoint();
            spawnTableCounter++;
        }
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 spawnPoint = new Vector3();
        Vector3 playerPos = Player.instance.pos;

        int quadrent = Random.Range(1, 3);
        float x = Random.Range(0f, StageSize.x / 2f);
        float y = Random.Range(0f, StageSize.y / 2f);
        float z = 4.12f;

        if (playerPos.x > 0 && playerPos.y > 0) //quadrent 1
        {
            if (quadrent == 1)
            {
                spawnPoint = new Vector3(-x, y, z);
            }
            else if (quadrent == 2)
            {
                spawnPoint = new Vector3(-x, -y, z);
            }
            else
            {
                spawnPoint = new Vector3(x, -y, z);
            }
        }
        else if (playerPos.x < 0 && playerPos.y > 0) //quadrent 2
        {
            if (quadrent == 1)
            {
                spawnPoint = new Vector3(-x, -y, z);
            }
            else if (quadrent == 2)
            {
                spawnPoint = new Vector3(x, -y, z);
            }
            else
            {
                spawnPoint = new Vector3(x, y, z);
            }
        }
        else if (playerPos.x < 0 && playerPos.y < 0) //quadrent 3
        {
            if (quadrent == 1)
            {
                spawnPoint = new Vector3(x, -y, z);
            }
            else if (quadrent == 2)
            {
                spawnPoint = new Vector3(x, y, z);
            }
            else
            {
                spawnPoint = new Vector3(-x, y, z);
            }
        }
        else //quadrent 4
        {
            if (quadrent == 1)
            {
                spawnPoint = new Vector3(x, y, z);
            }
            else if (quadrent == 2)
            {
                spawnPoint = new Vector3(-x, y, z);
            }
            else
            {
                spawnPoint = new Vector3(-x, -y, z);
            }
        }

        return spawnPoint;
    }
}
