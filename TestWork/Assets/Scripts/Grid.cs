using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject cubeObj;
    public int totalCubes;
    public float cubeSize = 1f;
    public int maxPerRow = 5;
    private Vector3 startPos;
    private List<GameObject> currentCubes;
    public InputField inputGridNo;

    private void Start()
    {
        currentCubes = new List<GameObject>();
        startPos = transform.position;
    }

    //Testing 
    private void Update()
    {
        totalCubes = int.Parse(inputGridNo.text);
    }

    public void SpawnGrid()
    {
        //Total cubes should be set here next time

        //If grid already exists then delete it and build a new one
        if (currentCubes.Count > 0)
        {
            for (int k = 0; k < currentCubes.Count; k++)
                Destroy(currentCubes[k]);
            currentCubes.Clear();
            CubeManager.instance.taggedCubes.Clear();
        }

        //Building the Grid
        int i = 0;                 //i takes the current number of cubes in the scene
        int w = 0;                 //w is the number of slots to moved on the width
        int h = 0;                 //h is the number of slot to move on the height

        while (i < totalCubes)
        {
            //Calculating spawn position by adding an offset to the x and y values
            //The offset is calculated based on the size of the cube and it id on from the width and hight tracker
            Vector3 spawnPos = new Vector3(startPos.x + (cubeSize * w), startPos.y + (cubeSize * h), startPos.z);
            currentCubes.Add(GameObject.Instantiate(cubeObj, spawnPos, Quaternion.identity));
            i++;

            //Incrementing width if the cubes are less that the maximum that can be held by the width 
            //Else reset the width tracker and incremnt the hight tracker to repat the process but one level higher
            if (w < maxPerRow - 1)
            {
                w++;
            }
            else
            {
                w = 0;
                h++;
            }
        }
    }
}