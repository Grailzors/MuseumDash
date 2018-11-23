using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeaverController : MonoBehaviour {

    public Sprite offSprite;
    public Sprite onSprite;
    public UnityEvent trigger;

    private bool isTriggered = false;


    //Remove for build
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        for (int i = 0; i < trigger.GetPersistentEventCount(); i++)
        {
            GameObject obj = GameObject.Find(trigger.GetPersistentTarget(i).name);
            if (obj != null)
            {
                Gizmos.DrawLine(transform.position, obj.transform.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && PlayerController.isGrabbing && !isTriggered)
        {
            trigger.Invoke();
            isTriggered = true;
            GetComponent<SpriteRenderer>().sprite = onSprite;
        }
    }
}
