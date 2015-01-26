using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	void OnTriggerEnter( Collider col ) {
		if( col.tag == "Outside" ) {
			Destroy( col.transform.root.gameObject );
		}
	}
}
