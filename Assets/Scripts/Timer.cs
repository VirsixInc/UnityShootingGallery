using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	Text timerText;
	public int timer;
	void Awake() {
		timerText = GetComponent<Text> ();
	}

	void Update () {
			string minutes = ((int)(timer / 60)).ToString();
			string seconds = ((int)(timer % 60f)).ToString();
			
			if(seconds.Length == 1) {
				seconds = "0"+seconds;
			}
			
			timerText.text = minutes + ":" + seconds;
			
		}
	
	public void Init() {
		StartCoroutine ("CountDown");

	}

	IEnumerator CountDown () {
		while (timer > 0) {
			yield return new WaitForSeconds(1);
			timer -= 1;
		}
		GameManager.s_instance.EndRound ();

	}
}