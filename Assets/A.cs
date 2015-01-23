using UnityEngine;
using System.Collections;

public class A : MonoBehaviour {

	Animator a;

	// Use this for initialization
	void Start () {
		a = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown( KeyCode.Space ) )
		   a.SetTrigger( "Rise" );
	}
}
