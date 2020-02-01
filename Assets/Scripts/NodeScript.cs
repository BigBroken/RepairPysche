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

    public GameObject region;

    public int nodeControl = 5; //-5 is all the way controlled left and 5 is all the way controlled right
    public int nodeHealth = 5;

    public int unitNodeInfluence;
    public int startingNodeInfluence;
    public int controlledInfluence;

    void Start()
    {
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (nodeControl > 0 && controlledLeft)
        {
            changeControl();
        }

        if (nodeControl < 0 && !controlledLeft)
        {
            changeControl();
        }

        nodeControl = Mathf.Clamp(nodeControl, -5, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Right"))
        {
            collision.GetComponent<FairyBrainController>().node = gameObject;
        }

        if (collision.CompareTag("Left"))
        {
            collision.GetComponent<RobotController>().node = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Right"))
        {
            collision.GetComponent<FairyBrainController>().node = null;
        }

        if (collision.CompareTag("Left"))
        {
            collision.GetComponent<RobotController>().node = null;
        }
    }

    void changeControl()
    {
        if (controlledLeft)
        {
            controlledLeft = false;
            nodeSpriteRenderer.sprite = rightControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionRightControlled;
        }

        else if (!controlledLeft)
        {
            controlledLeft = true;
            nodeSpriteRenderer.sprite = leftControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionLeftControlled;
        }
    }
}
