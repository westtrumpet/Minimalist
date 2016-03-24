using UnityEngine;
using System.Collections;

public class CanvasResize : MonoBehaviour {

	void Start () {
		GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
	}

}
