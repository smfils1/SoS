using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKillable
{
    public static Player instance;
    public Vector3 pos;
    public float health = 100f;

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

    public void decreaseHealth(int damage)
    {
        health -= damage;
    }

    public bool isDead()
    {
        return health <= 0;
    }


    void Update()
    {
        pos = transform.position;
    }

}
