using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManger : MonoBehaviour
{
    [Header("Level Description")]
    public GameObject player;
    public Transform startPos;
    public LevelDescription ld;
    [Space]
    public float timeLimit = 0f;
    public float countDownSpeed = 1;
    public Dialogue[] dialogue;

    public static bool complete = false;
    public static bool faild = false;

    private bool isTrigger = false;
    private int dialougeNum = 0;
    private float origTimeLimit;
    private Text dTimer;
    private Text dName;
    private Text dDialogue;


    private void Start()
    {
        dTimer = GameObject.Find("Timer").GetComponent<Text>();
        dName = GameObject.Find("DB_Name").GetComponent<Text>();
        dDialogue = GameObject.Find("DB_Dialogue").GetComponent<Text>();
        timeLimit = (ld.timeLimit.min * 60) + ld.timeLimit.sec;
        origTimeLimit = timeLimit;
        dialogue = ld.dialogue;
        player = ld.player;
        Instantiate(player, startPos.position, Quaternion.identity);
    }

    //Working but I want to moive this to being an event based system 
    //so its not updating every frame
    private void LateUpdate()
    {
        CycleDialogue();
        CountDown();
    }

    void CycleDialogue()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!isTrigger)
            {
                isTrigger = true;
            }
            else
            {
                dialougeNum++;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            dialougeNum--;
        }

        dialougeNum = Mathf.Clamp(dialougeNum, 0, dialogue.Length - 1);

        if (isTrigger && dialogue.Length > 0) //&& dialougeNum < dialouge.Length)
        {
            dName.text = dialogue[dialougeNum].name;
            dDialogue.text = dialogue[dialougeNum].dialogue;
            //print(dialogue[dialougeNum].Name + " : " + dialogue[dialougeNum].dialogue);
        }
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

        dTimer.text = string.Format("{1}.{0:0.00}",sec, min);
    }
}