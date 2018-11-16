using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour {

    public LevelDescription ld;
    public float timeLimit;


    private void OnEnable()
    {
        timeLimit = ld.timeLimit;
    }


}
