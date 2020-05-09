using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class StaticParams : MonoBehaviour
{
    public Text GameScore;
    public Text LoseMenuGameScore;
    public Text BestScoreText;

    public static int TotalScore = 0; //Main Menu Scene
    public static bool PlayerLose = false;
    public static int MelonCounter; //AnimationFinctions
    public static bool GameActive = false; //Road Mover + BackRoadMover + PlayerFunction
    public static float GameSpeed; //Road Mover + BackRoadMover\
    public static int BestScore = 0;
    void Start()
    {
        PlayerLose = false;
        MelonCounter = 0;
        GameSpeed = 1f;
        if(PlayerPrefs.HasKey("BestScore"))
        {
            TotalScore = PlayerPrefs.GetInt("TotalScore", TotalScore);
            BestScore = PlayerPrefs.GetInt("BestScore", BestScore);
        }
    }
    private void Update()
    {
        BestScoreText.text = BestScore.ToString();
        GameScore.text = MelonCounter.ToString();
        LoseMenuGameScore.text = MelonCounter.ToString();
        if(MelonCounter > BestScore)
        {
            BestScore = MelonCounter;
        }
    }
    public void Saver()
    {
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        PlayerPrefs.SetInt("BestScore", BestScore);
    }
}
