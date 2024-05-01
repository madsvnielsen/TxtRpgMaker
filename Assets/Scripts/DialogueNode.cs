using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueNode : MonoBehaviour
{

    public string dialogueHeader = "Untitled";
    public string dialogueText = "";
    public List<DialogueAction> dialogueActions;

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

    void drawNode(){
        ClearActionButtons();
        headerTxt.SetText(dialogueHeader);
        DrawActionButtons();
       

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

   
}
