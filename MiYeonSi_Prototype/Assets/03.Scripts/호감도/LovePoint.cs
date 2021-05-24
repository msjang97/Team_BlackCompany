using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovePoint : MonoBehaviour
{
    public static LovePoint instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    public int enji_LovePoint = 0; // 최은지 호감도
    public int sujin_LovePoint = 0; // 사수진 호감도
    public int hagyoung_LovePoint = 0; // 안하경 호감도
    public int minseok_LovePoint = 0; // 마민석 호감도



    public bool enji_end = true;
    public bool minseok_end = false;
    public bool sujin_end = false;
    public bool hagyong_end = false;
    public bool solo_end = false;

    public void Distr_LovePoint_Cal(int point) //방해자 점수 정리해주는 함수 - 챕터 별 방해자 한테 선택지 점수 넘겨주기
    {
        // 챕터 카운트를 가져와서 각각 챕터의 방해자에게 호감도 넣어주기 (사수진-1,4 ,7 / 안하경-3,6  / 마민석-2 ,5)
        if (NovelController.instance.ch_count == 1 || NovelController.instance.ch_count == 4 || NovelController.instance.ch_count == 7) // 사수진       
            sujin_LovePoint = point;
        
        else if (NovelController.instance.ch_count == 3 || NovelController.instance.ch_count == 6 ) //안하경        
            hagyoung_LovePoint = point;
        
        else if (NovelController.instance.ch_count == 2 || NovelController.instance.ch_count == 5 ) // 마민석       
            minseok_LovePoint = point;
          
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {      

    }
}
