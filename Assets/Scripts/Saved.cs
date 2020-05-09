using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saved : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("BestScore", StaticParams.BestScore);
        PlayerPrefs.SetInt("TotalScore", StaticParams.TotalScore);
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            StaticParams.BestScore = PlayerPrefs.GetInt("BestScore");
        }
        if(PlayerPrefs.HasKey("TotalScore"))
        {
            StaticParams.TotalScore = PlayerPrefs.GetInt("TotalScore");
        }
    }
}
