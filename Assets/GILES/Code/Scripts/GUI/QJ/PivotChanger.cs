using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PivotChanger : MonoBehaviour, IPointerClickHandler {
    //public Camera uiCamera;
    public RectTransform pivotIndicator;
    private RectTransform rectTransform;

    public void OnPointerClick (PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Right) {
            Vector2 pos = eventData.position;
            Debug.Log (pos.ToString());
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, pos, eventData.pressEventCamera, out localPoint);
            //RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, pos, null, out localPoint);
            Debug.Log ("localPoint: " + localPoint.ToString ());
            
            Vector2 pivot = Rect.PointToNormalized (rectTransform.rect, localPoint);
            Debug.Log ("Pivot: " + pivot.ToString());

            Vector2 size = rectTransform.rect.size;
            Vector2 deltaPivot = rectTransform.pivot - pivot;
            Vector3 deltaPosition = new Vector3 (deltaPivot.x * size.x, deltaPivot.y * size.y);
            rectTransform.pivot = pivot;
            rectTransform.localPosition -= deltaPosition;
            
            pivotIndicator.position = rectTransform.position;
        }
    }

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
        pivotIndicator.position = rectTransform.position;
    }
}
