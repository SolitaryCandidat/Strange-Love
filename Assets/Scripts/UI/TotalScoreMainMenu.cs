using UnityEngine.UI;
using UnityEngine;

public class TotalScoreMainMenu : MonoBehaviour
{
    public Text TotalScore;
    void Start()
    {
        StaticParams.TotalScore = PlayerPrefs.GetInt("TotalScore", StaticParams.TotalScore);
        TotalScore.text = StaticParams.TotalScore.ToString();
    }
    public void Loaders()
    {
        PlayerPrefs.DeleteAll();
    }
}
