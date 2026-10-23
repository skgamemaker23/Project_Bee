using UnityEngine;
using UnityEngine.SceneManagement;

//pops up when player gets game over screen 
//basic navigation 
public class endmenu : MonoBehaviour
{
    

    
    public string scene; // bee garden - play again restart 
    public string mainmenue; // got back to title page 
    
    public void Play()
    {
        SceneManager.LoadScene(scene);
    }
    public void Main()
    {
        SceneManager.LoadScene(mainmenue);
    }

    public void Quit()
    {

        Application.Quit();

    }
    


}
