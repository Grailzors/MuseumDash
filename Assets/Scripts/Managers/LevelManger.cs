﻿using System.Collections;
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
    public float countDownSpeed = 1;

    public static Dialogue[] dialogue;
    public static float timeLimit = 0f;
    public static bool complete = false;
    public static bool faild = false;
    public static string timerText;

    //private readonly bool isTrigger = false;


    private void Start()
    {        
        timeLimit = (ld.timeLimit.min * 60) + ld.timeLimit.sec;
        dialogue = ld.dialogue;
        player = ld.player;
        mainCam = ld.mainCam;
        mainCam.orthographicSize = ld.camSize;
        DialogueBoxController.dialogueNum = -1;

        Instantiate(mainCam, new Vector3(0f, 0f, -3f), Quaternion.identity);
        Instantiate(player, startPos.position, Quaternion.identity);
    }
}