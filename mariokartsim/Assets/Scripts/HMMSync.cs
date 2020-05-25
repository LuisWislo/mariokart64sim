using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HMMSync : MonoBehaviour
{
    private int usedPlaces = 0;
    private static float[][] placeProbabilities = new float[][]
    {
        //           1st    2nd    3rd    4th    5th    6th    7th    8th
        new float[] {0.42f, 0.37f, 0.09f, 0.08f, 0.05f, 0.04f, 0.03f, 0.02f}, //1st
        new float[] {0.27f, 0.38f, 0.15f, 0.05f, 0.05f, 0.05f, 0.03f, 0.02f}, //2nd
        new float[] {0.13f, 0.33f, 0.23f, 0.13f, 0.08f, 0.05f, 0.03f, 0.02f}, //3rd
        new float[] {0.10f, 0.19f, 0.29f, 0.10f, 0.15f, 0.10f, 0.05f, 0.02f}, //4th
        new float[] {0.05f, 0.10f, 0.14f, 0.23f, 0.09f, 0.19f, 0.10f, 0.10f}, //5th
        new float[] {0.02f, 0.05f, 0.14f, 0.25f, 0.24f, 0.05f, 0.15f, 0.10f}, //6th
        new float[] {0.02f, 0.05f, 0.19f, 0.39f, 0.15f, 0.10f, 0.05f, 0.05f}, //7th
        new float[] {0.01f, 0.02f, 0.05f, 0.32f, 0.33f, 0.15f, 0.05f, 0.05f}  //8th
    };

    private float[][] syncedPlaces = new float[][]
    {
        //           1st    2nd    3rd    4th    5th    6th    7th    8th
        new float[] {0.45f, 0.30f, 0.10f, 0.10f, 0.05f, 0.00f, 0.00f, 0.00f}, //1st
        new float[] {0.30f, 0.40f, 0.15f, 0.05f, 0.05f, 0.05f, 0.00f, 0.00f}, //2nd
        new float[] {0.15f, 0.35f, 0.25f, 0.15f, 0.10f, 0.00f, 0.00f, 0.00f}, //3rd
        new float[] {0.10f, 0.20f, 0.30f, 0.10f, 0.15f, 0.10f, 0.05f, 0.00f}, //4th
        new float[] {0.00f, 0.10f, 0.15f, 0.25f, 0.10f, 0.20f, 0.10f, 0.10f}, //5th
        new float[] {0.00f, 0.05f, 0.15f, 0.25f, 0.25f, 0.05f, 0.15f, 0.10f}, //6th
        new float[] {0.00f, 0.05f, 0.20f, 0.40f, 0.15f, 0.10f, 0.05f, 0.05f}, //7th
        new float[] {0.00f, 0.00f, 0.05f, 0.35f, 0.35f, 0.15f, 0.05f, 0.05f}  //8th
    };

    private void RestartArray()
    {
        for (int array = 0; array < placeProbabilities.Length; array++)
        {
            this.syncedPlaces[array] = new float[placeProbabilities[0].Length];
            Array.Copy(placeProbabilities[array], this.syncedPlaces[array], placeProbabilities[0].Length);
        }
        this.usedPlaces = 0;
    }

    private int GetNonZeroProbs(int placeArray)
    {
        int nonZeroProbs = 0;
        for (int place = 0; place < this.syncedPlaces[placeArray].Length; place++)
        {
            if (Math.Abs(this.syncedPlaces[placeArray][place]) > 0.0f) nonZeroProbs++;
        }
        return nonZeroProbs;
    }

    public int GetPlace(int place)
    {
        int newPlace = -1;
        float random = Random.Range(0.0001f, 0.9999f);
        float rng = (float)System.Math.Round(random * 100f) / 100f;
        
        float portion = 0;
        for (int i = 0; i < syncedPlaces[place].Length; i++)
        {
            portion += syncedPlaces[place][i];
            if (rng <= portion)
            {
                newPlace = i;
                break;
            }
        }
        
        this.usedPlaces++;
        if (this.usedPlaces < syncedPlaces[place].Length)
        {
            this.SyncPlaces(newPlace);
        }
        else
        {
            this.RestartArray();
        }
        return newPlace;
    }

    private void SyncPlaces(int usedPlace)
    {
        for (int placeArray = 0; placeArray < placeProbabilities[0].Length; placeArray++)
        {
            float currentPlaceProb = this.syncedPlaces[placeArray][usedPlace];
            this.syncedPlaces[placeArray][usedPlace] = 0.0f;
            float complement = currentPlaceProb / this.GetNonZeroProbs(placeArray);
            for (int place = 0; place < this.syncedPlaces[placeArray].Length; place++)
            {
                if(this.syncedPlaces[placeArray][place] > 0.0f) {
                    this.syncedPlaces[placeArray][place] += complement;
                }
            }
        }
    }
}
