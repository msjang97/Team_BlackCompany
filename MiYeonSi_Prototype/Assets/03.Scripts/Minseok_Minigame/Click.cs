using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{ 
    public void Click_Button()
    {
        SelectChoice();
        this.gameObject.SetActive(false);
    }

    private void SelectChoice()
    {                 
        name = name.Replace("Button", "");
        ChoiceManager.P_instance.selectedNum = int.Parse(name);      
    }

}
