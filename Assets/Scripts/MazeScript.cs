using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    public GameObject[] tiles = { };
    float[] yPositions = { 0.59f, -0.06f, -0.72f };
    GameObject[] activeTiles = { null, null, null };

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

            activeTiles[i] = foo;
        }
    }

    public void EndMaze()
    {
        for(int i = 0; i < 3; i++)
        {
            Destroy(activeTiles[i]);
        }
    }
}
