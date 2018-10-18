using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Movement Controlls")]
    public float moveSpeed = 5f;
    public float initalJumpStrength = 2f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    /*
    public float maxJumpHeight = 2f;
    
    public float addJumpStrength = 1f;
    */

    [Header("Player Data")]
    public List<GameObject> inventory;

    public static bool isGrabbing;
    public static int keys;

    private float h;
    private float jumpCounter = 0f;
    private bool isFalling;
    public bool isJumping;
    private bool maxedJump;
    private Rigidbody rb;
    

    private void Start()
    {
        isGrabbing = false;
        isFalling = true;
        isJumping = false;
        maxedJump = false;
        rb = GetComponent<Rigidbody>();
    }

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
        
        h = Input.GetAxis("Horizontal");

        //Player horizontal movement
        transform.position += new Vector3((h * Time.deltaTime) * moveSpeed, 0f, 0f);

        //Physics jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Jump");
            rb.AddForce(0f, initalJumpStrength * 100, 0f);
            //isFalling = true;
            //isJumping = true;
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


        //RAYCAST JUMP MOVEMENT
        /*
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * maxJumpHeight, Color.yellow);

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
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
                playerRb.AddForce(0f, addJumpStrength * 10, 0f);
                print("ADDING FORCE UP");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * maxJumpHeight, Color.red);
                print("NOT HITTING");
                //isJumping = false;
            }
        }
        */
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