﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public int nbLevels = 1;
    private int currLevelID;

    void Awake()
    {
        if (Instance == null) { 
            Instance = this; 
        } else { 
            Debug.Log("Warning: multiple " + this + " in scene!"); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GoToMenu();
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void GoToSettings()
    {
        UI.Instance.ShowSettingsScreen();
    }

    public void CloseSettings()
    {
        UI.Instance.HideSettingsScreen();
    }

    public void PauseGame()
    {
        UI.Instance.ShowPauseScreen();
        //todo stop time
    }

    public void UnpauseGame()
    {
        UI.Instance.HidePauseScreen();
        //todo stop time
    }

    // show the level win card  (w ui to go to menu, go to next level...)
    // called when the player has reached the end of a level
    public void FinishLevel()
    {
        // todo
        UI.Instance.ShowLevelVictoryScreen();
    }

    // load the current level (ie the first level at the first launch)
    public void LaunchCurrentLevel()
    {
        LaunchLevel(currLevelID);
    }

    // called when level win card nextLevel btn has been pressed    
    public void GoToNextLevel()
    {
        currLevelID++;
        if (currLevelID >= nbLevels)
        {
            UI.Instance.HideAll();
            LoadScene("VictoryScene");
        } else
        {
            LaunchLevel(currLevelID);
        }
    }

    // go back to the main menu
    public void GoToMenu()
    {
        LoadScene("Menu");
        UI.Instance.HideAll();
    }


    void LoadScene(string sceneName)
    {
        Debug.Log("loading " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    void LaunchLevel (int id)
    {
        UI.Instance.LaunchLevel();
        LoadScene("Level_" + id);
    }
}
