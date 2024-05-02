using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InspectorController : MonoBehaviour
{

    public GameObject editContentContainer;
    public Transform editActionsTransform;

    public EditAction editActionPrefab;

    public DialogueNode selectedNode = null;

    public TMP_Text headerText;
    public TMP_InputField titleInput;
    public TMP_InputField textInput;
    // Start is called before the first frame update
    void Start()
    {
        editContentContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNode(DialogueNode dialogueNode){
        selectedNode = dialogueNode;
        editContentContainer.SetActive(!dialogueNode.isStartNode);
        headerText.SetText(dialogueNode.dialogueHeader);
        titleInput.text = dialogueNode.dialogueHeader;
        textInput.text = dialogueNode.dialogueText;
        DrawEditActions();
    }

    private void DrawEditActions(){
        foreach(Transform child in editActionsTransform){
            Destroy(child.gameObject);
        }
        int index = 1;
        foreach(DialogueAction dialogueAction in selectedNode.dialogueActions){
            EditAction newEditAction = Instantiate(editActionPrefab);
            newEditAction.transform.SetParent(editActionsTransform);
            newEditAction.dialogueAction = dialogueAction;
            newEditAction.transform.localScale = new Vector3(1,1,1);
            newEditAction.id = index++.ToString();
        }

    }

    public void AddAction(){
        selectedNode.AddAction(new DialogueAction());
        DrawEditActions();
    }

    public void UpdateTitle(string newValue){
        headerText.SetText(newValue);
        selectedNode.dialogueHeader = newValue;
        selectedNode.drawNode();
    }

    public void UpdateText(string newValue){
        selectedNode.dialogueText = newValue;
    }

    public void DeleteActionFromNode(DialogueAction action){
        selectedNode.dialogueActions.Remove(action);
        selectedNode.drawNode();
    }
}
