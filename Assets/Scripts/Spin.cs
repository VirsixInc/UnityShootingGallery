using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	private Transform m_thisTransform;

	public float m_spinSpeed = 30f;

	// Use this for initialization
	void Start () {
		m_thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		m_thisTransform.Rotate( new Vector3( 0f, 0f, m_spinSpeed * Time.deltaTime ) );
	}
}
