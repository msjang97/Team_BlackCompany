using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    private float animationPlayTime = 4.0f;
    private int i = 0;

    public GameObject[] CutScenes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToNext());
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
