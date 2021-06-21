using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{   
    private Animator animator;
    private Vector3 myPosition;
    public Bar bar;
    public Timer_SuJin time_sujin;


    private bool isSelected;
    private float destroyedTime = 2.0f;
    static public bool lovecheck = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        myPosition = this.transform.position;
        lovecheck = false;
    }

    void Update()
    {
        if (bar.P_isStoped == true)
        {
            SelectChoice();
            AnimationController();
         
        }
        else if (time_sujin.TimeCost <= 0.0f )
        {
            if(this.name == "Choice1")
            TimeOutSelectChoice();
            else
            AnimationController();
        }

       
    }

    private void SelectChoice()
    {
        if (bar.P_BarPosition.y < myPosition.y + 0.85 && bar.P_BarPosition.y > myPosition.y - 0.85)
        {
            bar.gameObject.transform.position = Vector3.Lerp(transform.position, myPosition, 0.01f);
            isSelected = true;
            animator.SetBool("IsSelected", true);
            name = name.Replace("Choice", "");
            ChoiceManager.P_instance.selectedNum = int.Parse(name);

            if (lovecheck == true)
            {
                Set_Lovepoint();
                lovecheck = false;
            }
        }
    }

    private void TimeOutSelectChoice()
    {
        bar.gameObject.transform.position = Vector3.Lerp(transform.position, myPosition, 0.01f);
        isSelected = true;
        animator.SetBool("IsSelected", true);

        ChoiceManager.P_instance.selectedNum = 1;
    }

    private void AnimationController()
    {
        if (isSelected == false)
        {
            animator.SetBool("havetoDestroy", true);
            Destroy(this.gameObject, destroyedTime);
        }          
    }


    public void Set_Lovepoint()
    {
        switch (ChoiceManager.P_instance.selectedNum)
        {
            case 1:
                LovePoint.instance.Main_LovePoint_Cal(-5);
                break;
            case 2:
                LovePoint.instance.Main_LovePoint_Cal(0);
                break;
            case 3:
                LovePoint.instance.Main_LovePoint_Cal(3);
                break;
            case 4:
                LovePoint.instance.Main_LovePoint_Cal(5);
                break;
            default:
                break;
        }
    }
}
