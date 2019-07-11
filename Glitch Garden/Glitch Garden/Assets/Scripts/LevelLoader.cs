using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delaySeconds = 3f;
    int currentScreenIndex;

    public void Start()
    {
        currentScreenIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentScreenIndex == 0)
        {
            LoadStartMenu();
        }
    }

    public void LoadStartMenu()
    {
        StartCoroutine(loadDelay());
    }

    private IEnumerator loadDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScreenIndex + 1);
    }
}
