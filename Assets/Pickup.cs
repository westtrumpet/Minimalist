using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour{

	public string ColorType;
	public float PickupValue;

	SpriteRenderer sprite;

	string[] Colors = new string[3] {"Red", "Green", "Blue"};

	public GameObject PickupPath; //Attach a path prefab to determine
	public float speed;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
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
	}

	void FixedUpdate() {
		transform.Rotate(new Vector3(0.0f, 0.0f, speed));
	}
}
