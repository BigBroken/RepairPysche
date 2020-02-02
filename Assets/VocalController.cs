using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocalController : MonoBehaviour


{

    public static VocalController vocalControl;
    public AK.Wwise.Event fAttack;
    public AK.Wwise.Event fDamage;
    public AK.Wwise.Event fWin;
    public AK.Wwise.Event fLose;
    public AK.Wwise.Event rAttack;
    public AK.Wwise.Event rDamage;
    public AK.Wwise.Event rWin;
    public AK.Wwise.Event rLose;


    void Awake()
    {

        if (vocalControl == null)
        {
            vocalControl = this;

        }
        else
        {


            Destroy(this);

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void fairyAttack() { AkSoundEngine.PostEvent(fAttack, gameObject); }

    public void fairyDamage() { AkSoundEngine.PostEvent(fDamage, gameObject); }

    public void fairyWin() { AkSoundEngine.PostEvent(fWin, gameObject); }

    public void fairyLose() { AkSoundEngine.PostEvent(fLose, gameObject); }

    public void robotAttack() { AkSoundEngine.PostEvent(rAttack, gameObject); }

    public void robotDamage() { AkSoundEngine.PostEvent(rDamage, gameObject); }

    public void robotWin() { AkSoundEngine.PostEvent(rWin, gameObject); }

    public void robotLose() { AkSoundEngine.PostEvent(rLose, gameObject); }

}
