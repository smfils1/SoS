using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameInfoUI : MonoBehaviour
{
    private Text[] levelTime;
    private void Start()
    {
        levelTime = GetComponentsInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {//Update game score or highscore

        foreach (Text UI in levelTime)
        {
            if (UI.tag == "LevelUI")
            {
                UI.text = $"Level { GameManager.instance.level.ToString()}";
            }
            if (UI.tag == "TimerUI")
            {
                UI.text = $"Time: { GameManager.instance.time.ToString()}";
            }
            if (UI.tag == "PlayerHealthUI")
            {
                UI.text = $"Health: { Player.instance.health }";
            }

        }
    }
}

