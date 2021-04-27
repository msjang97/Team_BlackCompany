using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_PlFive : MonoBehaviour
{
    public int max;
    int click;


    public void ChangeScene_PlFiveBtn()
    {
        click = transform.GetComponent<ClickFive>().love;
        if (click >= max)
        {
            switch (this.gameObject.name)
            {
                case "Button_+5":
                    SceneManager.LoadScene("PlFive");
                    break;
                case "Button_+3":
                    SceneManager.LoadScene("PlThree");
                    break;
                case "Button_0":
                    SceneManager.LoadScene("Zero");
                    break;
                case "Button_-5":
                    SceneManager.LoadScene("MiFive");
                    break;
            }
        }
    }   
}
