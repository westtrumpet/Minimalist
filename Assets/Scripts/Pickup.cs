using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour{

	
	public string ColorType;
	public float PickupValue;

	SpriteRenderer sprite;

	string[] Colors = new string[3] {"Red", "Green", "Blue"};

	public int radius;
	public GameObject PickupPath; //Attach a path prefab to determine
	Path PickupMovement;
	public float speed;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		PickupPath = Instantiate( GameObject.Find("GameController").GetComponent<PathSelector>().getPath()) as GameObject;
		//PickupPath = GameObject.Find("GameController").GetComponent<PathSelector>().getPath();
		ColorType = Colors[Random.Range(0, 3)];
		PickupValue = Random.value;
		speed = PickupValue * 4;
		if (ColorType == "Red") {
			sprite.color = new Color(PickupValue, 0.0f, 0.0f, 1.0f);
		}
		if (ColorType == "Green") {
			sprite.color = new Color(0.0f, PickupValue, 0.0f, 1.0f);
		}
		if (ColorType == "Blue") {
			sprite.color = new Color(0.0f, 0.0f, PickupValue, 1.0f);
		}
		PickupMovement = PickupPath.GetComponent<Path>();
		PickupMovement.startPath();
		transform.position = new Vector3(PickupMovement.currentVertex.x, PickupMovement.currentVertex.y, 0.0f);
	}

	void FixedUpdate() {
		transform.Rotate(new Vector3(0.0f, 0.0f, speed));
		Move();
	}

	void Move() {
		if(WithinRange(PickupMovement.currentVertex)) {
			PickupMovement.nextVertex();
		}
		Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
		Vector2 movement = (PickupMovement.currentVertex - currentPos).normalized;
		movement *= speed;
		transform.Translate(movement.x, movement.y, 0.0f);
	}

	bool WithinRange(Vector2 vertex) {
		Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
		if((vertex-currentPos).magnitude <= radius) {
			return true;
		}
		else {
			return false;
		}
	}
}
