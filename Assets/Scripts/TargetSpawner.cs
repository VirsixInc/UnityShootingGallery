using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

	public GameObject m_baseTarget;
	public float m_spawnRate = 2f;
	public float m_targetSpeed = 1f;

	private float timer = 0f;

	public Vector3 direction = new Vector3(1f, 0f, 0f);
	private Transform myTransform;
//	private Transform killBox;

	void Start () {
		myTransform = GetComponent<Transform>();
//		killBox = myTransform.GetChild(0);

		timer = m_spawnRate;
	}
	
	void Update () {
		if(timer >= m_spawnRate) {
			GameObject obj = (GameObject)Instantiate( m_baseTarget, myTransform.position, Quaternion.identity );
			obj.SendMessage("SetDirection", direction.normalized);
			obj.SendMessage("SetSpeed", m_targetSpeed);
			obj.SendMessage("StartDeathTimer");

			timer = 0f;
		}

		timer += Time.deltaTime;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine (transform.position, transform.position + (direction.normalized * 4f));
	}
}
