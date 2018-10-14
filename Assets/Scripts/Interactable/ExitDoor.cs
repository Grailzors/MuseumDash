using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0.3f, 0.2f);
        Gizmos.DrawCube(transform.GetChild(0).position, new Vector3(1.3f, 2.3f, 1.3f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Next Level Loading");
        }
    }
}
