﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice_ : MonoBehaviour
{
    public Text [] texts;


    private void Start()
    {
        Input_Text();
    }

    private void Input_Text()
    {
        for (int i = 0; i < 4; i++)
        {
            texts[i].text = ChoiceManager.P_instance.choices[i];
        }
    }
}
