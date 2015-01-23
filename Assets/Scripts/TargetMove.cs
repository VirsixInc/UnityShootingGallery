using UnityEngine;
using System.Collections;

public class TargetMove : MonoBehaviour {
	
	public float amplitude;
	public float frequency;
	
	Vector3 newPos;
	float offsetX;
	float offsetY;
	
	// Use this for initialization
	void Start () {
		offsetX = transform.position.x;
		offsetY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		offsetX += amplitude * Mathf.Cos(Mathf.Deg2Rad * frequency * Time.frameCount);
		//offsetY = Sine^^;
		newPos = new Vector3(offsetX, offsetY, 0.0f);
		transform.position = newPos;
	}
}
