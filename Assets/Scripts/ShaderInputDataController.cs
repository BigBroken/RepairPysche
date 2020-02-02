using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderInputDataController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void OnWillRenderObject()
    {
        Camera targetCamera = Camera.current ? Camera.current : Camera.main;
        Vector3 screenPos = targetCamera.WorldToScreenPoint(transform.position);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetVector("_ObjectPosition", screenPos);
    }
}
