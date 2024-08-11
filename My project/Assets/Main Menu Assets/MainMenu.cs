using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setting()
    {
        
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit Game");
    }
}
