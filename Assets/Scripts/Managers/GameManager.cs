using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Collectables Collected")]
    public List<GameObject> treasureCollected;

    private int currentLevel;

    //private static bool Created = false;

    private void Awake()
    {
        /*
         * Need to test this out as it may not be necassary
        if (!Created)
        {
            DontDestroyOnLoad(this.gameObject);
            Created = true;
        }
        */
    }

    public static void LaunchLevels()
    {
        //Change the index number to the main scene
        SceneManager.LoadScene(1);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
