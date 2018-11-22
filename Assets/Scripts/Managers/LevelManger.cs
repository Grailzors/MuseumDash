using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManger : MonoBehaviour
{
    public float test;

    [Header("Level Description")]
    public LevelDescription ld;
    public GameObject player;
    public Camera mainCam;
    public Transform startPos;
    [Space]
    [SerializeField]
    public float countDownSpeed = 1;

    public static Dialogue[] dialogue;
    public static float timeLimit = 0f;
    public static bool complete = false;
    public static bool faild = false;
    public static string timerText;

    private bool isTrigger = false;
    private float origTimeLimit;


    private void Start()
    {        
        timeLimit = (ld.timeLimit.min * 60) + ld.timeLimit.sec;
        origTimeLimit = timeLimit;
        dialogue = ld.dialogue;
        player = ld.player;
        mainCam = ld.mainCam;

        mainCam.orthographicSize = ld.camSize;

        Instantiate(mainCam, new Vector3(0f, 0f, -3f), Quaternion.identity);
        Instantiate(player, startPos.position, Quaternion.identity);
    }


    private void LateUpdate()
    {
        
    }

    void FailedLevel()
    {
        //Here reload the same level again so its all reset 
    }


    /*
    //Working but I want to moive this to being an event based system 
    //so its not updating every frame
    private void LateUpdate()
    {
        CountDown();
    }

    void CountDown()
    {
        if (timeLimit < 2.5f)
        {
            timeLimit -= (countDownSpeed * Time.deltaTime) / 3.5f;
        }
        else
        {
            timeLimit -= countDownSpeed * Time.deltaTime;
        }

        //timeLimit -= countDownSpeed * Time.deltaTime;
        timeLimit = Mathf.Clamp(timeLimit, 0f, origTimeLimit);

        if (timeLimit == 0)
        {
            faild = true;
        }

        float sec = (float)(timeLimit % 60);
        int min = (int)(timeLimit / 60) % 60;

        timerText = string.Format("{1}.{0:0.00}",sec, min);
    }
    */
}