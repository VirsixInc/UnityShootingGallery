using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState {Start, Playing, Score};


public class GameManager : MonoBehaviour {

	public GameState thisGameState = GameState.Start;
	public static GameManager s_instance;
	public int gameDuration = 60; //sets how long a shooting round lasts
	public static int m_score = 0;

	float timeSinceLastShot;
	bool canShoot;

	void Awake() {
		timeSinceLastShot = Time.time;

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

	void Update(){
		if (timeSinceLastShot + 0.25f < Time.time) {
						timeSinceLastShot = Time.time;
						canShoot = true;
				}

	}
	public void OSCMessageReceived(OSC.NET.OSCMessage message) {
		if(message.Address == "/shoot" && canShoot){
			timeSinceLastShot = Time.time;
			canShoot = false;
			float x = (float)message.Values[0];
			float y = (float)message.Values[1];
			SendMessage("Shoot", new Vector2(x, y)); //goes to shot manager
		}
	}

	public void StartGame() {
		//enter shooting gallery mode
		thisGameState = GameState.Playing;
		GetComponentInChildren<Timer>().timer = gameDuration; //set timer
		Application.LoadLevel(1);
		GetComponentInChildren<Text>().enabled = true; //show timer
		GetComponentInChildren<Timer> ().Init (); //start timer countdown
	}

	public void EndRound () {
		//score screen
		GetComponentInChildren<Text>().enabled = false; //hide timer
		thisGameState = GameState.Score;
		Application.LoadLevel (2);
		StartCoroutine ("LoadMainScreen");
	}

	IEnumerator LoadMainScreen () {
		//start screen
		yield return new WaitForSeconds (5); //show score for this long before going back to main screen
		m_score = 0; //reset score
		GetComponentInChildren<Text>().enabled = false; //hide timer
		ShotManager.s_instance.totalShots = 0;
		ShotManager.s_instance.shotsHit = 0;
		thisGameState = GameState.Start;
		Application.LoadLevel (0);


	}

}
