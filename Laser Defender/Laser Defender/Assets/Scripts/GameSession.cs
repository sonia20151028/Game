using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    public int GetScore()
    {
        return currentScore;
    }

    public void AddToScore(int scoreValue)
    {
        currentScore += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int sessionCount = FindObjectsOfType<GameSession>().Length;
        if (sessionCount >1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
