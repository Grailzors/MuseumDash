using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public PickUpData pickupDetails;

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

[System.Serializable]
public class PickUpData
{
    public enum PickUpType { Key = 0, Treasure = 1, Create = 2 }
    public enum PickUpColor { None = 0, Red = 1, Blue = 2, Green = 3 }

    [Header("PickUp Details")]
    public string pickupName = "";
    public int pickupNumCode = 0;
    public PickUpType pickupType;
    public PickUpColor pickupColor;
}

