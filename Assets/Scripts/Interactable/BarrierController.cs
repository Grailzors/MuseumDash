using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour {

    public GameObject geo;
    public int inputNum;
    public SwitcherController switcher;
    public bool isSwitch;


    private void Awake()
    {
        isSwitch = false;
    }

    public void SwitchBarrier()
    {
        if (geo.GetComponent<Renderer>().enabled == false && !isSwitch || switcher != null && inputNum == switcher.outputNum)
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
}
