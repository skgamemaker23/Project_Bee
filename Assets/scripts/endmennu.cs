using UnityEngine;
using UnityEngine.SceneManagement;

public class endmenu : MonoBehaviour
{
    

    
    public string scene; 
    
    public void Play()
    {
        SceneManager.LoadScene(scene);
    }
    
    public void Quit()
    {

        Application.Quit();

    }
    


}
