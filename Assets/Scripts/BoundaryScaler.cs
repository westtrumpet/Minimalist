using UnityEngine;
using System.Collections;

public class BoundaryScaler : MonoBehaviour {

	public int ScreenWidth;
	public int ScreenHeight;

	public GameObject LeftBoundary;
	public GameObject RightBoundary;
	public GameObject TopBoundary;
	public GameObject BottomBoundary;

	BoxCollider2D Left;
	BoxCollider2D Right;
	BoxCollider2D Top;
	BoxCollider2D Bottom;

	void Start () {
		ScreenWidth = Screen.width;
		ScreenHeight = Screen.height;

		Left = LeftBoundary.GetComponent<BoxCollider2D>();
		Right = RightBoundary.GetComponent<BoxCollider2D>();
		Top = TopBoundary.GetComponent<BoxCollider2D>();
		Bottom = BottomBoundary.GetComponent<BoxCollider2D>();

		Left.size = new Vector2(40.0f, Screen.height);
		Right.size = new Vector2(40.0f, Screen.height);
		Top.size = new Vector2(Screen.width, 40.0f);
		Bottom.size = new Vector2(Screen.width, 40.0f);

		LeftBoundary.transform.position = new Vector3(Screen.width / (-2) - (Left.size.x / 2), 0.0f, 0.0f);
		RightBoundary.transform.position = new Vector3(Screen.width / 2 + (Right.size.x / 2), 0.0f, 0.0f);
		TopBoundary.transform.position = new Vector3(0.0f, (Screen.height / 2) + (Top.size.y /2), 0.0f);
		BottomBoundary.transform.position = new Vector3(0.0f, (-Screen.height / 2) - (Bottom.size.y / 2), 0.0f);

		
	}

}
