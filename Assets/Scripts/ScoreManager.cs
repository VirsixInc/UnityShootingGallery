using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score, accuracy;

	void Start () {
		score.text = "Total Score: " + GameManager.m_score.ToString();
		if (ShotManager.s_instance.totalShots != 0)
			accuracy.text = "Accuracy: " + (Mathf.CeilToInt(100 *((float)ShotManager.s_instance.shotsHit / (float)ShotManager.s_instance.totalShots))).ToString() + "%";
		else
			accuracy.text = "Accuracy: 0" + "%";

	}
}
