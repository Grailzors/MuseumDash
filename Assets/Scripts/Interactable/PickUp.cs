using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public PickUpData pickupDetails;

    private readonly GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - (transform.position + new Vector3(-1f, -1f, 0f));
    }

    private void Update()
    {
        //CarryCreate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 0.2f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    private void OnTriggerStay(Collider other)
    {
        //Pick Up item for inventory
        if (other.tag == "Player" && PlayerController.isGrabbing) //&& pickupDetails.pType != PickUpData.PickUpType.Create)
        {
            GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            other.gameObject.GetComponent<PlayerController>().PlayerCollect(gameObject);
        }
        
        /*
        //Pick up item for carrying
        if (other.tag == "Player" && PlayerController.isGrabbing && pickupDetails.pType == PickUpData.PickUpType.Create && !PlayerController.isCarrying)
        {
            player = other.gameObject;
            PlayerController.isCarrying = true;
        }
        else if (other.tag == "Player" && PlayerController.isGrabbing && pickupDetails.pType == PickUpData.PickUpType.Create && PlayerController.isCarrying)
        {
            PlayerController.isCarrying = false;
        } 
        */
    }

    /*
    void CarryCreate()
    {
        if (PlayerController.isCarrying)
        {
            transform.position = player.transform.position + offset;
        }
        else if (!PlayerController.isCarrying)
        {
            transform.position = transform.position;
        }
    }
    */
}

[System.Serializable]
public class PickUpData
{
    public enum PickUpType { Key = 0, Treasure = 1 }
    public enum PickUpColor { None = 0, Red = 1, Blue = 2, Green = 3 }

    [Header("PickUp Details")]
    public string pickupName = "";
    public int pickupNumCode = 0;
    public PickUpType pType;
    public PickUpColor pColor;
}

