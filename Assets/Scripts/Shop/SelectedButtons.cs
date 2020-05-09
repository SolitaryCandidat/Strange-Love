using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SelectedButtons : MonoBehaviour
{
    public AudioSource ButtonClickSound;
    public Button BuyButton;
    public Text TotalScore;

    public Button[] Buttons;

    public GameObject[] GrayObjects;

    public GameObject[] ColorObjects;

    public int[] IndexAlredyBuy;

    private int ButtonIsActive;

    private void Start()
    {
        Loader();
        ButtonClick(0);
    }
    private void Saver()
    {
        for(int i = 0; i < IndexAlredyBuy.Length; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), IndexAlredyBuy[i]);
        }
    }
    private void Loader()
    {
        for (int i = 0; i < IndexAlredyBuy.Length; i++)
        {
            IndexAlredyBuy[i] = PlayerPrefs.GetInt(i.ToString(), IndexAlredyBuy[i]);
            if(IndexAlredyBuy[i] == 1)
            {
                Buttons[i].image.GetComponent<Image>().color = Color.white;
                GrayObjects[i] = ColorObjects[i];
            }
        }
    }
    public void ButtonClick(int buttonState)
    {
        ButtonIsActive = buttonState;
        Debug.Log(ButtonIsActive);
        for (int i = 0; i < IndexAlredyBuy.Length; i++)
        {
            if (ButtonIsActive == i)
            {
                GrayObjects[i].SetActive(true);
            }
            else if (ButtonIsActive != i)
            {
                GrayObjects[i].SetActive(false);
            }
        }
    }
    public void Buy()
    {
        StaticParams.TotalScore -= 70;
        PlayerPrefs.SetInt("TotalScore", StaticParams.TotalScore);
        GrayObjects[ButtonIsActive].SetActive(false);
        GrayObjects[ButtonIsActive] = ColorObjects[ButtonIsActive];
        GrayObjects[ButtonIsActive].SetActive(true);
        Buttons[ButtonIsActive].image.GetComponent<Image>().color = Color.white;
        IndexAlredyBuy[ButtonIsActive] = 1;
        Saver();
    }
  
    private void Update()
    {
        if((IndexAlredyBuy[ButtonIsActive] == 1) || (StaticParams.TotalScore < 70))
        {
            BuyButton.interactable = false;
        }
        else
        {
            BuyButton.interactable = true;
        }
        TotalScore.text = StaticParams.TotalScore.ToString();
    }
    public void SoundOn()
    {
        ButtonClickSound.Play();
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
