using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Movement Controlls")]
    public float moveSpeed = 5f;
    public float maxJumpHeight = 2f;
    public float initalJumpStrength = 2f;
    public float addJumpStrength = 1f;

    [Header("Player Data")]
    public List<GameObject> inventory;

    public static bool isGrabbing;
    public static int keys;

    private float h;
    private float jumpCounter = 0f;
    private bool isFalling;
    public bool isJumping;
    private bool maxedJump;
    private Rigidbody playerRb;
    

    private void Start()
    {
        isGrabbing = false;
        isFalling = true;
        isJumping = false;
        maxedJump = false;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        PlayerMove();

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

    private void FixedUpdate()
    {
        //PlayerMove();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.4f);
        Gizmos.DrawCube(transform.GetChild(0).position, new Vector3(1, 1, 1));
    }


    private void OnCollisionEnter(Collision collision)
    {
        isFalling = false;
        //isJumping = false;
    }


    void PlayerMove()
    {
        RaycastHit hit;
        h = Input.GetAxis("Horizontal");

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * maxJumpHeight, Color.yellow);

        //Player horizontal movement
        transform.position += new Vector3((h * Time.deltaTime) * moveSpeed, 0f, 0f);

        //Jump movement
        if (Input.GetKeyDown(KeyCode.Space) == true && isFalling == false)
        {
            print("Jump");
            playerRb.AddForce(0f, initalJumpStrength * 100, 0f);
            isFalling = true;
            isJumping = true;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        //Control the height of the jump while button is held down
        //NOT WORKING WIERD FLOATY
        if (Input.GetKey(KeyCode.Space) == true && isJumping == true)
        {            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, maxJumpHeight))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * maxJumpHeight, Color.green);
                playerRb.AddForce(0f, addJumpStrength * 10, 0f);
                print("ADDING FORCE UP");
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, maxJumpHeight * 1.1f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * maxJumpHeight * 1.1f, Color.red);
                print("NOT HITTING");
                isJumping = false;
            }
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
        int typeValue = (int)obj.GetComponent<PickUp>().pickupDetails.pickupType;
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
        }
    }
}