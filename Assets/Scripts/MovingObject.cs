using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private Vector3 m_direction;
	private float m_speed;

	void Start () {
	
	}
	
	void Update() {
		transform.Translate( m_direction * m_speed * Time.deltaTime );
	}

	void SetSpeed( float value ) {
		m_speed = value;
	}
	
	void SetDirection( Vector3 v ) {
		m_direction = v;
	}

	void StartDeathTimer() {
		Destroy (gameObject, 14f);
	}
}
