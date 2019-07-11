using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int pointPerBlockDestroyed = 5;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnable;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            //Singleton:MonoBehaviour
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //if (scoreText != null)
        //{
        //    scoreText.text = scoreText.ToString();
        //}
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
        currentScore += pointPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnable()
    {
        return isAutoPlayEnable;
    }
}
