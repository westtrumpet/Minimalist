using UnityEngine;
using System.Collections;

public class CameraResize : MonoBehaviour {

	void Start() {
		GetComponent<Camera>().orthographicSize = Screen.height / 2;
	}
}
