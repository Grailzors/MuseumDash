using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class BoxCastTest : MonoBehaviour {

    public float rayOffset = 0f;
    public float maxDistance = 0.7f;

    Vector3 pos;
    RaycastHit hit;
    bool hitDetect;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (hitDetect)
        {
            Gizmos.color = Color.green;

            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(pos, transform.up * -1 * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(pos + transform.up * -1 * hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(pos, transform.up * -1 * maxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(pos + transform.up * -1 * maxDistance, transform.localScale);
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.up * -1;
        pos = transform.position + new Vector3(0f, rayOffset, 0f);

        hitDetect = Physics.BoxCast(pos, transform.localScale, dir, out hit, transform.rotation, maxDistance);

        if (hitDetect)
        {
            Debug.Log("Grounded : " + hit.collider.name);
        }
        else
        {
            Debug.Log("Jumping");
        }

    }



    /*
    float m_MaxDistance;
    float m_Speed;
    bool m_HitDetect;

    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        //Choose the distance the Box can reach to
        m_MaxDistance = 300.0f;
        m_Speed = 20.0f;
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        //Simple movement in x and z axes
        float xAxis = Input.GetAxis("Horizontal") * m_Speed;
        float zAxis = Input.GetAxis("Vertical") * m_Speed;
        transform.Translate(new Vector3(xAxis, 0, zAxis));

        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.up*-1, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + m_Hit.collider.name);
        }


    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.up * -1 * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.up * -1 * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.up * -1 * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.up * -1 * m_MaxDistance, transform.localScale);
        }
    }
    */
}
