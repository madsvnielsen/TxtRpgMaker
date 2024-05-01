using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public DialogueAction dialogueAction;
    public TMP_Text actionLabel;

    public void SetText(string newText){
        actionLabel.SetText(newText);
    }

}
