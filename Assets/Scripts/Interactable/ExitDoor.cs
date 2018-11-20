using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    [Header("Door Requirments")]
    public List<GameObject> requiredKeys;

    private bool gotKeys;


    private void Start()
    {
        gotKeys = false;    
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0.3f, 0.2f);
        Gizmos.DrawCube(transform.GetChild(0).position, new Vector3(1.3f, 2.3f, 1.3f));

        foreach(GameObject k in requiredKeys)
        {
            Gizmos.color = new Color(0f, 0f, 1f);
            Gizmos.DrawLine(transform.position, k.transform.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CheckPlayerInventory(other);
        }
    }
    

    void CheckPlayerInventory(Collider other)
    {
        List<GameObject> inv = other.gameObject.GetComponent<PlayerController>().inventory;
        int num = 0;
        
        for (int i = 0; i < requiredKeys.Count; i++)
        {
            for (int key = 0; key < inv.Count; key++)
            {
                if (requiredKeys[i] == inv[key])
                {
                    num += 1;
                }
            }
        }

        if (num == requiredKeys.Count)
        {
            print("All Keys Collected");
            gotKeys = true;
            LevelManger.complete = true;
            GameManager.LoadNextLevel();
        }
        else
        {
            print("Missing Items");
        }
    }
}
