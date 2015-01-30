using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	Text timerText;
	public Image fadeOut;
	public int timer;
	float startTime, fadeTime = .0001f, blackTime = .0001f;
	bool isFading = false, isBlackingOut;
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
		if (isFading) {
			float timePassed = (Time.time - startTime);
			float fracJourney = timePassed / fadeTime;
			GameObject.Find ("WhiteOut").GetComponent<Image>().color = Color.Lerp(new Color(1f,1f,1f,0f), new Color(1f,1f,1f,1f), fracJourney);
			}
		if (isBlackingOut) {
			float timePassed = (Time.time - startTime);
			float fracJourney = timePassed / blackTime;
			GameObject.Find ("WhiteOut").GetComponent<Image>().color = Color.Lerp(new Color(0f,0f,0f,1f), new Color(0f,0f,0f,0f), fracJourney);
			}
			
		}
	
	public void Init() {
		isBlackingOut = true;
		StartCoroutine ("CountDown");
		StartCoroutine ("FadeOut");

	}

	IEnumerator CountDown () {
		while (timer >= 0) {
			yield return new WaitForSeconds(1);
			timer -= 1;
		}
		GameManager.s_instance.EndRound ();

	}

	public IEnumerator FadeOut() {
		yield return new WaitForSeconds ((float)(timer-fadeTime+1));
		isBlackingOut = false;
		startTime = Time.time;
		isFading = true;
		yield return new WaitForSeconds (fadeTime);

	}
}