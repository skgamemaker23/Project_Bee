using System.Collections.Frozen;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;


//using unity discussions post with edits
public class pause: MonoBehaviour
{
   
   
  
    public GameObject pausemenu;

    
    private bool paused;


   



    private void Start()
    {
        pausemenu.SetActive(false);


    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pausemenu.SetActive(true);
                paused = true;
                PauseGame();
            }
            else
            {
                pausemenu.SetActive(false);
                paused = false;
                
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

    }





    
    


}
