using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject root;

    public GameObject tutorial;

    public string scene; 
    
    public void Play()
    {
        SceneManager.LoadScene(scene);
    }
    public void HowToPlay()
    {
        root.SetActive(false);
        tutorial.SetActive(true);
    }
    public void Settings()
    {
        root.SetActive(false);
        settings.SetActive(true);
    }
    public void QuitButton()
    {

        Application.Quit();

    }
    public void BackButton()
    {

        root.SetActive(true);
        settings.SetActive(false);
        tutorial.SetActive(false);

    }


}
