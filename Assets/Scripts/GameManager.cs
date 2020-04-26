using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    public string controls { get; private set; }
    public float time { get; private set; }
    public int maxTime = 30;



    void Awake()
    {//Singleton Pattern
        controls = PlayerPrefs.HasKey("controls") ? getControls() : "keyboard";
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
    {//Initialize the Game
        isGameOver = false;
        time = 0;
        StartCoroutine("Clock");


    }


    IEnumerator Clock()
    {
        while (true)
        {
            Debug.Log(time);

            yield return new WaitForSeconds(1);
            time += 1;
        }
    }

    public void StartGame()
    {//Initialize default game state & Load game. Resume time if needed
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
