using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	private bool m_hit = false;
	private Animator m_animator;
	private Vector3 m_direction;
	private float m_speed;

	void Start () {
		m_animator = GetComponentInChildren<Animator>();
	}

	void Update() {
		transform.Translate( m_direction * m_speed * Time.deltaTime );
	}

	public void Hit() {
		m_animator.SetTrigger( "Drop" );
		m_hit = true;

		SetColliders (false);
	}

	public void PopUp() {
		SetColliders (true);
	}

	void SetColliders(bool on) {
		Collider[] colliders = GetComponentsInChildren<Collider>();
		
		foreach(Collider col in colliders) {
			col.enabled = on;
		}
	}

	public void SetSpeed( float value ) {
		m_speed = value;
	}

	public void SetDirection( Vector3 v ) {
		m_direction = v;
	}
}
