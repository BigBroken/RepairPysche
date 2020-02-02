using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    GameObject[] tiles = { };
    float[] yPositions = { 0.59f, -0.6f, -0.72f };
    float xMax = -0.178f;
    float xMin = 0.178f;

    private void Start()
    {
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        
    }

    public void EndMaze()
    {

    }
}
