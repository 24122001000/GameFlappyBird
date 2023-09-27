using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string HIGH_SCORE = "High score";

    private void Awake()
    {
        MakeSingleInstance();
        IsGameStartForTheFirstTime();
    }

    void IsGameStartForTheFirstTime()
    {
        if (PlayerPrefs.HasKey("IsGameStartForTheFirstTime") == true)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFirstTime", 0);
        }
    }

    //Sau khi điều hướng sang screen khác vẫn giữ nguyên gameobject gamemanager
    void MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance =this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
