using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBall;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D myRegidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRegidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            myRegidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (hasStarted)
        {

            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            //GetComponent<AudioSource>().Play();
            myAudioSource.PlayOneShot(clip);
            myRegidbody2D.velocity += velocity;
        }
    }
}