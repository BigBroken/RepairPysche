using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
	public bool startedLeft = false;
	public bool controlledLeft = false;


    public SpriteRenderer nodeSpriteRenderer;

    public Sprite leftControlled;
    public Sprite rightControlled;

    public Sprite regionLeftControlled;
    public Sprite regionRightControlled;

    public GameObject region;

    void Start()
    {
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            changeControl();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
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
