using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStates : MonoBehaviour
{
    public static MusicStates instance;
    public AK.Wwise.State NodeOne;
    public AK.Wwise.State NodeTwo;
    public AK.Wwise.State NodeThree;
    public AK.Wwise.State NodeFour;
    public AK.Wwise.State NodeFive;
    public AK.Wwise.State NodeSix;
    // Start is called before the first frame update
    void Awake() {

        if (instance == null)
        {
            instance = this;

        }else {


            Destroy(this);

        }
    }

    void Start()
    {
        AkSoundEngine.SetState("Node_1", "Captured_Robot");
        AkSoundEngine.SetState("Node_2", "Captured_Robot");
        AkSoundEngine.SetState("Node_3", "Captured_Robot");
        AkSoundEngine.SetState("Node_4", "Captured_Fairy");
        AkSoundEngine.SetState("Node_5", "Captured_Fairy");
        AkSoundEngine.SetState("Node_6", "Captured_Fairy");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nodeOneState(int nodeNumber,string nodeState)
    {

        AkSoundEngine.SetState("Node_" + nodeNumber, nodeState);

    }

    
}
