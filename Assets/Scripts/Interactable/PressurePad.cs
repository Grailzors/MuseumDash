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
            Gizmos.DrawLine(transform.position, obj.transform.position);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PressureItem" && !isTriggered)
        {
            trigger.Invoke();
            isTriggered = true;
        }

        /* TRYING TO MAKE IT WORK WITH PLAYER ASL WEEL TURNED OFF FOR NOW AS NOT IMPORTANT
        if (other.tag == "Player" && !isTriggered && !PlayerController.isCarrying)
        {
            trigger.Invoke();
            isTriggered = true;
            Debug.Log("Player No Box Enter");
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PressureItem" && isTriggered)
        {
            trigger.Invoke();
            isTriggered = false;
        }

        /* TRYING TO MAKE IT WORK WITH PLAYER ASL WEEL TURNED OFF FOR NOW AS NOT IMPORTANT
        if (other.tag == "Player" && isTriggered && PlayerController.isCarrying)
        {
            trigger.Invoke();
            isTriggered = false;
            Debug.Log("Player No Box Exit");
        }
        */
    }
}
