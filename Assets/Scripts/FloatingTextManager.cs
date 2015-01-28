using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour {
	
	static FloatingTextManager s_instance;

	public GameObject okayPrefab, nicePrefab, bullseyePrefab;
	
	private float m_fadeTime = 1.0f;
	private float m_yGain = 0.5f;	// meters per second

	public enum ScoreType {
		OKAY, NICE, BULLSEYE
	}

	#region Singleton Initialization
	public static FloatingTextManager instance {
		get { 
			if(s_instance == null)
				s_instance = GameObject.FindObjectOfType<FloatingTextManager>();
			
			return s_instance;
		}
	}
	
	void Awake() {
		if(s_instance == null) {
			s_instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			if(s_instance != this)
				Destroy(gameObject);
		}
	}
	#endregion

	public static void CreateFloatingText(Vector3 pos, ScoreType scoreType) {
		instance.Create (pos, scoreType);
	}

	public void Create(Vector3 pos, ScoreType scoreType) {
		GameObject text;
		if(scoreType == ScoreType.OKAY) {
			text = okayPrefab;
		} else if(scoreType == ScoreType.NICE) {
			text = nicePrefab;
		} else {
			text = bullseyePrefab;
		}

		pos.z = 0f;

		Text t_obj = ((GameObject)GameObject.Instantiate(text, pos, Quaternion.identity)).GetComponent<Text>();

		t_obj.rectTransform.SetParent(transform.FindChild ("Canvas"), true);
//		t_obj.rectTransform.localPosition = pos;
		t_obj.rectTransform.localScale = Vector3.one * 0.6391072f; //Ghetto cuz why not

		if(scoreType == ScoreType.OKAY) {
			pos.x = Mathf.Clamp(pos.x, -275f, 275f); // Hardcode ghetto thug life
		} else if(scoreType == ScoreType.NICE) {
			pos.x = Mathf.Clamp(pos.x, -275f, 275f);
			print ("clamped to: " + pos.x);
		} else {
			pos.x = Mathf.Clamp(pos.x, -248f, 248f);
		}

		t_obj.rectTransform.localPosition = pos;

		StartCoroutine( "FloatingText", t_obj );
	}
//	
//	void OnLevelWasLoaded(int level) {
//		StopAllCoroutines();
//		_instance = this;
//	}
	
	IEnumerator FloatingText(Text textObj) {
		Vector3 startingPos = textObj.transform.position;
		Vector3 yOffset = Vector3.zero;
		float timer = 0f;
		
		while(timer < m_fadeTime) {
			yOffset.y += m_yGain * Time.deltaTime;
			
			textObj.transform.position = startingPos + yOffset;
			
			timer += Time.deltaTime;
			yield return null;
		}
		
		Destroy(textObj.gameObject);
	}
}
