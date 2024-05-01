using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNodeTree : MonoBehaviour
{
    public DialogueNode entry;

    public DialogueNodeGroup dialogueNodeGroupPrefab;

    public void AddNodeGroup(){
        DialogueNodeGroup newDng = Instantiate(dialogueNodeGroupPrefab);
        newDng.transform.SetParent(this.transform);
        newDng.transform.localScale = new Vector3(1,1,1);
    }
   
}
