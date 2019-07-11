using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    //[SerializeField] List<Transform> wayPoints;
    List<Transform> wayPoints;
    WaveConfig waveConfig;
    //[SerializeField] float moveSpeed = 5f;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.getWavePoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWayPoints(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count -1)
        {
            var targetPos = wayPoints[wayPointIndex].transform.position;
            var speed = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
