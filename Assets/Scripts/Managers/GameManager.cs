using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Player Data")]
    public GameObject player;

    [Header("Camera Data")]
    public GameObject mainCam;
    public GameObject cmCamera;

    [Header("Collectables Collected")]
    public List<GameObject> treasureCollected;


    private void Awake()
    {
        LoadNextLevel();
        DontDestroyOnLoad(gameObject);
    }
    

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void OnLevelWasLoaded(int level)
    {
        Vector3 startPos = GameObject.FindGameObjectWithTag("StartPos").transform.position;
        InstantiatePlayer(startPos);
        Instantiate(mainCam, new Vector3(), Quaternion.identity);
        Instantiate(cmCamera, new Vector3(0,0,-3f), Quaternion.identity);
    }


    void InstantiatePlayer(Vector3 startPos)
    {
        print("Creating Player");
        Instantiate(player, startPos, Quaternion.identity);
    }
}
