using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float screenMin = 0f;
    [SerializeField] float screenMax = 16f;
    GameStatus myGameStatus;
    Ball myBoll;
    // Start is called before the first frame update
    void Start()
    {
        myGameStatus = FindObjectOfType<GameStatus>();
        myBoll = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getPosX(), screenMin, screenMax);
        transform.position = paddlePos;
        
    }

    private float getPosX()
    {
        if(myGameStatus.IsAutoPlayEnable())
        {
            return myBoll.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnit; ;
        }
    }
}
