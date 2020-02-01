using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
	public bool startedLeft = true;
	public bool controlledLeft = true;

    public SpriteRenderer nodeSpriteRenderer;

    public Sprite leftControlled;
    public Sprite rightControlled;

    public Sprite regionLeftControlled;
    public Sprite regionRightControlled;

    public enum NodeType {HighFunctions, Movement, VisAud}
    public GameObject region;

    public float nodeControlPercent = 100; //-100 is all the way controlled left and 100 is all the way controlled right
    public int leftInfluence = 0;
    public int rightInfluence = 0;

    public int unitNodeInfluence;
    public int startingNodeInfluence;
    public int controlledInfluence;

    void Start()
    {
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
        if (startedLeft)
        {
            leftInfluence += startingNodeInfluence;
        }
        if (!startedLeft)
        {
            rightInfluence += startingNodeInfluence;
        }
        if (controlledLeft)
        {
            leftInfluence += controlledInfluence;
        }
        if (!controlledLeft)
        {
            rightInfluence += controlledInfluence;
        }
    }

    void Update()
    {
        if (nodeControlPercent > 0 && controlledLeft)
        {
            changeControl();
        }

        if (nodeControlPercent < 0 && !controlledLeft)
        {
            changeControl();
        }

        nodeControlPercent += rightInfluence * Time.deltaTime;
        nodeControlPercent -= leftInfluence * Time.deltaTime;
        nodeControlPercent = Mathf.Clamp(nodeControlPercent, -100, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Right"))
        {
            rightInfluence += unitNodeInfluence;
        }

        if (collision.CompareTag("Left"))
        {
            leftInfluence += unitNodeInfluence;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Right"))
        {
            rightInfluence -= unitNodeInfluence;
        }

        if (collision.CompareTag("Left"))
        {
            leftInfluence -= unitNodeInfluence;
        }
    }

    void changeControl()
    {
        if (controlledLeft)
        {
            controlledLeft = false;
            leftInfluence -= controlledInfluence;
            rightInfluence += controlledInfluence;
            nodeSpriteRenderer.sprite = rightControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionRightControlled;
        }

        else if (!controlledLeft)
        {
            controlledLeft = true;
            leftInfluence += controlledInfluence;
            rightInfluence -= controlledInfluence;
            nodeSpriteRenderer.sprite = leftControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionLeftControlled;
        }
    }
}
