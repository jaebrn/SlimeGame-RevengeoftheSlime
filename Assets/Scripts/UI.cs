using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button button;
    public GameObject player;
    public Vector2 resetPos;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
        resetPos = player.GetComponent<PlayerControllerCurrent>().initialPosition;
    }
    public void StartOnClick()
    {
        SceneManager.LoadScene("IntroLevel");
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }


    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && player!= null)
        {
            player.transform.position = resetPos;
            print("reset");
        }
    }

}
