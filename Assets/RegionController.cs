using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionController : MonoBehaviour
{
    public NodeScript node;

    public void Awake()
    {
        node = GetComponentInParent<NodeScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() is PlayerController player)
        {
            player.EnteredRegion(node);
        }
    }
}
