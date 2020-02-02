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
    public GameObject garbleQuad;
    public GameObject flipQuad;
    public GameObject garbleMazeQuad;
    public GameObject flipMazeQuad;

    //UseRepair defines
    public float repairTime = 5;
    public float timer = 0;
    public bool isRepairing = false;
    public GameObject maze;
    
    List<NodeScript> allNodes = new List<NodeScript>();
    
    void Awake()
    {
        allNodes = new List<NodeScript>(Object.FindObjectsOfType<NodeScript>());
        garbleMazeQuad.SetActive(false);
        flipMazeQuad.SetActive(false);
    }

    void Update()
    {
        SetupQuads();
        
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
    
    protected override bool ShouldMove()
    {
        return !isRepairing;
    }
    
    void UseAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab, this.transform);
        Attack.GetComponent<AttackController>().SetDirection(body.velocity);
    }
    public void EnteredRegion(NodeScript Node)
    {

    }

    int captureNodeCount()
    {
        int result = 0;
        
        foreach(NodeScript n in allNodes) {
            if (n.currentState == NodeScript.NodeState.RobotControlled && AmRobot) {
                result += 1;
            } else if (n.currentState == NodeScript.NodeState.FairyControlled && !AmRobot) {
                result += 1;
            }
        }
        
        return result;
    }

    GameObject CurrentQuad()
    {
        int captured = captureNodeCount();
        
        if (captured == 4) {
            return flipQuad;
        } else if (captured == 5) {
            return garbleQuad;
        } else {
            return null;
        }
    }

    GameObject CurrentMazeQuad()
    {
        int captured = captureNodeCount();
        
        if (captured == 4) {
            return flipMazeQuad;
        } else if (captured == 5) {
            return garbleMazeQuad;
        } else {
            return null;
        }
    }
    
    void SetupQuads()
    {
        currentQuad = CurrentQuad();
        
        if (currentQuad) {
            currentQuad.SetActive(true);
        }
        
        if (garbleQuad != currentQuad) {
            garbleQuad.SetActive(false);
        }
        
        if (flipQuad != currentQuad) {
            flipQuad.SetActive(false);
        }
    }

    public void startRepair()
    {
        isRepairing = true;
        maze.GetComponent<MazeScript>().GenerateMaze(CurrentMazeQuad());
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
