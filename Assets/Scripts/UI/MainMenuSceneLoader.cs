using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{
    public AudioSource Sound1;
    public AudioSource Sound2;
    public void MainSceneLoader()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Sound1Active1()
    {
        Sound1.Play();
    }
    public void Sound1Active2()
    {
        Sound2.Play();
    }
}
