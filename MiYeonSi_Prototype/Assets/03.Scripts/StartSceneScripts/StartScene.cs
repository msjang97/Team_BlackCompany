using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{  
    public void StartGameScene() // 게임 시작
    {
        SceneManager.LoadScene("MainSystem");
    }

    public void StartMainMenuScene() // 게임 시작
    {
        AudioManager.instance.StopSong();
        SceneManager.LoadScene("StartScene");
    }

    public void LoadGameScene() // 게임 이어하기
    {
        SaveData.P_instance.isLoadData = true;
        SceneManager.LoadScene("MainSystem");
    }

    public void QuitApplication() //게임 종료
    {
        //AudioManager.instance.StopSong();
        Application.Quit();
    }
    
}
