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
    // Start is called before the first frame update
    void Start()
    {
        this.place = Int32.Parse(this.name.Substring(4));
        this.item = "";
        GetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //this.place = ItemBox.getPlace(this.place);
        //this.item = ItemBox.getItem(this.place);
    }
}