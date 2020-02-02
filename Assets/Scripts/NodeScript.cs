using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public int nodeNumber;
    public enum NodeState {Destroyed, RobotControlled, FairyControlled,}
	public bool startedLeft = true;
	public bool controlledLeft = true;
    public float repairTime;
    public float attackTime;


    public SpriteRenderer nodeSpriteRenderer;

    public Sprite leftControlled;
    public Sprite rightControlled;
    public Sprite destroyed;

    public Sprite regionLeftControlled;
    public Sprite regionRightControlled;

    public enum NodeType {HighFunctions, Movement, VisAud}
    public GameObject region;

    void Start()
    {
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if (nodeControl > 0 && controlledLeft)
        //{
        //    changeControl();
        //}

        //if (nodeControl < 0 && !controlledLeft)
        //{
        //    changeControl();
        //}

        //nodeControl = Mathf.Clamp(nodeControl, -5, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right"))
        {
            collision.GetComponent<FairyBrainController>().node = this;
        }

        if (collision.CompareTag("Left"))
        {
            collision.GetComponent<RobotController>().node = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Right"))
        {
            collision.GetComponent<FairyBrainController>().node = null;
        }

        if (collision.CompareTag("Left"))
        {
            collision.GetComponent<RobotController>().node = null;
        }
    }

    public void changeState(NodeState state)
    {
        switch (state)
        {
            case NodeState.Destroyed:
                {
                    MusicStates.instance.nodeOneState(nodeNumber, "Destroyed");
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case NodeState.RobotControlled:
                {
                    MusicStates.instance.nodeOneState(nodeNumber, "Captured_Robot");
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case NodeState.FairyControlled:
                {
                    MusicStates.instance.nodeOneState(nodeNumber, "Captured_Fairy");
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            default: break;
        }
    }
}
