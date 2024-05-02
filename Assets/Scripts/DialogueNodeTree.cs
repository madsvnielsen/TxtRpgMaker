using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueNodeTree : MonoBehaviour
{
    public DialogueNode entry;

    public DialogueNodeGroup dialogueNodeGroupPrefab;

    void Update(){
        RefreshConnections();
    }

    public void AddNodeGroup(){
        DialogueNodeGroup newDng = Instantiate(dialogueNodeGroupPrefab);
        newDng.transform.SetParent(this.transform);
        newDng.transform.localScale = new Vector3(1,1,1);
        newDng.id = System.Guid.NewGuid().ToString();
        RefreshConnections();
    }

    private void RefreshConnections(){
        List<ActionButton> connectedActions = new List<ActionButton>();
        foreach(ActionButton ab in GetComponentsInChildren<ActionButton>()){
            if(ab.dialogueAction.link != null){
                connectedActions.Add(ab);
            }
        }
        GameObject.FindWithTag("SCD").GetComponent<StaticConnectionDrawer>().RedrawConnections(connectedActions);
        
    }

    public string SerializeTreeToJson(){
       DialogueNode[] nodes = GetComponentsInChildren<DialogueNode>();
       string[] nodeSerialization = new string[nodes.Length];
        for(int i = 0; i < nodes.Length; i++){
            nodeSerialization[i] = nodes[i].SerializeNodeData();
        }
        return "["+String.Join(",", nodeSerialization)+"]";
    }

    public string SerializeGroups(){
       DialogueNodeGroup[] groups = GetComponentsInChildren<DialogueNodeGroup>();
       string[] groupSerialization = new string[groups.Length];
        for(int i = 0; i < groups.Length; i++){
            groupSerialization[i] = groups[i].SerializeNodeGroup();
        }
        return "["+String.Join(",", groupSerialization)+"]";
    }

    public string SaveView(){
        string treeJson = SerializeTreeToJson();
        string groupJson = SerializeGroups();
        return "{ \"groups\":"+groupJson + ", \"nodes\":" + treeJson + "}";
    }

   
}
