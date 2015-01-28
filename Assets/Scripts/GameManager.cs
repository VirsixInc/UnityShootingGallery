using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState {Start, Playing, Score};


public class GameManager : MonoBehaviour {

	public GameState thisGameState = GameState.Start;
	public static GameManager s_instance;
	public int gameDuration = 60;
	public static int m_score;
	
	void Awake() {
		if( s_instance != null ) {
			DestroyImmediate( gameObject );
		} else {
			s_instance = this;
			DontDestroyOnLoad( gameObject );
		}
	}


	public static void ChangeScore( int num ) {
		m_score += num;
	}

	public void OSCMessageReceived(OSC.NET.OSCMessage message) {
		if(message.Address == "/shoot"){
			float x = (float)message.Values[0];
			float y = (float)message.Values[1];
			SendMessage("Shoot", new Vector2(x, y));
		}
	}

	public void StartGame() {
		thisGameState = GameState.Playing;
		GetComponentInChildren<Timer>().timer = gameDuration;
		Application.LoadLevel(1);
		GetComponentInChildren<Text>().enabled = true;

		GetComponentInChildren<Timer> ().Init ();
	}

	public void EndRound () {
		GetComponentInChildren<Text>().enabled = false;
		thisGameState = GameState.Score;
		Application.LoadLevel (2);
		StartCoroutine ("LoadMainScreen");
	}

	IEnumerator LoadMainScreen () {
		yield return new WaitForSeconds (10);
		m_score = 0;
		GetComponentInChildren<Text>().enabled = false;

		ShotManager.s_instance.totalShots = 0;
		ShotManager.s_instance.shotsHit = 0;
		thisGameState = GameState.Start;
		Application.LoadLevel (0);


	}

}
