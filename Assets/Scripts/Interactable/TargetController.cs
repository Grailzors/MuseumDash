using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour {


    private bool isExplode = false;

    public void SetSwitch()
    {
        //Have this trigger animation of doors etc
        gameObject.SetActive(false);
    }

    public void Explode()
    {
        if (!isExplode)
        {
            //Here needs to be the thing that plays the particle effect
            //and removes the obstacle 
            isExplode = true;
        }
    }
}
