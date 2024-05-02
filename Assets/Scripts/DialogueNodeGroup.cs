using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNodeGroupData{
    public string id;
    public string nodes;
}
public class DialogueNodeGroup : MonoBehaviour
{

    public DialogueNode nodePrefab;

    public Transform nodeGroup;

    public string id = "0";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNode(){
        DialogueNode newNode = Instantiate(nodePrefab);
        newNode.transform.SetParent(nodeGroup);
        newNode.transform.localScale = new Vector3(1,1,1);
        nodePrefab.id = System.Guid.NewGuid().ToString();

    }

    public void DeleteGroup(){
        Destroy(gameObject);
    }

    public string SerializeNodeGroup(){
        return JsonUtility.ToJson(new DialogueNodeGroupData{
            id = id,
            nodes = SerializeChildNodes()
        });

    }

    private string SerializeChildNodes(){
        DialogueNode[] childNodes = transform.GetComponentsInChildren<DialogueNode>();
        string[] serializedNodes = new string[childNodes.Length];
        for(int i = 0; i < childNodes.Length; i++){
            serializedNodes[i] = childNodes[i].id;
        }
        return "[" + string.Join(",", serializedNodes) + "]";
    }
}
