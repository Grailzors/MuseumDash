using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Movement Controlls")]
    public float moveSpeed = 5f;
    public float jumpStrength = 2f;

    [Header("Player Data")]
    public List<GameObject> inventory;

    public static bool isGrabbing;

    private float h;
    private bool isFalling;
    private Rigidbody playerRb;
    

    private void Start()
    {
        isGrabbing = false;
        isFalling = true;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        PlayerMove();   
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.4f);
        Gizmos.DrawCube(transform.GetChild(0).position, new Vector3(1, 1, 1));
    }


    private void OnCollisionEnter(Collision collision)
    {
        isFalling = false;
    }


    void PlayerMove()
    {
        h = Input.GetAxis("Horizontal");

        transform.position += new Vector3((h * Time.deltaTime) * moveSpeed, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space) == true && isFalling == false)
        {
            print("Jump");
            playerRb.AddForce(0f, jumpStrength, 0f);
            isFalling = true;
        }
    }

    void PlayerInteract()
    {

    }

    public void PlayerCollect(GameObject obj)
    {
        inventory.Add(obj);
    }
}