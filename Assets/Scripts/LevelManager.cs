﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
        
    public void LoadLevel(string name)
    {
        if (name == "Level_01")
        {
            Score.score = 0;
            Lives.lives = 3;
        }

        /// reset brick count so leftover bricks from last game are not included
        Brick.breakableCount = 0;

        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        /// reset brick count so leftover bricks from last game are not included
        Brick.breakableCount = 0;

        /// buildindex is from build settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // End level if last brick destroyed
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0) 
        {
            LoadNextLevel();
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }
}
