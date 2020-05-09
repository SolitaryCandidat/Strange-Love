using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Buttonfunction : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public GameObject Buttons;
    public Text TapTheScreen;
    public Button TapButton;
    public AudioSource ClickButtonSound;
    public void ScreenTap()
    {
        TapButton.interactable = false;
        Buttons.active = true;
        TapTheScreen.enabled = false;
    }
    public void Play()
    {
        ClickButtonSound.Play();
        SceneManager.LoadScene("Game");
    }
    public void Info()
    {
        ClickButtonSound.Play();
        SceneManager.LoadScene("Info");
    }
    public void Shop()
    {
        ClickButtonSound.Play();
        SceneManager.LoadScene("Shop");
    }
    public void AudioOnOf(bool enable)
    {
        if(!enable)
        {
            Mixer.audioMixer.SetFloat("Volume", -80);
            ToggleChecker.TogglePosition = false;
        }
        else if(enable)
        {
            Mixer.audioMixer.SetFloat("Volume", 0);
            ToggleChecker.TogglePosition = true;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void sound()
    {
        ClickButtonSound.Play();
    }

}
