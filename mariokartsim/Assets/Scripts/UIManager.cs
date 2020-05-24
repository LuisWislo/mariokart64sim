using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] currentPlaces;
    private float[][] targetPositions;

    void Start()
    {
        /*this.currentPlaces = null;
        this.targetPositions = new float[][]
        {

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void receivePlaces(GameObject[] places)
    {
        this.currentPlaces = places;
    }

    private void changePlaces()
    {

    }


}
