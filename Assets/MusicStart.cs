using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    public AK.Wwise.Event MyMusic;
    // Start is called before the first frame update
    void Start()
    {
        MyMusic.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
