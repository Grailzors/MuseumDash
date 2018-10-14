using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public enum PickUpType {Key, Treasure, Create}
    public enum PickUpColor { Red, Blue, Green, None}

    [Header("PickUp Info")]
    public PickUpType pickupType;
    public PickUpColor pickupColor;

    private bool isCollected;

    private void Start()
    {
        isCollected = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 0.2f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && PlayerController.isGrabbing == true)
        {
            isCollected = true;
            GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            other.gameObject.GetComponent<PlayerController>().PlayerCollect(gameObject);

        }
    }

}
