using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class GameSystemManager : MonoBehaviour {
    public Text t;
    public Player player;
    public int point = 0;
    public int EnemyCount = 5;
    public Text restart;
    public Text win;
    public Text lose;
    public Text exit;
    public Text timerLabel; 
    private string timerText;
    private float temp;
    bool canRes;
    bool canExit;
    int count = 0;
    public GameObject cam1, cam2;
    bool ok = false;
    // Use this for initialization

    private void Awake()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);
    }

    private void Start()
    {
        count = 0;
        restart.enabled = false;
        win.enabled = false;
        lose.enabled = false;
        exit.enabled = false;
    }

    public void UpdatePoint(int p)
    {
        point += p;
        t.text = point.ToString();
    }

    public void LoadLevel()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit the game");
    }

    private void Update()
    {
        count++;
        temp += Time.deltaTime; 
        TimeSpan timeSpan = TimeSpan.FromSeconds(temp); 

        timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); 
        timerLabel.text = timerText; 
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            cam2.SetActive(false);
            cam1.SetActive(true);
        }
        if(EnemyCount == 0 && ok!=true)
        {
            Win();
        }

        if (player.isDeath())
        {
            GameOver();
        }

        if (canRes && Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(1);
        }

        if(canExit && Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }

    }

    private void Win()
    {
        UpdatePoint(point + 1000 - count);
        count = 0;
        ok = true;
        win.enabled = true;
        restart.enabled = true;
        exit.enabled = true;
        canRes = true;
        canExit = true;
    }

    private void GameOver()
    {
        lose.enabled = true;
        restart.enabled = true;
        exit.enabled = true;
        canRes = true;
        canExit = true;
        
    }

}
