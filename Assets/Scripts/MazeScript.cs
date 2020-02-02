using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    public GameObject mazePlayerPrefab;
    public GameObject mazePlayerReal;
    public GameObject brainController;
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

        mazePlayerReal = Instantiate(mazePlayerPrefab, transform);
        mazePlayerReal.transform.localPosition = new Vector3(0, -1.13f, 0);
    }

    public void EndMaze()
    {
        for(int i = 0; i < 3; i++)
        {
            Destroy(activeTiles[i]);
        }

        Destroy(mazePlayerReal);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (brainController.CompareTag("Right"))
        {
            brainController.GetComponent<FairyBrainController>().node.RepairedFairy();
            brainController.GetComponent<FairyBrainController>().endRepair();
        }

        else if(brainController.CompareTag("Left"))
        {
            brainController.GetComponent<RobotController>().node.RepairedRobot();
            brainController.GetComponent<RobotController>().endRepair();
        }
    }
}
