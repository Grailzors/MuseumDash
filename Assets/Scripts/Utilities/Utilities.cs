using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour {

    //Parents GameObject Function
    [MenuItem("GameObject/Matt Utils/ParentObject %g", false, 10)]
    static void ParentObject()
    {
        GameObject group;

        if (GameObject.Find("Grouped Objects") == null)
        {
            group = new GameObject
            {
                name = "Grouped Objects"
            };

            foreach (GameObject i in Selection.gameObjects)
            {
                i.transform.parent = group.transform;
            }
        }
    }

    //Create Project Directories Functions
    static Dictionary<string, string> ProjectPaths()
    {
        string root = Application.dataPath + "/";

        Dictionary<string, string> pathDict = new Dictionary<string, string>
        {
            { "Materials", root + "Materials" },
            { "Models", root + "Models" },
            { "Resources", root + "Resources" },
            { "Scripts", root + "Scripts" },
            { "Audio", root + "Resources/Audio" },
            { "Prefabs", root + "Resources/Prefabs" },
            { "Textures", root + "Resources/Textures" },
            { "Fonts", root + "Resources/Fonts" },
            { "Sprites", root + "Resources/Sprites" },
            { "ScriptableObjects", root + "Resources/ScriptableObjects" },
        };

        return pathDict;
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Whole Dir", false, 100)]
    static void CreateProjectDirectory()
    {
        foreach (KeyValuePair<string, string> entry in ProjectPaths())
        {
            if (!Directory.Exists(entry.Value))
            {
                Directory.CreateDirectory(entry.Value);
                System.IO.File.WriteAllText(entry.Value + "/placeholder.txt", " ");
            }
            else
            {
                Debug.Log(entry.Key + " : Folder already exists");
            }
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Materials" , false, 111)]
    static void MaterialDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Materails"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Materails"]);
            System.IO.File.WriteAllText(ProjectPaths()["Materails"] + "/placeholder.txt", " ");
        }
        
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Models", false, 111)]
    static void ModelDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Models"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Models"]);
            System.IO.File.WriteAllText(ProjectPaths()["Models"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Resources", false, 111)]
    static void ResourcesDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Resources"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Resources"]);

            System.IO.File.WriteAllText(ProjectPaths()["Resources"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Scripts", false, 111)]
    static void ScriptsDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Scripts"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Scripts"]);
            System.IO.File.WriteAllText(ProjectPaths()["Scripts"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Audio", false, 111)]
    static void AudioDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Audio"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Audio"]);
            System.IO.File.WriteAllText(ProjectPaths()["Audio"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Prefabs", false, 111)]
    static void PrefabsDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Prefabs"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Prefabs"]);
            System.IO.File.WriteAllText(ProjectPaths()["Prefabs"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Textures", false, 111)]
    static void TexturesDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Textures"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Textures"]);
            System.IO.File.WriteAllText(ProjectPaths()["Textures"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Fonts", false, 111)]
    static void FontsDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Fonts"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Fonts"]);
            System.IO.File.WriteAllText(ProjectPaths()["Fonts"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/Sprites", false, 111)]
    static void SpritesDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["Sprites"]))
        {
            Directory.CreateDirectory(ProjectPaths()["Sprites"]);
            System.IO.File.WriteAllText(ProjectPaths()["Sprites"] + "/placeholder.txt", " ");
        }
    }

    [MenuItem("Assets/Matt Utils/Create Directory/ScriptableObjects", false, 111)]
    static void ScriptableObjectsDirectory()
    {
        if (!Directory.Exists(ProjectPaths()["ScriptableObjects"]))
        {
            Directory.CreateDirectory(ProjectPaths()["ScriptableObjects"]);
            System.IO.File.WriteAllText(ProjectPaths()["ScriptableObjects"] + "/placeholder.txt", " ");
        }
    }

    //Other functions to come
    [MenuItem("Matt Utils/DebugTools/Print Current Scene %q", false, 0)]
    static void PrintCurrentScene()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
