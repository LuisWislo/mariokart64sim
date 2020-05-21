using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
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
            GetItem();
        }
    }

    void GetItem()
    {
        Debug.Log("Got item: " + ItemBox.GetItem(2));
    }
}
