using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour {

	private static ShotManager s_instance;

	void Awake() {
		if( s_instance != null )
			DestroyImmediate( gameObject );
		else
			s_instance = this;
	}

	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown( 0 ) ) {
			Shoot( Input.mousePosition.x, Input.mousePosition.y );
		}
	}

	public void Shoot( float x, float y ) {
		Ray ray = Camera.main.ViewportPointToRay( new Vector3( x, y ) );
		RaycastHit hit;
		Debug.Log( x + y );
		if( Physics.Raycast( ray, out hit ) ) {
			hit.transform.SendMessage( "Hit" );

		}
	}
}
