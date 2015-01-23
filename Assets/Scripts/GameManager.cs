using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager s_instance;

	public static int m_score;
	
	void Awake() {
		if( s_instance != null ) {
			DestroyImmediate( gameObject );
		} else {
			s_instance = this;
			DontDestroyOnLoad( gameObject );
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ChangeScore( int num ) {
		m_score += num;
	}
}
