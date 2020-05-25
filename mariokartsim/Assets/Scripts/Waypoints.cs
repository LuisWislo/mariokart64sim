using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour
{
    private int currentWayPoint = 1; //Sigue indices de 0 a n-1
    private int currentLap = 1;
    private int laps = 3;
    private float speed = 2f;
    private int availableWaypoints = 25;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    public Text lapText;

    void Start()
    {
        wayPointList = new Transform[availableWaypoints];
        for (int wp = 0; wp < wayPointList.Length; wp++)
        {
            wayPointList[wp] = GameObject.Find("Waypoint" + (wp)).transform;
            //wayPointList[wp].GetComponent<MeshRenderer>().enabled = false;
        }
        targetWayPoint = wayPointList[currentWayPoint];
    }

    // Update is called once per frame
    void Update()
    {
        setLap();
        if (currentLap <= laps)
        {
            Walk();
            if (transform.position == targetWayPoint.position)
            {
                UpdateWaypoint();
            }
        }
    }

    void Walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
    }

    void UpdateWaypoint()
    {
        if (currentWayPoint == 0)
        {
            currentLap++;
        }

        currentWayPoint = (currentWayPoint + 1) % (availableWaypoints);
        targetWayPoint = wayPointList[currentWayPoint];
    }

    private void setLap()
    {
        if(this.currentLap <= 3)
            this.lapText.text = "Laps: " + this.currentLap + "/3";
    }
}
