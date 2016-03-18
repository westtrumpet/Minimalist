using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour{

	public string ColorType;
	public float PickupValue;
	public bool PickedUp = false;

	SpriteRenderer sprite;

	string[] Colors = new string[3] {"Red", "Green", "Blue"};

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		ColorType = Colors[Random.Range(0, 3)];
		PickupValue = Random.value;
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

	void OnTriggerEnter() {
		PickedUp = true;
	}
}
