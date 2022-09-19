using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPathfinder : MonoBehaviour
{
    AsteroidSpawner asteroidSpawner;
    WavePath wavePath;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
    }

    void Start()
    {
        wavePath = asteroidSpawner.GetCurrentWave();
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
            if (transform.position == targetPosition)
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
