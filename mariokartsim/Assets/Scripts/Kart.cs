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
    private UIManager ui;
    private Canvas canvas;
    public RectTransform character;
    private Transform kartManager;
    private GameObject syncManager;
    private HMMSync syncer;
    
    private Transform[] innerWP;
    private Transform targetIWP;
    private float speed = 2f;
    private int currentIWP;
    private int availableIWP = 8;

    private int availableWaypoints = 25;
    Transform targetWayPoint;
    private Transform[] wayPointList; //Sigue indices de 0 a n-1
    private int currentWayPoint = 1; //Sigue indices de 0 a n-1

    void Start()
    {
        this.canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        this.ui = this.canvas.GetComponent<UIManager>();
        this.kartManager = GameObject.Find("KartManager").transform;
        innerWP = new Transform[8];
        for (int wp = 0; wp < innerWP.Length; wp++)
        {
            innerWP[wp] = GameObject.Find("iwp" + wp).transform;
            innerWP[wp].GetComponent<MeshRenderer>().enabled = false;
        }

        wayPointList = new Transform[availableWaypoints];
        for (int wp = 0; wp < wayPointList.Length; wp++)
        {
            wayPointList[wp] = GameObject.Find("Waypoint" + (wp)).transform;
            //wayPointList[wp].GetComponent<MeshRenderer>().enabled = false;
        }
        targetWayPoint = wayPointList[currentWayPoint];

        this.syncManager = GameObject.Find("SyncManager");
        this.syncer = this.syncManager.GetComponent<HMMSync>();
        this.place = this.currentIWP = (int)Int64.Parse(this.name.Substring(4)) - 1;
        this.ui.InitPlaces(this.character, this.place);
        this.item = "";
        //GetInfo();
        targetIWP = innerWP[(this.currentIWP + 1) % 8];
    }
    
    void Update()
    {
        Walk();
        if (this.kartManager.position == targetWayPoint.position)
        {
            UpdateWaypoint();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "item")
        {
            //Asignar valores a GUI
            this.ui.ChangePlaces(this.character, this.place);
            print("Got place: " + places[this.place]);
            print("Got item: " + this.item);
            //GetInfo();
        }
    }

    void GetInfo()
    {
        this.place = this.syncer.GetPlace(this.place);
        this.item = ItemBox.getItem(this.place);
    }

    void Walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetIWP.position - transform.position, speed * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetIWP.position, speed * Time.deltaTime);
    }

    void UpdateWaypoint()
    {
        currentIWP = (currentIWP + 1) % (availableIWP);
        targetIWP = innerWP[currentIWP];
    }
}