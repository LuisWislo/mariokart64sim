﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemBox
{
    private static float[][] itemProbabilities = new float[][]
    {
        new float[] {0.30f, 0.05f, 0.30f, 0.05f, 0.05f, 0.00f, 0.00f, 0.00f, 0.10f, 0.00f, 0.05f, 0.10f, 0.00f, 0.00f}, //1st
        new float[] {0.00f, 0.05f, 0.05f, 0.10f, 0.15f, 0.20f, 0.00f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.15f, 0.05f}, //2nd
        new float[] {0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.20f, 0.00f, 0.05f, 0.00f, 0.10f, 0.00f, 0.05f, 0.20f, 0.10f}, //3rd
        new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.15f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.20f, 0.10f}, //4th
        new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.25f, 0.10f}, //5th
        new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.15f, 0.00f, 0.20f, 0.00f, 0.00f, 0.25f, 0.10f}, //6th
        new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.10f, 0.10f}, //7th
        new float[] {0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.15f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.05f, 0.10f}  //8th
    };

    private static int noItems = itemProbabilities[0].Length;

    private static string[] itemNames = new string[]
    {
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

    public static string getItem(int place)
    {
        string newItem = "";
        bool itemFound = false;
        while (!itemFound)
        {
            float random = Random.Range(0.0f, 1.0f);
            float rng = (float) System.Math.Round(random * 100f) / 100f;
            if (rng > 0.0f)
            {
                float portion = 0;

                for (int i = 0; i < noItems; i++)
                {
                    portion += itemProbabilities[place][i];
                    if (rng <= portion)
                    {
                        itemFound = true;
                        newItem = itemNames[i];
                        break;
                    }
                }
            }
        }
        return newItem;
    }
}