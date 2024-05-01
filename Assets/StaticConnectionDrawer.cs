using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticConnectionDrawer : MonoBehaviour
{
    public LineRenderer linePrefab;
    public void RedrawConnections(List<ActionButton> actionButtons){
        ClearLineRenderers();
        foreach(ActionButton ab in actionButtons){
            LineRenderer lr = Instantiate(linePrefab);
            lr.transform.SetParent(transform);
            Vector2 actionButtonScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, ab.transform.position);
            Vector2 actionButtonWorldPosition = Camera.main.ScreenToWorldPoint(actionButtonScreenPosition);
            Vector2 targetScreenpos = RectTransformUtility.WorldToScreenPoint(Camera.main, ab.dialogueAction.link.transform.position);
            Vector2 targetWorldpos = Camera.main.ScreenToWorldPoint(targetScreenpos);
            lr.SetPositions(new Vector3[]{actionButtonWorldPosition, targetWorldpos});
        }
        
    }

    void ClearLineRenderers(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
    }

}
