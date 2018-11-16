using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour {

    public LevelDescription ld;
    [Space]
    public float timeLimit;
    public string[] dialouge;
    public string[] npcDialouge;


    private void OnEnable()
    {
        timeLimit = ld.timeLimit;
        dialouge = ld.dialouge;
        npcDialouge = ld.npcDialouge;
    }


}
