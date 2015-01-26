using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour {

	private static ShotManager s_instance;

	void Awake() {
		if( s_instance != null ) {
			DestroyImmediate( gameObject );
		} else {
			s_instance = this;
			DontDestroyOnLoad( gameObject );
		}
	}

	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown( 0 ) ) {
			Shoot( Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height );
		}
	}

	public void Shoot( float x, float y ) {
		Ray ray = Camera.main.ViewportPointToRay( new Vector3( x, y ) );
		RaycastHit hit;

		if( Physics.Raycast( ray, out hit ) ) {
			hit.transform.SendMessageUpwards( "Hit", SendMessageOptions.DontRequireReceiver );
			//Debug.Log( hit.transform.name );

			if(hit.collider.gameObject.tag == "Outside") {
				GameManager.ChangeScore(1);
				//Debug.Log( 1 );
			} else if(hit.collider.gameObject.tag == "Middle") {
				GameManager.ChangeScore(2);
				//Debug.Log( 2 );
			} else if(hit.collider.gameObject.tag == "Center") {
				GameManager.ChangeScore(3);
				//Debug.Log( 3 );
			} else {
				GameManager.ChangeScore(-1);
				//Debug.Log( -1 );
			}

			Debug.Log( GameManager.m_score );
		}
	}
}
