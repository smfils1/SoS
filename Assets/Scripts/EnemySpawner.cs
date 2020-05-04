using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public GameObject EnemyPrefab;
    public Vector2 StageSize;

    private float RoundStartTime;
    private int spawnTableCounter;
    private float[] spawnTable;
    private List<GameObject> spawnedEnemies;

    void Awake()
    {//Singleton Pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //tmp round start time, set to current time at start of round
        spawnedEnemies = new List<GameObject>();
        FillSpawnTable();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTableCounter < spawnTable.Length && (Time.time - RoundStartTime) > spawnTable[spawnTableCounter])
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = GetSpawnPoint();
            spawnedEnemies.Add(enemy);
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

    public void FillSpawnTable()
    {
        // kill all enemies on the stage at end of round
        foreach (GameObject enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
        spawnedEnemies.Clear();

        // update spawn table
        int level = GameManager.instance.level;
        int enemiesToSpawn = 9 + level;
        float spawnRate = 20f / ((float)enemiesToSpawn);
        spawnTable = new float[enemiesToSpawn];

        float spawnTime = 2f;
        for (int i = 0; i < spawnTable.Length; i++)
        {
            spawnTable[i] = spawnTime;
            spawnTime += spawnRate;
        }

        // reset variables
        RoundStartTime = Time.time;
        spawnTableCounter = 0;
        spawnedEnemies = new List<GameObject>();
    }
}
