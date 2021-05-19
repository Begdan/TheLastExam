using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstFloorStart");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
