using UnityEngine;
using System.Collections;

public class PathSelector : MonoBehaviour {

	public GameObject[] PathPrefabs;

	public GameObject getPath() {
		return PathPrefabs[Random.Range(0, PathPrefabs.Length-1)];
	}
}
