using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    private int place = 1;
    public Transform kart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "item")
        {
            GetStuff();
        }
    }

    void GetStuff()
    {
        place = ItemBox.getPlace(place);
        Debug.Log("Got item: " + place);
        Debug.Log("Got item: " + ItemBox.getItem(place));
    }
}
