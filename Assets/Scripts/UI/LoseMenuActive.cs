using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuActive : MonoBehaviour
{
    public GameObject LoseButtons;
    public GameObject ScoreInformation;

    public void LoseMenuActivate()
    {
        LoseButtons.active = true;
        ScoreInformation.active = true;
        StaticParams.TotalScore += StaticParams.MelonCounter;
        Debug.Log(StaticParams.TotalScore);
    }
}
