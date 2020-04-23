using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IKillable
{
    private int maxHealth = 100;
    private int health;
    private Text healthUI;
    private void Awake()
    {
        health = maxHealth;
        healthUI = GetComponentInChildren<Text>();
    }

    public bool isDead()
    {
        return health <= 0;
    }

    public void decreaseHealth(int damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            Destroy(gameObject);
        } else
        {
            healthUI.text = $"{health}";
        }
    }

}
