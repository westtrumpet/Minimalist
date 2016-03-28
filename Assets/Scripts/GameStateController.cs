using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	public GraphicController Graphics;
	public PlayerController Player;
	public GameObject[] Pickups;
	public GameObject PickupPrefab;

	public int pickupsIndex;
	public int maxPickups;

	void Start() {
		pickupsIndex = 0;
		Pickups = new GameObject[maxPickups];
		AddPickup();
	}

	void End() {

	}
	
	void AddPickup() {
		Debug.Log("Adding pickup");
		if(pickupsIndex < Pickups.Length) {
			Pickups[pickupsIndex] = Instantiate(PickupPrefab, new Vector3(0, 100, 0), PickupPrefab.transform.rotation) as GameObject; 
			pickupsIndex++;
		}
	}

	void Update() {
		if(Player.Collider.PickedUp) {
			Vector3 temp = Player.Collider.PickupColliderStats();
			Graphics.Increment("Red", temp.x);
			Graphics.Increment("Green", temp.y);
			Graphics.Increment("Blue", temp.z);
			Player.Collider.Reset();
		}
	}
}
