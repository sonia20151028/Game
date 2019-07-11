using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSounds;
    [SerializeField] GameObject sparkleVFX;
    Level level;
    //GameStatus gameStatus;
    [SerializeField] int hitCounts;
    //[SerializeField] int maxHitCounts;
    [SerializeField] Sprite[] hitSprites;

    void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        //gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //gameStatus.addToScore();
        if(tag == "Breakable")
        {
            hitCounts++;
            int maxHitCounts = hitSprites.Length + 1;
            if (hitCounts >= maxHitCounts)
            {
                DestroyBlock();
            }
            else
            {
                showNextHitSpite();
            }
        }

    }

    private void showNextHitSpite()
    {
        int spiteIndex = hitCounts - 1;
        if (hitSprites[spiteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spiteIndex];
        }
        else
        {
            Debug.LogError("There are somethin wrong in"+gameObject.name);
        }

    }

    private void DestroyBlock()
    {
        PlayAudio();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkleVFX();

        //if (tag == "Breakable")
        //{

        //    Destroy(gameObject);
        //    level.BlockDestroyed();
        //    TriggerSparkleVFX();
        //}
    }

    private void PlayAudio()
    {
        FindObjectOfType<GameStatus>().addToScore();
        AudioSource.PlayClipAtPoint(breakSounds, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(sparkleVFX,transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }
}
