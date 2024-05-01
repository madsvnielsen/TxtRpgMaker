using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InspectorController : MonoBehaviour
{

    public GameObject editContentContainer;

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
    }

    public void UpdateTitle(string newValue){
        headerText.SetText(newValue);
        selectedNode.dialogueHeader = newValue;
        selectedNode.drawNode();
    }

    public void UpdateText(string newValue){
        selectedNode.dialogueText = newValue;
    }
}
