using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    private float animationPlayTime = 1.0f;
    private int i = 0;
    private static bool isCutScene = true;

    public GameObject[] CutScenes;

    // Start is called before the first frame update
    void Start()
    {
        if (isCutScene == true)
        {
            StartCoroutine(MoveToNext());
            isCutScene = false;
        }
        else
            ShowMainMenu.instance.ActiveMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveToNext()
    {
        while (i < CutScenes.Length-1)
        {
            yield return new WaitForSeconds(animationPlayTime);

            CutScenes[i].SetActive(false);
            CutScenes[i+1].SetActive(true);

            i++;
        }
        i = 0;
    }
}
