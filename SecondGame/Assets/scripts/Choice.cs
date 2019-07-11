using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Choice : MonoBehaviour
{
    [SerializeField] public static int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

    }
    public int getScoreInt()
    {
        return score;
    }
    public void setScoreInt(int scoreInt)
    {
        score = scoreInt;
    }

    public void onChoiceNow()
    {
        ++score;
        Debug.Log(" score is = "+score);

        //scoreText.text = score.ToString();
    }
    public void onChoiceAfter()
    {
        --score;
        Debug.Log(" score is = " + score);

        //scoreText.text = score.ToString();
    }
    public void getScore()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
