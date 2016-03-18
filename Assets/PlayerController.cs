using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	public bool isMobile = false;
	public float forceMult;
	public bool DebugOn = false;

	Rigidbody2D PlayerPhysics;
	Vector2 cursorStart;
	Vector2 cursorEnd;
	bool inputStarted = false;
	

	void Start() {
		PlayerPhysics = Player.GetComponent<Rigidbody2D>();
		if(isMobile){
			Input.multiTouchEnabled = false;
		}
	}

	void Update() {
		if(InputBegun()){
			if(DebugOn) Debug.Log("Click");
			inputStarted = true;
			cursorStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		else {
			if(inputStarted) {
				if(InputEnded()){
					inputStarted = false;
					cursorEnd = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
					ApplyForce(getInputDrag());
					if(DebugOn) Debug.Log("Input: " + getInputDrag().x + ", " + getInputDrag().y);
				}
			}
		}
	}

	void FixedUpdate() {
		
	}

	bool InputBegun() {
		if(isMobile) {
			return false;
		}
		else{
			return Input.GetMouseButtonDown(0);
		}
	}

	bool InputEnded() {
		if(isMobile) {
			return true;
		}
		else {
			return Input.GetMouseButtonUp(0);
		}
	}

	Vector2 getInputDrag () {
		return cursorEnd - cursorStart;
	}

	void ApplyForce(Vector2 inputDrag) {
		PlayerPhysics.velocity = forceMult * inputDrag;
	}
}
