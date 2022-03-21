using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnds : MonoBehaviour
{   // Array of all scenes in build; as new ones become added, their names must be added to this string array
    string[] sceneArray = {"IntroLevel", "BouncePadLevel"};
    // set this in the inspector so that the index matches the string
    //e.g: sceneIndex 0 == Intro Level
    public int sceneIndex; 
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(sceneArray[sceneIndex + 1]);
        print("scene change");
    }


}
