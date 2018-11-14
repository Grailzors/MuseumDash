using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Utilities : MonoBehaviour {

    //private GameObject group;

    [MenuItem("GameObject/MattUtils/ParentObject", false, 10)]
    static void ParentObject()
    {
        GameObject group;

        if (GameObject.Find("Group_1") == null)
        {
            group = new GameObject();
            group.name = "Group_1";

            foreach (GameObject i in Selection.gameObjects)
            {
                Debug.Log(i.name);
                i.transform.parent = group.transform;
            }
        }
    }









}
