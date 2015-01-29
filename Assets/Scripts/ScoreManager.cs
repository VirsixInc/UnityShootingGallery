using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score, accuracy;

	void Start () {
		score.text = "Total Score: " + GameManager.m_score.ToString();
		accuracy.text = "Accuracy: " + (Mathf.CeilToInt(100 *((float)ShotManager.s_instance.shotsHit / (float)ShotManager.s_instance.totalShots))).ToString() + "%";
	}
}
