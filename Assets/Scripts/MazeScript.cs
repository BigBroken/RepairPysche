﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    public GameObject[] tiles = { };
    float[] yPositions = { 0.59f, -0.06f, -0.72f };

    private void Start()
    {
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject foo = Instantiate(tiles[Random.Range(0, 5)]);
            foo.transform.parent = transform;
            int leftOrRight = Random.Range(0,2);
            print(leftOrRight);

            if(leftOrRight == 1)
            {
                foo.transform.localPosition = new Vector3(-0.178f, yPositions[i], 0);
            }
            else
            {
                foo.transform.localPosition = new Vector3(0.178f, yPositions[i], 0);
            }
        }
    }

    public void EndMaze()
    {

    }
}
