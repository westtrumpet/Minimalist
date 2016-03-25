using UnityEngine;
using System.Collections;

public class PickupCollider : MonoBehaviour {

	public float RedPickup = 0;
	public float BluePickup = 0;
	public float GreenPickup = 0;

	public bool PickedUp = false;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Pickup")) 
		{
			PickedUp = true;
			Pickup temp = other.gameObject.GetComponent<Pickup>();
			if(temp.ColorType == "Red") RedPickup += temp.PickupValue;
			if(temp.ColorType == "Green") GreenPickup += temp.PickupValue;
			if(temp.ColorType == "Blue") BluePickup += temp.PickupValue;
			Destroy (other.gameObject);
		}
	}

	public Vector3 PickupColliderStats() {
		return new Vector3(RedPickup, GreenPickup, BluePickup);
	}

	public void Reset() {
		RedPickup = 0;
		BluePickup = 0;
		GreenPickup = 0;
		PickedUp = false;
	}
}
