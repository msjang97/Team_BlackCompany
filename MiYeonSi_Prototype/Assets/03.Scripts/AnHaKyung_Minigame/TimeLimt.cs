using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimt : MonoBehaviour
{
    Text text;
    public static float rTime;
    
    void Start()
    {
        rTime = 10f;
        text = GetComponent<Text>();
    }

    void Update()
    {
        rTime -= Time.deltaTime;
        if (rTime < 0)
        { 
            rTime = 0;
            ChoiceManager.P_instance.selectedNum = 1;
        }

        text.text = " " +  Mathf.Round(rTime);
    }
}
