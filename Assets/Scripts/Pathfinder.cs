using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WavePath wavePath;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        wavePath = enemySpawner.GetCurrentWave();
        waypoints = wavePath.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = wavePath.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
