using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //int screenNum = 1;
    //string nowScreen = "Now";
    //string afterScreen = "After";

    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if (currentSceneIndex == 0)
        //{
        //    c.setScoreInt(0);
        //}

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    //public void loadLastScene()
    //{
    //    if (c.getScoreInt() >= 1)
    //    {
    //        SceneManager.LoadScene(5);
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(6);
    //    }

    //}

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().Destroy();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
