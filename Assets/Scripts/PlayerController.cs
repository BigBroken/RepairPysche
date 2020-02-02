using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public enum SelectedPlayer { Player1, Player2 };
    public SelectedPlayer Player;
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

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player == SelectedPlayer.Player1)
        {
            if (!isRepairing)
            {
                horizontal = Input.GetAxisRaw("Player1Horizontal");
                vertical = Input.GetAxisRaw("Player1Vertical");
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
                horizontal = Input.GetAxisRaw("Player2Horizontal");
                vertical = Input.GetAxisRaw("Player2Vertical");
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

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
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
