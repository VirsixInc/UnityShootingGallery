using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public int score = 0;
	
	static Score s_score;
	
	void Start() {
		s_score = this;
	}
	
	void OnGUI() {
		GUI.Label(new Rect(0.0f, 0.0f, 200.0f, 50.0f), "Score: " + score);	
	}
	
	/// <summary>
	/// Changes the score.
	/// </summary>
	/// <param name='num'>
	/// Number.
	/// </param>
	public static void ChangeScore(int num) {
		s_score.score += num;
	}
}
