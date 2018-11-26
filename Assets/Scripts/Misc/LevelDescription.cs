using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Description", menuName = "Level Description")]
public class LevelDescription : ScriptableObject {

    [Header("Components")]
    public GameObject player;
    public Camera mainCam;

    [Header("Game Controls")]
    public TimeLimit timeLimit;
    public Dialogue[] dialogue;

    [Header("Camera Controls")]
    public float camSize;
}


[System.Serializable]
public struct Dialogue {

    public string name;
    [TextArea(0,800)]
    public string dialogue;
}

[System.Serializable]
public struct TimeLimit
{
    [Range(0, 60)]
    public float min, sec;
}