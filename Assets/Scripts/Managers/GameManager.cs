using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

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
        DontDestroyOnLoad(mainCam);
        DontDestroyOnLoad(virtualCam);
        DontDestroyOnLoad(camConfiner);
    }    

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnLevelWasLoaded(int level)
    {
        Vector3 startPos = GameObject.FindGameObjectWithTag("StartPos").transform.position;
        InstantiatePlayer(startPos);
        InstantiateCameras(mainCam, virtualCam);
        //Instantiate(mainCam, new Vector3(), Quaternion.identity);
        //Instantiate(virtualCam, new Vector3(0,0,-3f), Quaternion.identity);
    }

    void InstantiatePlayer(Vector3 startPos)
    {
        print("Creating Player");
        Instantiate(player, startPos, Quaternion.identity);
    }

    void InstantiateCameras(GameObject mainCam, GameObject virtualCam)
    {
        virtualCam.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;  
    }
}
