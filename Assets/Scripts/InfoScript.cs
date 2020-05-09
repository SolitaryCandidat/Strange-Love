using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class InfoScript : MonoBehaviour
{
    public AudioSource SoundOfButton;
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ButtonSound()
    {
        SoundOfButton.Play();
    }
}
