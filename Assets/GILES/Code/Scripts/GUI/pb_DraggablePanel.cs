using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using GILES;

namespace GILES.Interface
{
	public class pb_DraggablePanel : MonoBehaviour, IBeginDragHandler, IDragHandler
	{
        public bool isWorldSpace = false;
        public bool isFloorPlan = false;

		Rect screenRect = new Rect(0,0,0,0);

		/// The root gameobject of this window.
		public RectTransform windowParent;

		public void OnBeginDrag(PointerEventData eventData)
		{
			screenRect.width = Screen.width;
			screenRect.height = Screen.height;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if(windowParent == null)
			{
				Debug.LogWarning("Window parent is null, cannot drag a null window.");
				return;
			}

            if (isWorldSpace) {
                if (screenRect.Contains (eventData.position))
                    windowParent.position += new Vector3(eventData.delta.x, 0, eventData.delta.y);
                if(isFloorPlan) {
                    //var rectTransform = this.gameObject.GetComponent<RectTransform> ();
                    //Vector2 origin = this.transform.parent.GetComponent<QJGUI.Ruler> ().origin;
                    //Debug.Log ("Ruler origin: " + origin.ToString());
                    //rectTransform.pivot = origin;
                }
            }
            else {
                if (screenRect.Contains (eventData.position))
                    windowParent.position += (Vector3)eventData.delta;
            }
		}
	}
}
