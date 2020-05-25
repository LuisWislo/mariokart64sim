using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    private static string[] places = new string[]
    {
        "1st", "2nd", "3rd", "4rd", "5th", "6th", "7th", "8th"
    };

    private int place;
    private string item;
    public Transform kart;
    private GameObject syncManager;
    private HMMSync syncer;

    private int currentWayPoint = 1; //Sigue indices de 0 a n-1
    private int currentLap = 1;
    private int laps = 3;
    private float speed = 10f;
    private int availableWaypoints = 25;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1

    void Start()
    {
        this.syncManager = GameObject.Find("SyncManager");
        this.syncer = this.syncManager.GetComponent<HMMSync>();
        this.place = Int32.Parse(this.name.Substring(4)) - 1;
        this.item = "";
        GetInfo();

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
            Walk();
            if (transform.position == targetWayPoint.position)
            {
                UpdateWaypoint();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "item")
        {
            //Asignar valores a GUI
            print("Got place: " + places[this.place]);
            print("Got item: " + this.item);
            GetInfo();
        }
    }

    void GetInfo()
    {
        this.place = this.syncer.GetPlace(this.place);
        this.item = ItemBox.getItem(this.place);
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
}