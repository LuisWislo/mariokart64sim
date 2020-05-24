using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Waypoints : MonoBehaviour
{
    private int currentWayPoint = 1; //Sigue indices de 0 a n-1
    private int currentLap = 1;
    private int laps = 3;
    private float speed = 10f;

    private int availableWaypoints = 29;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1

    void Start()
    {
        wayPointList = new Transform[availableWaypoints];
        for (int wp = 0; wp < wayPointList.Length; wp++)
        {
            wayPointList[wp] = GameObject.Find("Waypoint" + (wp)).transform;
        }
        targetWayPoint = wayPointList[currentWayPoint];
    }

    void Update()
    {
        if (currentLap <= laps)
        {
            walk();
            if (transform.position == targetWayPoint.position)
            {
                updateWaypoint();
            }
        }
    }

    void walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
    }

    void updateWaypoint()
    {
        if (currentWayPoint == 0)
        {
            currentLap++;
        }

        currentWayPoint = (currentWayPoint + 1) % (availableWaypoints);
        targetWayPoint = wayPointList[currentWayPoint];
    }
}
