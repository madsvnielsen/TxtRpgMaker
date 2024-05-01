using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNodeGroup : MonoBehaviour
{

    public DialogueNode nodePrefab;

    public Transform nodeGroup;
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

    }

    public void DeleteGroup(){
        Destroy(gameObject);
    }
}
