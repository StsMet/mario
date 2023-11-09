using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug . Log("Exit");
    }
}
