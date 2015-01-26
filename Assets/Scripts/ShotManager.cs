using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour {

	private static ShotManager s_instance;

	public GameObject hitParticle;

	void Awake() {
		if( s_instance != null ) {
			DestroyImmediate( gameObject );
		} else {
			s_instance = this;
			DontDestroyOnLoad( gameObject );
		}
	}
		
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Shoot(Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height);
		}
	}

	public void Shoot(Vector2 pos) {
		Shoot (pos.x, pos.y);
	}

	public void Shoot(float x, float y) {
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(x, y));
		RaycastHit hit;

		if( Physics.Raycast( ray, out hit ) ) {
			hit.transform.SendMessageUpwards("Hit", SendMessageOptions.DontRequireReceiver);

			GameObject particle = (GameObject)Instantiate(hitParticle, hit.point, Quaternion.identity);
//			particle.transform.rotation = Quaternion.LookRotation(hit.normal, -particle.transform.forward);
//			particle.transform.LookAt(hit.point + Vector3.back, Vector3.right);
			particle.transform.eulerAngles = new Vector3(270f, 0f, 0f); // Fuck it I'm not smart enough

			Transform decal = particle.transform.FindChild("ShatteredGround");

			decal.parent = hit.transform.parent;

			if(hit.collider.gameObject.tag == "Outside") {
				GameManager.ChangeScore(1);
			} else if(hit.collider.gameObject.tag == "Middle") {
				GameManager.ChangeScore(2);
			} else if(hit.collider.gameObject.tag == "Center") {
				GameManager.ChangeScore(3);
			} else {
				GameManager.ChangeScore(-1);
			}
		}
	}
}
