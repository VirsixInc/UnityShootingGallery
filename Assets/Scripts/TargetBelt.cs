using UnityEngine;
using System.Collections;

public class TargetBelt : MonoBehaviour {

	public Transform m_beltEnd;
	public GameObject m_baseTarget;
	public float m_moveSpeed = 0f;
	public int m_numTargets = 4;

	private Transform[] m_targets;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		if( m_baseTarget != null ) {
			m_targets = new Transform[m_numTargets];

			dir = ( m_beltEnd.position - transform.position).normalized;
			float distance = ( m_beltEnd.position - transform.position ).magnitude;
			float increment = distance / (float)m_numTargets;

			for( int i = 0, j = m_numTargets; i < j; i++ ) {
				Vector3 pos = transform.position + dir * increment * i;
				GameObject temp = (GameObject)Instantiate( m_baseTarget, pos, Quaternion.identity );
				m_targets[i] = temp.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach( Transform t in m_targets ) {
			t.rigidbody.MovePosition( t.position + dir * m_moveSpeed * Time.deltaTime );
		}
	}

	void OnTriggerEnter( Collider col ) {
		Debug.Log( "Hello" );
	}
}
