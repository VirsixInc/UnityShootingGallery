using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetToZero : MonoBehaviour {

	public Image thisImage;

	// Use this for initialization
	void Start () {
		thisImage = GetComponent<Image> ();
		thisImage.color = new Color (1f, 1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
