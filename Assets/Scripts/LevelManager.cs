using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
        
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        /// buildindex is from build settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0) // if last brick destroyed
        {
            LoadNextLevel();
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }
}
