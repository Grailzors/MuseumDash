using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

    public float radius = 1f;

    private void OnDrawGizmos()
    {
        GameObject exit = GameObject.FindGameObjectWithTag("Finish");

        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, radius);

        Gizmos.color = new Color(1f, 0.5f, 0f);
        Gizmos.DrawLine(transform.position, exit.transform.position);
    }
}
