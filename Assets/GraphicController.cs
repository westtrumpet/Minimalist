using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GraphicController : MonoBehaviour {

	public PlayerController Player;
	public Camera mainCamera;
	GameObject PlayerObject;
	SpriteRenderer playerImage;

	public Image RedLeft;
	public Image RedRight;
	public Image GreenLeft;
	public Image GreenRight;
	public Image BlueLeft;
	public Image BlueRight;

	public float Red;
	public float Green;
	public float Blue;

	public float ColorIncrement;

	void Start() {
		PlayerObject = Player.Player;
		playerImage = PlayerObject.GetComponent<SpriteRenderer>();
		RedLeft.type = Image.Type.Filled;
		RedLeft.fillMethod = Image.FillMethod.Horizontal;
		GreenLeft.type = Image.Type.Filled;
		GreenLeft.fillMethod = Image.FillMethod.Horizontal;
		BlueLeft.type = Image.Type.Filled;
		BlueLeft.fillMethod = Image.FillMethod.Horizontal;
		RedRight.type = Image.Type.Filled;
		RedRight.fillMethod = Image.FillMethod.Horizontal;
		GreenRight.type = Image.Type.Filled;
		GreenRight.fillMethod = Image.FillMethod.Horizontal;
		BlueRight.type = Image.Type.Filled;
		BlueRight.fillMethod = Image.FillMethod.Horizontal;
		ChangeBarFill("Red");
		ChangeBarFill("Green");
		ChangeBarFill("Blue");
	}

	/*void Update() {
		ChangeBarFill("Red");
		ChangeBarFill("Green");
		ChangeBarFill("Blue");
	}*/

	void ChangePlayerColor(Vector3 NewColor) {
		playerImage.color = new Color(NewColor.x, NewColor.y, NewColor.z, 1.0f);
		mainCamera.backgroundColor = new Color(NewColor.x, NewColor.y, NewColor.z, 1.0f);
	}

	public void Increment(string ColorBar, float NumIncrement) {
		if (ColorBar == "Red") {
			Red += NumIncrement * ColorIncrement;
			ChangeBarFill("Red");
		}
		if (ColorBar == "Green") {
			Green += NumIncrement * ColorIncrement;
			ChangeBarFill("Green");
		}
		if (ColorBar == "Blue") {
			Blue += NumIncrement * ColorIncrement;
			ChangeBarFill("Blue");
		}
	}

	void ChangeBarFill(string ColorBar) {
		if (Red > 1.0f) Red = 1.0f;
		if (Green > 1.0f) Green = 1.0f; 
		if (Blue > 1.0f) Blue = 1.0f;
		if (Red < 0.0f) Red = 0.0f;
		if (Green < 0.0f) Green = 0.0f;
		if (Blue < 0.0f) Blue = 0.0f;
		if (ColorBar == "Red") {
			if(Red > .5) {
				RedLeft.fillAmount = 1.0f;
				RedRight.fillAmount = 2 * (Red - 0.5f);
			}
			else {
				RedLeft.fillAmount = 2 * Red;
				RedRight.fillAmount = 0.0f;
			}
		}
		if (ColorBar == "Green") {
			if(Green > .5) {
				GreenLeft.fillAmount = 1.0f;
				GreenRight.fillAmount = 2 * (Green - 0.5f);
			}
			else {
				GreenLeft.fillAmount = 2 * Green;
				GreenRight.fillAmount = 0.0f;
			}
		}
		if (ColorBar == "Blue") {
			if(Blue > .5) {
				BlueLeft.fillAmount = 1.0f;
				BlueRight.fillAmount = 2 * (Blue - 0.5f);
			}
			else {
				BlueLeft.fillAmount = 2 * Blue;
				BlueRight.fillAmount = 0.0f;
			}
		}
		ChangePlayerColor(new Vector3(Red, Green, Blue));
	}
}
