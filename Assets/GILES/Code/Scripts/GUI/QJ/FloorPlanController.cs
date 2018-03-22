using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlanController : MonoBehaviour {
    public QJGUI.Ruler ruler;
	// Use this for initialization
	void Start () {
        ruler.ShowUnit ();
	}

    private void Update () {
        float wheelAxis = Input.GetAxis ("Mouse ScrollWheel");
        if (wheelAxis < 0) { // back
            this.transform.localScale += Vector3.one * wheelAxis;
        } else if(wheelAxis > 0) { // forward
            this.transform.localScale += Vector3.one * wheelAxis;
        }
    }
}
