using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button button;

    public void StartOnClick()
    {
        SceneManager.LoadScene("IntroLevel");
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }
}
