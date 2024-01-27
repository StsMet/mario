using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public static bool pause;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}
