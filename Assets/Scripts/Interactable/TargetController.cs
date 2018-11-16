using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    //public enum TargetType { Barrier, Switch, Explosive }

    public GameObject geo;

    private bool isExplode = false;

    public void ToggleBarrier()
    {
        if (geo.GetComponent<Renderer>().enabled == false)
        {
            geo.GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            geo.GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

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
