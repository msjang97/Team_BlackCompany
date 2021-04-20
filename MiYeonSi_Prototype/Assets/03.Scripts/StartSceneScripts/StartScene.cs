using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{  
    public void LoadGameScene() //게임 시작
    {
        SceneManager.LoadScene("MainSystem");
    }

    public void QuitApplication() //게임 종료
    {
        Application.Quit();
    }
    
}
