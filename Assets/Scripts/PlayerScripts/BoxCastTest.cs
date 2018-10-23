using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest : MonoBehaviour {


    private RaycastHit hit;
    private bool hitDetect;
    private int mask;

    private void Start()
    {
        mask = 1 << 9;
    }

    private void OnDrawGizmos()
    {
        

        Gizmos.color = Color.red;
        if (hitDetect)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + Vector3.down * hit.distance, transform.localScale/1.3f);
        }
        else
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale/1.3f);
        }

    }

    private void FixedUpdate()
    {
        
        hitDetect = Physics.BoxCast(transform.position * 0.5f, transform.localScale/1.3f, Vector3.down, out hit, transform.rotation, 0.5f, mask);
        
        if(hitDetect)
        {
            print("HIT: " + hit.collider.name);
        }

    }
}
