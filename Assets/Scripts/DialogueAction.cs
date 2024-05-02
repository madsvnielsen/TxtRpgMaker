using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueActionData{

    public string actionText;
    public string link;

}
public class DialogueAction 
{
    public string actionText;
    public DialogueNode link;
    

    public string SerializeDialogueAction(){
        
        DialogueActionData data = new DialogueActionData{
            actionText = actionText,
            link = null
        };

        if(link != null){
            data.link = link.id;   
        }
        return JsonUtility.ToJson(data);
    }

}
