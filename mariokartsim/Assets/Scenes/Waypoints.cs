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
    private float speed = 20f;

    private int availableWaypoints = 25;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    private int[] initShorcut = {3,10,13}; //Waypoints con acceso a shortcuts
    private int[] endShortcut = {4,13,18}; //Waypoints terminales de shortcuts

    private Boolean throughShortcut = false;
    //private Boolean isRacing = false;

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

        GameObject possibleShortcut = GameObject.Find("Waypoints" + (currentWayPoint));
        if (!this.throughShortcut)
        {
            if (initShorcut.Contains(currentWayPoint-1) && possibleShortcut != null && UnityEngine.Random.value < 0.5)
            {
                this.throughShortcut = true;
                targetWayPoint = possibleShortcut.transform;
            }
            else
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
        else
        {
            if (possibleShortcut != null)
            {
                targetWayPoint = possibleShortcut.transform;
            }
            else
            {
                this.throughShortcut = false;
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }
}
