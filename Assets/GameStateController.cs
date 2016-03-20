using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	public GraphicController Graphics;
	public PlayerController Player;
	public GameObject[] Pickups;
	public GameObject PickupPrefab;

	int pickupsIndex;
	public int maxPickups;

	void Start() {
		pickupsIndex = 0;
		Pickups = new GameObject[maxPickups];
		AddPickup();
	}

	void End() {

	}
	
	void AddPickup() {
		if(pickupsIndex < Pickups.Length) {
			Pickups[pickupsIndex] = Instantiate(PickupPrefab, new Vector3(500, 50, 0), PickupPrefab.transform.rotation) as GameObject; 
			pickupsIndex++;
		}
	}

	void Update() {

	}
}
