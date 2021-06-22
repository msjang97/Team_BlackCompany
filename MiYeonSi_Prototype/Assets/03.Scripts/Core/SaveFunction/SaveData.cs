using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    private static SaveData instance = null;
    public static SaveData P_instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private string _chapterName;
    public string ChapterName
    {
        get { return _chapterName; }
        set { _chapterName = value; }
    }

    private int _savedChapterProgress;
    public int SavedChapterProgress
    {
        get { return _savedChapterProgress; }
        set { _savedChapterProgress = value; }
    }

    private int _savedBackgroundLine;
    public int SavedBackgroundLine
    {
        get { return _savedBackgroundLine; }
        set { _savedBackgroundLine = value; }
    }

    private string _savedPlaySong;
    public string SavedPlaySong
    {
        get { return _savedPlaySong; }
        set { _savedPlaySong = value; }
    }

    private bool _isLoadData;
    public bool isLoadData
    {
        get { return _isLoadData; }
        set { _isLoadData = value; }
    }

    string dataPath;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        dataPath = Application.dataPath + "/05.SaveData/SaveData.txt";

        // 이 부분은 테스트를 위해서 사용했고, 나중에 이어하기 할 데이터가 없으면 UI내의 경고창으로 대체할 예정
        FileInfo dataFile = new FileInfo(dataPath);
        if (!dataFile.Exists)
        {
            SaveGame("Chapter0_start", 0, 0, "Title");
        }

        _chapterName = "";
        _savedChapterProgress = 0;
        _isLoadData = false;
    }


    public void SaveGame(string chapterName, int chapterProgress, int backgroundLine, string playSong)
    {
        _chapterName = chapterName;
        _savedChapterProgress = chapterProgress;
        _savedBackgroundLine = backgroundLine;
        _savedPlaySong = playSong;

        FileInfo dataFile = new FileInfo(dataPath);

        FileStream fs = dataFile.Create();
        TextWriter tw = new StreamWriter(fs);
        tw.Write("ChapterName : " + _chapterName + "\n");
        tw.Write("ChapterProgress : " + _savedChapterProgress + "\n"); 
        tw.Write("SavedBackgroundLine : " + _savedBackgroundLine + "\n");
        tw.Write("SavedPlaySong : " + _savedPlaySong + "\n");

        tw.Write("enji_LovePoint : " + LovePoint.instance.enji_LovePoint + "\n");
        tw.Write("hagyoung_LovePoint : " + LovePoint.instance.hagyoung_LovePoint + "\n");
        tw.Write("minseok_LovePoint : " + LovePoint.instance.minseok_LovePoint + "\n");
        tw.Write("sujin_LovePoint : " + LovePoint.instance.sujin_LovePoint + "\n");

        tw.Close();
        fs.Close();

        Debug.Log(_chapterName + ", line : " + _savedChapterProgress + " lastBackground : " + _savedBackgroundLine + ", " + _savedPlaySong);

        // 추가 작성
        // File.AppendAllText(Application.dataPath + "/SaveData.txt", "  !@#추가 내용");
    }

    public void LoadGame()
    {
        if (File.Exists(dataPath))
        {
            string[] loadData = File.ReadAllLines(dataPath);
            for (int i = 0; i < loadData.Length; i++)
            {
                string[] data = null;
                if (loadData[i].StartsWith("ChapterName : "))
                {
                    // 배열의 3번째에 정보가 들어감.
                    data = loadData[i].Split(' ', '\n');
                    _chapterName = data[2];
                }
                else if (loadData[i].StartsWith("ChapterProgress : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    _savedChapterProgress = int.Parse(data[2]);
                }
                else if (loadData[i].StartsWith("SavedBackgroundLine : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    _savedBackgroundLine = int.Parse(data[2]);
                }
                else if (loadData[i].StartsWith("SavedPlaySong : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    _savedPlaySong = data[2];
                }
                else if (loadData[i].StartsWith("enji_LovePoint : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    LovePoint.instance.enji_LovePoint = int.Parse(data[2]);
                }
                else if (loadData[i].StartsWith("hagyoung_LovePoint : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    LovePoint.instance.hagyoung_LovePoint = int.Parse(data[2]);
                }
                else if (loadData[i].StartsWith("minseok_LovePoint : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    LovePoint.instance.minseok_LovePoint = int.Parse(data[2]);
                }
                else if (loadData[i].StartsWith("sujin_LovePoint : "))
                {
                    data = loadData[i].Split(' ', '\n');
                    LovePoint.instance.sujin_LovePoint = int.Parse(data[2]);
                }
            }

            Debug.Log("Load!" + _chapterName + ", line : " + _savedChapterProgress + " lastBackground : " + _savedBackgroundLine + ", " + _savedPlaySong);
        }
        else
        {
            string errorMessage = "ERR! File " + dataPath + " does not exist!";
            Debug.LogError(errorMessage);
        }
    }
}
