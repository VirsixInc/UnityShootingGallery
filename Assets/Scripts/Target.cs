using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	private bool m_hit = false;
	private Animator m_animator;

	// Use this for initialization
	void Start () {
		m_animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hit() {
		m_animator.SetTrigger( "Drop" );
		m_hit = true;
	}
}
