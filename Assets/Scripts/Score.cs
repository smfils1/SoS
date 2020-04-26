using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score { get; private set; }
    public bool isHighScore { get; private set; }


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

    void Start()
    {
        score = 0;
        isHighScore = false;
    }

    public void SaveHighScore()
    {//If score is a high score, save it
        if (score > GetHighScore()) {
            PlayerPrefs.SetInt("HighScore", score);
            isHighScore = true;
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        int time = GameManager.instance.time;
        int maxTime = GameManager.instance.maxTime;
        score = Mathf.Abs(time % (maxTime + 1) - maxTime);
    }
}
