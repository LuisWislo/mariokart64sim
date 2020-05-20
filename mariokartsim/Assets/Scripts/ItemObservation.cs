using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObservation : MonoBehaviour
{
    // Start is called before the first frame update
    private float[][] itemProbabilities;
    private int noItems;

    private string[] itemNames;

    void Start()
    {
        this.itemProbabilities = new float[][] {
            new float[] {0.30f, 0.05f, 0.30f, 0.05f, 0.05f, 0.00f, 0.00f, 0.00f, 0.10f, 0.00f, 0.05f, 0.10f, 0.00f, 0.00f}, //1st
            new float[] {0.00f, 0.05f, 0.05f, 0.10f, 0.15f, 0.20f, 0.00f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.15f, 0.05f}, //2nd
            new float[] {0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.20f, 0.00f, 0.05f, 0.00f, 0.10f, 0.00f, 0.05f, 0.20f, 0.10f}, //3rd
            new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.15f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.25f, 0.10f}, //4th
            new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.25f, 0.10f}, //5th
            new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.15f, 0.00f, 0.20f, 0.00f, 0.00f, 0.25f, 0.10f}, //6th
            new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.10f, 0.10f}, //7th
            new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.15f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.05f, 0.10f}  //8th
        };

        this.noItems = this.itemProbabilities[0].Length;
        this.itemNames = new string[] {
            "Banana", 
            "Banana Bunch", 
            "Green Shell", 
            "Triple Green Shell", 
            "Red Shell", 
            "Triple Red Shell",
            "Spiny Shell",
            "Thunder Bolt",
            "Fake Item Box",
            "Super Star",
            "Boo",
            "Mushroom",
            "Triple Mushrooms",
            "Super Mushroom"
        };


    }

    // Update is called once per frame
    void Update()
    {
        GetItem(3);
    }

    void GetItem(int place)
    {
        float random = Random.Range(0.0f, 1.0f);
        float rng = (float)System.Math.Round(random * 100f)/100f;

        float portion = 0;

        for(int i=0; i<noItems; i++)
        {
            portion += this.itemProbabilities[place][i];
            if(rng <= portion)
            {
                Debug.Log(this.itemNames[i] + " " + rng);
                break;
            }
        }

    }

}
