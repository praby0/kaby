using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu_canvas;
    public GameObject hud;
    public FirstPersonController movement;
    public bool is_game_paused;
    public int game_level;

    // Start is called before the first frame update
    void Start()
    {
        menu_canvas.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = false;
        movement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
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

    public void play()
    {
        Time.timeScale = 1f;
        is_game_paused = false;
        menu_canvas.SetActive(false);
        hud.SetActive(true);
        Cursor.visible = false;
        movement.enabled = true;
    }
    void pause()
    {
        Time.timeScale = 0f;
        is_game_paused = true;
        menu_canvas.SetActive(true);
        hud.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        movement.enabled = false;
    }


    public void Title_Screen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - (game_level + 1));
    }

    public void quit()
    {
        Application.Quit();
    }

}
