using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour {

    public UnityEvent trigger;

    private bool isTriggered = false;


    //Remove for build
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (int i = 0; i < trigger.GetPersistentEventCount(); i++)
        {
            GameObject obj = GameObject.Find(trigger.GetPersistentTarget(i).name);
            if (obj != null)
            {
                Gizmos.DrawLine(transform.position, obj.transform.position);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PressureItem" && !isTriggered)
        {
            trigger.Invoke();
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PressureItem" && isTriggered)
        {
            trigger.Invoke();
            isTriggered = false;
        }
    }
}
