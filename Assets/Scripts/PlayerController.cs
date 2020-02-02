using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{
    Rigidbody2D body;

    public GameObject AttackPrefab;
    public List<NodeScript> StartingNodes;
    public List<NodeScript> CapturedNodes;
    public NodeScript node;
    public bool AmRobot;

    //UseRepair defines
    public float repairTime = 5;
    public float timer = 0;
    public bool isRepairing = false;
    public GameObject maze;

    void Update()
    {
        if (Player == SelectedPlayer.Player1)
        {
            if (!isRepairing)
            {
                player1Movement();
            }
            
            if (Input.GetButtonDown("Player1Attack"))
            {
                
            }
            if (Input.GetButtonDown("Player1Repair"))
            {
                if (node != null)
                {
                    //StartCoroutine(AttemptRepair());
                    if (isRepairing)
                    {
                        endRepair();
                    }

                    else if (!isRepairing)
                    {
                        startRepair();
                    }
                }
            }
        }
        else if (Player == SelectedPlayer.Player2)
        {
            if (!isRepairing)
            {
                player2Movement();
            }
            
            if (Input.GetButtonDown("Player2Attack"))
            {
                UseAttack();
            }
            if (Input.GetButtonDown("Player2Repair"))
            {
                if (node != null)
                {
                    //StartCoroutine(AttemptRepair());
                    if (isRepairing)
                    {
                        endRepair();
                    }

                    else if (!isRepairing)
                    {
                        startRepair();
                    }
                }
            }
        }
    }
    void UseAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab, this.transform);
        Attack.GetComponent<AttackController>().SetDirection(body.velocity);
    }
    public void EnteredRegion(NodeScript Node)
    {

    }

    public void startRepair()
    {
        isRepairing = true;
        maze.GetComponent<MazeScript>().GenerateMaze();
    }

    public void endRepair()
    {
        isRepairing = false;
        maze.GetComponent<MazeScript>().EndMaze();
    }

    public IEnumerator AttemptRepair()
    {
        float repairTime = node.repairTime;
        string playerInput;
        if(SelectedPlayer.Player1 == Player)
        {
            playerInput = "Player1Repair";
        } else
        {
            playerInput = "Player2Repair";
        }
        while (Input.GetButton(playerInput) && timer < node.repairTime)
        {
            //update repair timer
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(timer > node.repairTime)
        {
            if (AmRobot)
            {
                node.changeState(NodeScript.NodeState.RobotControlled);
            } else
            {
                node.changeState(NodeScript.NodeState.FairyControlled);
            }
        }
        yield return null;
    }

    public void NodeDamaged(NodeScript.NodeType type)
    {
        switch (type)
        {
            case NodeScript.NodeType.HighFunctions:
                {
                    break;
                }
            case NodeScript.NodeType.Movement:
                {
                    break;
                }
            case NodeScript.NodeType.VisAud:
                {
                    break;
                }
            default: break;
        }
    }
}
