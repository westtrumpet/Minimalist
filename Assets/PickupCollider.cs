using UnityEngine;
using System.Collections;

public class PickupCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("WORKS");
		if(other.gameObject.CompareTag("Pickup")) Destroy (other.gameObject);
	}
}
