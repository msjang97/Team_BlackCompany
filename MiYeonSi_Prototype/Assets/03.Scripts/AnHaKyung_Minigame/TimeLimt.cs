using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimt : MonoBehaviour
{
    Text text;
    public static float rTime = 10f;
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        rTime -= Time.deltaTime;
        if (rTime < 0)
        { 
            rTime = 0;
            SceneManager.LoadScene("MiFive");
        }

        text.text = " Time : " +  Mathf.Round(rTime);
    }
}
