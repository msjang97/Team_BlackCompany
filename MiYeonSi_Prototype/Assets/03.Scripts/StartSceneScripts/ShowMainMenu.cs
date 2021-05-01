using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMainMenu : MonoBehaviour
{
    public static ShowMainMenu instance;
    private GameObject MainMenu;

    private void Awake()
    {
        instance = this;
        MainMenu = this.transform.GetChild(3).gameObject;        
    }

    public void ActiveMainMenu()
    {
        MainMenu.SetActive(true);
    }
}
