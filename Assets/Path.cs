using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

//Paths are written so that vertices are relative to the path boundary

	public int height;
	public int vertOffset;
	
	public Vector2 currentVertex;
	public int currentVertexIndex;
	public Vector2[] vertices;

	public RectTransform debugRect;
	public LineRenderer LinePath;

	void Start() {
		debugRect.sizeDelta = new Vector2(0.0f, (float) height);
		debugRect.localPosition = new Vector3(0.0f, -300 + vertOffset, 0.0f);
		LinePath.SetVertexCount(vertices.Length);
		drawPath();
	}

	public Vector2 startPath() {
		currentVertexIndex = 0;
		currentVertex = vertices[0];
		return currentVertex;
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
			LinePath.SetPosition(i, new Vector3(vertices[i].x * (float) Screen.width, (float) vertices[i].y * height + (float) vertOffset, 0.0f));
		}
	}

	
}