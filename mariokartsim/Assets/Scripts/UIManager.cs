using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private GameObject[] currentPlaces;
    private float[][] targetPositions;

    void Start()
    {
        //this.currentPlaces = null;
        this.targetPositions = new float[][]
        {
            new float[]{-750f, 374f}, //1st
            new float[]{-750f, 254f}, //2nd
            new float[]{-750f, 134f}, //3rd
            new float[]{-750f, 14f}, //4th
            new float[]{-750f, -106f}, //5th
            new float[]{-750f, -226f}, //6th
            new float[]{-750f, -346f}, //7th
            new float[]{-750f, -466f} //8th

        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void receivePlaces(GameObject[] places)
    {
        //this.currentPlaces = places;
    }*/

    public void InitPlaces(RectTransform character, int place)
    {
        character.localPosition = new Vector3(this.targetPositions[place][0], this.targetPositions[place][1], 0);
    }

    public void ChangePlaces(RectTransform character, int place)
    {
        
        Vector3 targetPosition = new Vector3(this.targetPositions[place][0], this.targetPositions[place][1], 0);
        StartCoroutine(SmoothChange(character, targetPosition));

    }

    IEnumerator SmoothChange(RectTransform character, Vector3 targetPosition)
    {
        while (Vector3.Distance(character.localPosition, targetPosition) > 0.01f)
        {
            character.localPosition = Vector3.MoveTowards(character.localPosition, targetPosition, Time.deltaTime * 5000f);
            yield return new WaitForSeconds(0.02f);
        }

    }




}
