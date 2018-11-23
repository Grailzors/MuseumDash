using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitcherController : MonoBehaviour {

    public UnityEvent outputs;
    public int outputNum;
    public bool isPowered;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < outputs.GetPersistentEventCount(); i++)
        {
            GameObject obj = GameObject.Find(outputs.GetPersistentTarget(i).name);
            if (obj != null)
            {
                Gizmos.DrawLine(transform.position, obj.transform.position);
            }
        }
    }

    private void Awake()
    {
        isPowered = false;
    }

    private void Start()
    {
        outputNum = 0;

        for (int i = 0; i < outputs.GetPersistentEventCount(); i++)
        {
            GameObject obj = GameObject.Find(outputs.GetPersistentTarget(i).name);
            obj.GetComponent<BarrierController>().inputNum = i;
            obj.GetComponent<BarrierController>().switcher = gameObject.GetComponent<SwitcherController>();
            obj.GetComponent<BarrierController>().isSwitch = true;
        }

        outputs.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (isPowered)
            {
                outputNum++;

                if (outputNum > outputs.GetPersistentEventCount() - 1)
                {
                    outputNum = 0;
                }

                //Debug.Log(outputNum);
                outputs.Invoke();
            }
        }
    }

    public void PowerOn()
    {
        isPowered = true;
    }
}
