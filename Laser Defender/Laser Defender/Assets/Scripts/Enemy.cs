using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    [SerializeField] int health = 100;
    [SerializeField] int scoreVlaue = 50;

    [Header("Shooting Status")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject projectile;

    [Header("Sound Effects")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float dorationExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.8f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    //[SerializeField] int enemyDestroyed = 20;
    //[SerializeField] int currentScore = 0;
    //[SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        countDownAndShoot();
    }
    private void countDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <=0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void Fire()
    {
        GameObject enemyLaser = Instantiate(projectile, transform.position,Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.getDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreVlaue);
        Destroy(gameObject);
        GameObject particleEffect = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(particleEffect, dorationExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
