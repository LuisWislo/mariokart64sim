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
    private int item;
    public Transform kart;
    public UIManager ui;
    //public Canvas canvas;
    public RectTransform character;
    private Transform kartManager;
    private GameObject syncManager;
    private HMMSync syncer;
    
    private Transform[] innerWP;
    private Transform targetIWP;
    private float speed = 3f;
    private int currentIWP;

    private int availableWaypoints = 7;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    private int currentWayPoint = 0; //Sigue indices de 0 a n-1

    void Start()
    {
        //this.canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //Debug.Log(this.canvas);
        //this.ui = this.canvas.GetComponent<UIManager>();
        //Debug.Log("Got ui: " + this.character + ": " + this.ui.simpleMsg());
        //Debug.Log(this.ui);
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
        //Debug.Log("character should exist: " + this.character);
        this.ui.InitPlaces(this.character, this.place);
        this.item = 0;
        GetInfo(); //was commented
        targetIWP = innerWP[(this.currentIWP + 1) % 8];
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
            this.ui.ChangePlaces(this.character, this.place);
            this.ui.ChangeItems(this.character, this.item);
            GetInfo();
            UpdateWaypoints();
        }
    }

    void GetInfo()
    {
        this.place = this.syncer.GetPlace(this.place);
        //Debug.Log(this.character + "got " + this.place);
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