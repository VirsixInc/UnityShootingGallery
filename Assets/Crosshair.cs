using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

//	public Texture2D crosshair;
//	
//	public GameObject emitter;
//	
//	public float sizePercentOfScreen = 100.0f;
//	
//	void Update () {
//		if(Input.GetButtonDown("Fire1")) {
//			RaycastHit hit;
//			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
//				emitter.transform.position = hit.point+Vector3.back;
//				emitter.particleSystem.Play();
//				if(hit.collider.gameObject.tag == "Outside") {
//					Score.ChangeScore(1);
//				} else if(hit.collider.gameObject.tag == "Middle") {
//					Score.ChangeScore(2);
//				} else if(hit.collider.gameObject.tag == "Center") {
//					Score.ChangeScore(3);
//				} else {
//					Score.ChangeScore(-1);
//				}
//			}
//		}
//	}
//	
//	void OnGUI() {
//		GUI.DrawTexture(
//			new Rect(
//				Input.mousePosition.x - (Screen.width*(sizePercentOfScreen/100.0f))/2.0f, 
//				(Screen.height - Input.mousePosition.y) - (Screen.width*(sizePercentOfScreen/100.0f))/2.0f,
//				Screen.width*(sizePercentOfScreen/100.0f),
//				Screen.width*(sizePercentOfScreen/100.0f)
//			),
//			crosshair
//		);
//	}
}