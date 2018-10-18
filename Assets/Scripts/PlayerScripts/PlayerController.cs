﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Movement Controlls")]
    public float moveSpeed = 5f;
    public float initalJumpStrength = 2f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Player Data")]
    public List<GameObject> inventory;

    public static bool isGrabbing;
    public static bool isCarrying;
    public static int keys;

    private Rigidbody rb;
    private float h;
    private bool isHolding;
    private bool isJumping;
    
    

    private void Start()
    {
        isGrabbing = false;
        isCarrying = false;
        isJumping = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        PlayerMove();

        print(isCarrying);

        if (inventory.Count > 0)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                PickUp obj = inventory[i].GetComponent<PickUp>();
                //print(obj.pickupName + " " + obj.pickupNumCode + " " + obj.pickupType + " " + obj.pickupColor);
            }
        }
    }

    private void LateUpdate()
    {
        PlayerInteract();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.4f);
        Gizmos.DrawCube(transform.GetChild(0).position, new Vector3(1, 1, 1));
    }

    void PlayerMove()
    {
        
        h = Input.GetAxis("Horizontal");

        //Player horizontal movement
        transform.position += new Vector3((h * Time.deltaTime) * moveSpeed, 0f, 0f);

        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            print("Jump");
            rb.AddForce(0f, initalJumpStrength * 100, 0f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
        }

        if (rb.velocity.y < 0)
        {
            //(fallMultiplier - 1) this is minus 1 to mimic how unity is all ready applying physics to 
            //an object
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }

    void PlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isGrabbing = true;
        }
        else
        {
            isGrabbing = false;
        }
    }

    public void PlayerCollect(GameObject obj)
    {
        //Convert the enum to its int value for switch
        int typeValue = (int)obj.GetComponent<PickUp>().pickupDetails.pType;
        GameObject gm = GameObject.FindGameObjectWithTag("GM");

        switch (typeValue)
        {
            case 2:
                print("Got Box");
                break;
            case 1:
                gm.GetComponent<GameManager>().treasureCollected.Add(obj);
                inventory.Add(obj);
                obj.transform.SetParent(gm.transform);
                print("Collected: " + obj.GetComponent<PickUp>().pickupDetails.pickupName);
                break;
            case 0:
                print("Collected: " + obj.GetComponent<PickUp>().pickupDetails.pickupName);
                inventory.Add(obj);
                break;
            default:
                break;
        }
    }
}