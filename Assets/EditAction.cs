using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EditAction : MonoBehaviour
{
    public DialogueAction dialogueAction;
    // Start is called before the first frame update
    public string id = "0";

    public TMP_Text idText;
    public TMP_InputField textInput;
    


    public void Start(){
        idText.SetText(id);
        textInput.text = dialogueAction.actionText;
        
    }
    public void SetActionText(string newValue){
        dialogueAction.actionText = newValue;
    }

    public void DeleteAction(){
        GetComponentInParent<InspectorController>().DeleteActionFromNode(dialogueAction);
        Destroy(gameObject);
    }
}
