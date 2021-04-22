using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    public float maxHp;
    private float curHp = 0;

    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           curHp += 1;
       
        }

        HandleHp();
    }

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }
}
