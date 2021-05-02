using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_size : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1080,1920, true);
    }


}
