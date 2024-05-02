using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TopMenuController : MonoBehaviour
{
    public DialogueNodeTree tree;
    // Start is called before the first frame update
    public void SaveView(){
        string json = tree.SaveView();
        string saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TextRPG");
        string filePath = Path.Combine(saveDirectory, "out.json");

        // Ensure the directory exists, create it if it doesn't
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to: " + filePath);
    }
}
