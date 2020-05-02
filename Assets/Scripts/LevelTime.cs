using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelTime : MonoBehaviour
{
    private GameObject scoreUI;
    private Text[] levelTime;
    private void Start()
    {
        scoreUI = gameObject;
        levelTime = GetComponentsInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {//Update game score or highscore
 
            levelTime[0].text = $"Level { GameManager.instance.level.ToString()}";
            levelTime[1].text = $"Time: { GameManager.instance.time.ToString()}";
            Debug.Log(string.Format("Level: {0}, Time: {1}", GameManager.instance.level.ToString(), GameManager.instance.time.ToString()));

    }
}

public class ScoreUI : MonoBehaviour
{
    






}
