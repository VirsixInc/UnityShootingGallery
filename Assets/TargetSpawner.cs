using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

	public GameObject m_baseTarget;
	public float m_spawnRate = 2f;
	public float m_targetSpeed = 1f;

	private float timer = 0f;
	private Transform myTransform;
	private Transform killBox;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();
		killBox = myTransform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		if( timer >= m_spawnRate) {
			GameObject temp = (GameObject)Instantiate( m_baseTarget, myTransform.position, Quaternion.identity );
			Target tTarget = temp.GetComponentInChildren<Target>();
			tTarget.SetDirection( (killBox.position - myTransform.position).normalized );
			tTarget.SetSpeed( m_targetSpeed );

			timer = 0f;
		}

		timer += Time.deltaTime;
	}
}
