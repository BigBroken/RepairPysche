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

    public Sprite fairySprite;
    public Sprite robotSprite;
    public Sprite destroyedSprite;

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
                    nodeSpriteRenderer.sprite = destroyedSprite;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case NodeState.RobotControlled:
                {
                    MusicStates.instance.nodeOneState(nodeNumber, "Captured_Robot");
                    nodeSpriteRenderer.sprite = robotSprite;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            case NodeState.FairyControlled:
                {
                    MusicStates.instance.nodeOneState(nodeNumber, "Captured_Fairy");
                    nodeSpriteRenderer.sprite = fairySprite;
                    // your code 
                    // for MULTIPLY operator
                    break;
                }
            default: break;
        }
    }
    
    public NodeState currentState {
        get {
            if (nodeSpriteRenderer.sprite == robotSprite) {
                return NodeState.RobotControlled;
            } else if (nodeSpriteRenderer.sprite == fairySprite) {
                return NodeState.FairyControlled;
            } else {
                return NodeState.Destroyed;
            }
        }
    }

    public void RepairedFairy()
    {
        changeState(NodeState.FairyControlled);
        print(":)");
    }

    public void RepairedRobot()
    {
        changeState(NodeState.RobotControlled);
        print(":|");
    }
}
