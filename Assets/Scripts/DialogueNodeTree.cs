using System.Collections;
using System.Collections.Generic;
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
   
}
