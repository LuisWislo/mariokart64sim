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
    private Transform kartManager;
    private GameObject syncManager;
    private HMMSync syncer;
    
    private Transform[] innerWP;
    private Transform targetIWP;
    private float speed = 3f;
    private int currentIWP;
    private int availableIWP = 8;

    private int availableWaypoints = 7;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    private int currentWayPoint = 0; //Sigue indices de 0 a n-1

    void Start()
    {
        this.kartManager = GameObject.Find("KartManager").transform;
        innerWP = new Transform[8];
        for (int wp = 0; wp < innerWP.Length; wp++)
        {
            innerWP[wp] = GameObject.Find("iwp" + wp).transform;
            innerWP[wp].GetComponent<MeshRenderer>().enabled = false;
        }

        wayPointList = new Transform[availableWaypoints];
        wayPointList[0] = GameObject.Find("Waypoint3").transform;
        wayPointList[1] = GameObject.Find("Waypoint9").transform;
        wayPointList[2] = GameObject.Find("Waypoint11").transform;
        wayPointList[3] = GameObject.Find("Waypoint16").transform;
        wayPointList[4] = GameObject.Find("Waypoint20").transform;
        wayPointList[5] = GameObject.Find("Waypoint21").transform;
        wayPointList[6] = GameObject.Find("Waypoint24").transform;
      
        targetWayPoint = wayPointList[currentWayPoint];

        this.syncManager = GameObject.Find("SyncManager");
        this.syncer = this.syncManager.GetComponent<HMMSync>();
        this.place = this.currentIWP = (int)Int64.Parse(this.name.Substring(4)) - 1;
        this.item = "";
        GetInfo();
        targetIWP = innerWP[this.place];
    }
    
    void Update()
    {
        Walk();
        //if (this.kartManager.position == targetWayPoint.position)
        //{
            
        //}
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "item")
        {
            //Asignar valores a GUI
            print(this.name + " got place: " + places[this.place]);
            print(this.name + " got item: " + this.item);
            GetInfo();
            UpdateWaypoints();
        }
    }

    void GetInfo()
    {
        this.place = this.syncer.GetPlace(this.place);
        this.item = ItemBox.getItem(this.place);
    }

    void Walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetIWP.position - transform.position, (speed * Time.deltaTime) / Vector3.Distance(this.kartManager.position, targetWayPoint.position), 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetIWP.position, (speed * Time.deltaTime)/Vector3.Distance(this.kartManager.position, targetWayPoint.position));
    }

    void UpdateWaypoints()
    {
        currentIWP = this.place;
        targetIWP = innerWP[currentIWP];
        currentWayPoint = (currentWayPoint + 1) % (availableWaypoints);
        targetWayPoint = wayPointList[currentWayPoint];
    }
}