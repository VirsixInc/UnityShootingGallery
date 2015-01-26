using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

	public GameObject m_baseTarget;
	public float m_spawnRate = 2f;
	public float m_targetSpeed = 1f;

	private float timer = 0f;
	private Transform myTransform;
	private Transform killBox;

	void Start () {
		myTransform = GetComponent<Transform>();
		killBox = myTransform.GetChild(0);

		timer = m_spawnRate;
	}
	
	void Update () {
		if(timer >= m_spawnRate) {
			GameObject obj = (GameObject)Instantiate( m_baseTarget, myTransform.position, Quaternion.identity );
			obj.SendMessage("SetDirection", (killBox.position - myTransform.position).normalized );
			obj.SendMessage("SetSpeed", m_targetSpeed);

			timer = 0f;
		}

		timer += Time.deltaTime;
	}
}
