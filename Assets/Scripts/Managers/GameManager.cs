using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Player Data")]
    public GameObject player;

    [Header("Camera Data")]
    public GameObject mainCam;
    public GameObject virtualCam;
    public GameObject camConfiner;

    [Header("Collectables Collected")]
    public List<GameObject> treasureCollected;


    private void Awake()
    {
        LoadNextLevel();
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadNextLevel()
    {
        Object.Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("TestUI", LoadSceneMode.Additive);

    }
}
