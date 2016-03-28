using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

//Paths are written so that vertices are relative to the path boundary

	public int height;
	public int vertOffset;
	
	public Vector2 currentVertex;
	public int currentVertexIndex;
	public Vector2[] vertices;
	public Vector2[] pathToScreenVertices;

	public RectTransform debugRect;
	public LineRenderer LinePath;

	void Start() {
		debugRect.sizeDelta = new Vector2(0.0f, (float) height);
		debugRect.localPosition = new Vector3(0.0f, (float) (-.5 * Screen.height) + vertOffset, 0.0f);
		LinePath.SetVertexCount(vertices.Length);
		pathToScreenVertices = new Vector2[vertices.Length];
		drawPath();
	}

	public void startPath() {
		currentVertexIndex = 0;
		currentVertex = vertices[0];
	}

	public Vector2 nextVertex() {
		if(currentVertexIndex < vertices.Length - 1) {
			currentVertexIndex++;
			currentVertex = vertices[currentVertexIndex];
			return currentVertex;
		}
		else {
			return Vector3.zero;
		}
	}

	public void drawPath() {
		for (int i = 0; i < vertices.Length; i++) {
			LinePath.SetPosition(i, new Vector3((float)(vertices[i].x - .5) * (float) (Screen.width), (float)(vertices[i].y - .5) * height + (float) vertOffset - (float) (Screen.height / 2), 0.0f));
			pathToScreenVertices[i] = new Vector2((float)(vertices[i].x - .5) * (float) (Screen.width), (float)(vertices[i].y - .5) * height + (float) vertOffset - (float) (Screen.height / 2));
		}
	}
}