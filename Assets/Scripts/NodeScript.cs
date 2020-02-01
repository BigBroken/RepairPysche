using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
	public bool startedLeft = false;
	public bool controlledLeft = false;

    public Sprite leftControlled;
    public Sprite rightControlled;

    public Sprite regionLeftControlled;
    public Sprite regionRightControlled;

    public GameObject region;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            changeControl();
        }
    }

    void changeControl()
    {
        if (controlledLeft)
        {
            controlledLeft = false;
            GetComponent<SpriteRenderer>().sprite = rightControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionRightControlled;

        }

        else if (!controlledLeft)
        {
            controlledLeft = true;
            GetComponent<SpriteRenderer>().sprite = leftControlled;
            region.GetComponent<SpriteRenderer>().sprite = regionLeftControlled;
        }
    }
}
