using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MadLevelManager;

public class GameManager : MonoBehaviour {

    private static GameManager manager = null;

    public static GameManager Manager
    {
        get { return manager; }
    }

    void Awake()
    {
        GetThisGameManager();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetThisGameManager()
    {
        if (manager != null && manager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            manager = this;
            print("GM loaded");
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelectPerception()
    {
        MadLevel.LoadLevelByName("02a_Level_Select_Perception");
    }

    public void LevelSelectSpeed()
    {
        MadLevel.LoadLevelByName("02b_Level_Select_Speed");
    }

    public void LevelSelectMemory()
    {
        MadLevel.LoadLevelByName("02c_Level_Select_Memory");
    }
}
