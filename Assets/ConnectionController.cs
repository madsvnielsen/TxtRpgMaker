using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionController : MonoBehaviour
{
    public ActionButton firstActionButton = null;

    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    public void StartConnection(ActionButton startButton){
        firstActionButton = startButton;
       
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)){
            CancelConnection();
        }

        if(firstActionButton != null){
            lineRenderer.positionCount = 2;
            Vector2 actionButtonScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, firstActionButton.transform.position);
            Vector2 actionButtonWorldPosition = Camera.main.ScreenToWorldPoint(actionButtonScreenPosition);
            Vector2 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPositions(new Vector3[]{actionButtonWorldPosition, mousePosition});
        }
    }

    void CancelConnection(){
        firstActionButton = null;
        lineRenderer.positionCount = 0;
    }

    public bool TryFinishConnection(DialogueNode target){
        if(firstActionButton != null){
            firstActionButton.dialogueAction.link = target;
            CancelConnection();
            return true;
        }
        return false;
    }
}
