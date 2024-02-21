using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI: MonoBehaviour
{
   
   public GameObject gameOverPainel;
   public AudioSource Source;

    public static GameControllerUI instance;

    // Start is called before the first frame update
    void Start()

    {
        
        instance = this;
        Time.timeScale = 1;

    }
   

    public void ShowGameOver()
    {
        gameOverPainel.SetActive(true);
        Time.timeScale = 0;
        Source.Stop();


    }

  
    
    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Paused()
    {
        SceneManager.LoadScene(1);
    }

   
}
