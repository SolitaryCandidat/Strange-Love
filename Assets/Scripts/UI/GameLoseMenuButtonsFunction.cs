using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLoseMenuButtonsFunction : MonoBehaviour
{
    public AudioSource ClickButtonSound;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadStarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SoundButton()
    {
        ClickButtonSound.Play();
    }
}
