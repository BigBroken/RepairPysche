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
    public GameObject node;

    //UseRepair defines
    public float repairTime = 5;
    public float timer = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player == SelectedPlayer.Player1)
        {
            horizontal = Input.GetAxisRaw("Player1Horizontal");
            vertical = Input.GetAxisRaw("Player1Vertical");
            if (Input.GetButtonDown("Player1Attack"))
            {
                UseAttack();
            }
            if (Input.GetButton("Player1Repair"))
            {
                UseRepair();
            }
        }
        else if (Player == SelectedPlayer.Player2)
        {
            horizontal = Input.GetAxisRaw("Player2Horizontal");
            vertical = Input.GetAxisRaw("Player2Vertical");
            if (Input.GetButtonDown("Player2Attack"))
            {
                UseAttack();
            }
            if (Input.GetButton("Player2Repair"))
            {
                UseRepair();
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

    void UseRepair()
    {
        if (node != null)
        {
            if (timer >= repairTime)
            {
                timer = 0;
                if (SelectedPlayer.Player1 == Player)
                {
                    node.GetComponent<NodeScript>().nodeControl -= 1;
                }
                else if (SelectedPlayer.Player2 == Player)
                {
                    node.GetComponent<NodeScript>().nodeControl += 1;
                }
                return;
            }

            timer += Time.deltaTime;
        }
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
                    // your code 
                    // for plus operator
                    break;
                }
            case NodeScript.NodeType.Movement:
                {
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case NodeScript.NodeType.VisAud:
                {
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            default: break;
        }
    }
}
