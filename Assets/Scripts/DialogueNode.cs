using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

[System.Serializable]
public class DialogueNodeData{
    public string dialogueHeader;
    public string dialogueText;
    public bool isStartNode;
    public string id;

    public string serializedDialogueActions;
}

public class DialogueNode : MonoBehaviour
{

    public string dialogueHeader = "Untitled";
    public string dialogueText = "";
    public List<DialogueAction> dialogueActions;

    public string id = "0";

    public bool isStartNode = false;

    public RectTransform actionButtonsTransform;

    public ActionButton actionButtonPrefab;

    public TMP_Text headerTxt;


    
    // Start is called before the first frame update
    void Start()
    {
        dialogueActions = new List<DialogueAction>();
        if(isStartNode){
            dialogueActions.Add(new DialogueAction());
        }
        drawNode();
    }

    public void drawNode(){
        ClearActionButtons();
        headerTxt.SetText(dialogueHeader);
        DrawActionButtons();
       

    }

    public void AddAction(DialogueAction newAction){
        dialogueActions.Add(newAction);
        drawNode();
    }

    private void ClearActionButtons(){
        foreach(Transform child in actionButtonsTransform){
            Destroy(child.gameObject);
        }
    }

    private void DrawActionButtons(){
         for (int i = 0; i < dialogueActions.Count; i++) {
            DialogueAction dialogueAction = dialogueActions[i];
            ActionButton newButton = Instantiate(actionButtonPrefab);
            newButton.transform.SetParent(actionButtonsTransform);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.dialogueAction = dialogueAction;
            newButton.SetText((i + 1).ToString());
        }
    }

    public void SelectNode(){
        InspectorController ic = GameObject.FindWithTag("IC").GetComponent<InspectorController>();
        ConnectionController cc = GameObject.FindWithTag("CC").GetComponent<ConnectionController>();
        if(!cc.TryFinishConnection(this)){
            ic.SelectNode(this);
        } 
        
    }

    public void InitializeConnection(ActionButton actionButton){
        ConnectionController cc = GameObject.FindWithTag("CC").GetComponent<ConnectionController>();
        cc.StartConnection(actionButton);
    }

    public string SerializeNodeData()
    {
       
        DialogueNodeData data = new DialogueNodeData
        {
            dialogueHeader = dialogueHeader,
            dialogueText = dialogueText,
            isStartNode = isStartNode,
            id = id,
            serializedDialogueActions = SerializedDialogueActions()
        };
        return JsonUtility.ToJson(data);
    }

    private string SerializedDialogueActions(){
        string[] serializedActions = new string[dialogueActions.Count];
        for(int i = 0; i < dialogueActions.Count; i++){
            serializedActions[i] = dialogueActions[i].SerializeDialogueAction();
        }
        return "[" + String.Join(",", serializedActions) + "]";
    }

   
}
