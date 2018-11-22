using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public float countDownSpeed = 1;

    private Text tText;
    private float timeLimit = 0f;
    private float origLimit = 0f;

    private void Start()
    {
        tText = gameObject.GetComponent<Text>();
        timeLimit = LevelManger.timeLimit;
        origLimit = LevelManger.timeLimit;
    }

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
        timeLimit = Mathf.Clamp(timeLimit, 0f, origLimit);

        if (timeLimit == 0)
        {
            LevelManger.faild = true;
        }

        float sec = (float)(timeLimit % 60);
        int min = (int)(timeLimit / 60) % 60;

        tText.text = string.Format("{1}.{0:0.00}", sec, min);
    }
}
