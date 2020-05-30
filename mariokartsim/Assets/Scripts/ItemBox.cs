using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemBox
{
    private static float[][] itemProbabilities = new float[][]
    {
        new float[] {0.57f, 0.13f, 0.02f, 0.13f, 0.02f, 0.02f, 0.00f, 0.00f, 0.00f, 0.05f, 0.00f, 0.02f, 0.04f, 0.00f, 0.00f}, //1st
        new float[] {0.57f, 0.00f, 0.02f, 0.02f, 0.04f, 0.07f, 0.09f, 0.00f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.07f, 0.02f}, //2nd
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.04f, 0.09f, 0.09f, 0.00f, 0.02f, 0.00f, 0.04f, 0.00f, 0.02f, 0.09f, 0.04f}, //3rd
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.00f, 0.06f, 0.09f, 0.02f, 0.04f, 0.00f, 0.07f, 0.00f, 0.02f, 0.09f, 0.04f}, //4th
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.00f, 0.04f, 0.09f, 0.02f, 0.04f, 0.00f, 0.07f, 0.00f, 0.02f, 0.11f, 0.04f}, //5th
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.09f, 0.04f, 0.06f, 0.00f, 0.09f, 0.00f, 0.00f, 0.11f, 0.04f}, //6th
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.09f, 0.04f, 0.09f, 0.00f, 0.13f, 0.00f, 0.00f, 0.04f, 0.04f}, //7th
        new float[] {0.57f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.09f, 0.06f, 0.09f, 0.00f, 0.13f, 0.00f, 0.00f, 0.02f, 0.04f}  //8th
    };

    private static float[][] itemProbabilities2 = new float[][]
    {
        new float[] {0.0f, 0.30f, 0.05f, 0.30f, 0.05f, 0.05f, 0.00f, 0.00f, 0.00f, 0.10f, 0.00f, 0.05f, 0.10f, 0.00f, 0.00f}, //1st
        new float[] {0.0f, 0.00f, 0.05f, 0.05f, 0.10f, 0.15f, 0.20f, 0.00f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.15f, 0.05f}, //2nd
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.20f, 0.00f, 0.05f, 0.00f, 0.10f, 0.00f, 0.05f, 0.20f, 0.10f}, //3rd
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.00f, 0.15f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.20f, 0.10f}, //4th
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.00f, 0.10f, 0.20f, 0.05f, 0.10f, 0.00f, 0.15f, 0.00f, 0.05f, 0.25f, 0.10f}, //5th
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.15f, 0.00f, 0.20f, 0.00f, 0.00f, 0.25f, 0.10f}, //6th
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.10f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.10f, 0.10f}, //7th
        new float[] {0.0f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.20f, 0.15f, 0.20f, 0.00f, 0.30f, 0.00f, 0.00f, 0.05f, 0.10f}  //8th
    };

    private static int noItems = itemProbabilities[0].Length;

    private static string[] itemNames = new string[]
    {
        "No Item",
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

    public static int getItem(int place)
    {
        int newItem = 0;
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
                        newItem = i;
                        break;
                    }
                }
            }
        }
        return newItem;
    }
}