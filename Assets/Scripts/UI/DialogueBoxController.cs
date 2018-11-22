using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueBoxController : MonoBehaviour {

    public Text dName;
    public Text dDialogue;

    public static int dialogueNum = -1;

    private void Start()
    {
        dName.text = " ";
        dDialogue.text = " ";
    }

    public void CycleDialogue()
    {
        if (LevelManger.dialogue.Length > 0)
        {
            dialogueNum++;
            dialogueNum = Mathf.Clamp(dialogueNum, -1, LevelManger.dialogue.Length - 1);

            dName.text = LevelManger.dialogue[dialogueNum].name;
            dDialogue.text = LevelManger.dialogue[dialogueNum].dialogue;
        }
    }
}
