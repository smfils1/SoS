using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    public string controls { get; private set; }
    public int time { get; private set; }
    public int level { get; private set; }
    public int maxTime = 30;
    public float xSensitivity { get; private set; }
    public float ySensitivity { get; private set; }
    public Text xSensitivityUI;
    public Text ySensitivityUI;
    //public GameObject Game_Over;


    void Awake()
    {//Singleton Pattern
        controls = PlayerPrefs.HasKey("controls") ? getControls() : "keyboard";
        xSensitivity = PlayerPrefs.HasKey("xSensitivity") ? getXSensitivity() : 1.0f;
        ySensitivity = PlayerPrefs.HasKey("ySensitivity") ? getYSensitivity() : 1.0f;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;            
        }
        if (SceneManager.GetActiveScene().name == "Settings")
        {

            xSensitivityUI.text = $"xSensitivity: {xSensitivity.ToString()}";
            ySensitivityUI.text = $"ySensitivity: {ySensitivity.ToString()}";
        }

    }



    // Start is called before the first frame update
    void Start()
    {//Initialize the Game
       // Game_Over = GameObject.Find("GameOver");
        //Game_Over.SetActive(false);
        isGameOver = false;
        time = maxTime;
        level = 1;
        StartCoroutine("Clock");


    }


    IEnumerator Clock()
    {
        if (SceneManager.GetActiveScene().name == "Game")

        {
            while (true)
        {
            yield return new WaitForSeconds(1);
            
                if (time % maxTime == 0 && time != 30)
                {
                    time = maxTime;
                    level += 1;
                    EnemySpawner.instance.FillSpawnTable();
                }
                else
                {
                    time -= 1;
                }

            }
 
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    
    public void ExitGame()
    {//Close the application        
        Application.Quit();
    }

    
    public void Settings()
    {//Loads Settings
        SceneManager.LoadScene("Settings");
    }

    public void About()
    {//Load About Info.
        SceneManager.LoadScene("About");
    }

    public void StartMenu()
    {//Load main menu
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main");
    }

    public void useGameControls(string gameControls)
    {//
        controls = gameControls;
        PlayerPrefs.SetString("controls", gameControls);
        
    }

    public string getControls()
    {//
        return PlayerPrefs.GetString("controls");
        
    }

    public float getXSensitivity()
    {//
        return PlayerPrefs.GetFloat("xSensitivity");

    }

    public float getYSensitivity()
    {//
        return PlayerPrefs.GetFloat("ySensitivity");

    }

    public void updateXSensitivity(float value)
    {
        xSensitivity = (float)System.Math.Round(value, 2);
        PlayerPrefs.SetFloat("xSensitivity", xSensitivity);
        xSensitivityUI.text = $"xSensitivity: {xSensitivity.ToString()}";
    }


    public void updateYSensitivity(float value)
    {
        ySensitivity = (float)System.Math.Round(value, 2);
        PlayerPrefs.SetFloat("ySensitivity", ySensitivity);
        ySensitivityUI.text = $"ySensitivity: {ySensitivity.ToString()}";
    }

    //Game Over Menu
    public void EndGame()
    {
        isGameOver = true;
        if(isGameOver == true)
        {
            isGameOver = false;
            Debug.Log("GAME OVER");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
        }

    }

    //Restart Function
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {//Listen for request for close app and main menu. 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartMenu();
        }
        if (GameManager.instance.isGameOver)

        {//Stop spawning where game over

            StopCoroutine("Clock");
        }

    }
}
