using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu_canvas;
    public bool is_game_paused;
    public int game_level;

    // Start is called before the first frame update
    void Start()
    {
        menu_canvas.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(is_game_paused)
            {
                play();   
            }
            else
            {
                pause();
            }
        }
    }

    void play()
    {
        Time.timeScale = 1f;
        is_game_paused = false;
        menu_canvas.SetActive(false);
        
    }
    void pause()
    {
        Time.timeScale = 0f;
        is_game_paused = true;
        menu_canvas.SetActive(true);
    }


    void Title_Screen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - (game_level + 1));
    }

}
