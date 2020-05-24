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
    private float speed = 50f;

    private int availableWaypoints = 25;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    private int[] sShortcutAvailable = {11,12,14,15,16,17};
    private int[] mShortcutAvailable = {3,10,13};
    private Boolean canShortcut = false;
    //private int[] shortcut1 = {4};
    //private int[] shortcut2 = {11, 12, 13};
    //private int[] shortcut3 = {14, 15, 16, 17, 18};

    private Boolean throughShortcut = false;
    //private Boolean isRacing = false;

    void Start()
    {
        wayPointList = new Transform[availableWaypoints];
        for (int wp = 0; wp < wayPointList.Length; wp++)
        {
            wayPointList[wp] = GameObject.Find("Waypoint" + (wp)).transform;
        }

        /*
        for (int wp = 0; wp < wayPointList.Length; wp++)
        {
            int count = 0;
            if (GameObject.Find("Waypoints" + (wp)) != null)
            {
                for (int sc = 0; sc < wayPointList.Length; sc++)
                {
                    GameObject possibleShortcut = GameObject.Find("Waypoints" + (sc + wp));
                    if (possibleShortcut != null)
                    {
                        shortcuts[count][sc] = possibleShortcut.transform;
                    }
                    else
                    {
                        break;
                    }
            }
        }
        */

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
        if (!this.throughShortcut && this.mShortcutAvailable.Contains(currentWayPoint))
        {
            if (possibleShortcut != null && UnityEngine.Random.value < 0.5)
            {
                this.throughShortcut = true;
                targetWayPoint = possibleShortcut.transform;
            }
            else
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
        else if (this.throughShortcut && this.sShortcutAvailable.Contains(currentWayPoint))
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
