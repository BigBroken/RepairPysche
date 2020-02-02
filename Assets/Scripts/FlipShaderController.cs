using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlipShaderController : MonoBehaviour
{
    public Camera targetCamera = null;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Vector3 screenPos = targetCamera.WorldToScreenPoint(transform.position);
        renderer.material.SetVector("_ObjectPosition", screenPos);
    }
}
