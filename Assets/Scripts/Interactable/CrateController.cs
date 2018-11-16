using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private int d = 1;

    private void LateUpdate()
    {
        CarryCreate();
    }

    private void OnTriggerStay(Collider other)
    {
        //Pick up item for carrying
        if (other.tag == "Player" && PlayerController.isGrabbing && !PlayerController.isCarrying)
        {
            player = other.gameObject;
            PlayerController.isCarrying = true;
        }
        else if (other.tag == "Player" && PlayerController.isGrabbing && PlayerController.isCarrying)
        {
            PlayerController.isCarrying = false;
        }
    }

    void CarryCreate()
    {
        Vector3 offset = transform.position - (transform.position + new Vector3(PlayerFacingDirection(), -1f, 0f));

        if (PlayerController.isCarrying)
        {
            transform.position = player.transform.position + offset;
        }
        else if (!PlayerController.isCarrying)
        {
            transform.position = transform.position;
        }
    }

    int PlayerFacingDirection()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            d = -1;
        }
        else if (h < 0)
        {
            d = 1;
        }

        return d;
    }

}
