using UnityEngine;
using System.Collections;

public class Decal : MonoBehaviour {
	
	public Texture2D decal;
	
	Texture2D surface;
	Material mat;
	
	// Use this for initialization
	void Start () {
		mat = renderer.material;
		surface = (Texture2D)Instantiate(mat.mainTexture);
		
		renderer.material.mainTexture = surface;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) ) {
				if(hit.collider.gameObject.tag == "Target") {
					Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 100.0f);
					Debug.Log(hit.transform.name);
					ApplyDecal(hit);
				}
			}
		}
	}
	
	void ApplyDecal(RaycastHit hit) {
		Vector2 offset = hit.textureCoord;
		offset.x *= surface.width;
		offset.y *= surface.height;

		Color d, s;
		for(int x =0; x < decal.width; x++) {
			for(int y = 0; y < decal.height; y++){
				
				d = decal.GetPixel(x,y);
				s = surface.GetPixel(x + (int)offset.x, y + (int)offset.y);
				
				s = Color.Lerp(d, s, 1-d.a);
				if(d.a > 0.0f)
					surface.SetPixel(x+(int)offset.x-(decal.width/2), y+(int)offset.y-(decal.height/2), d);
			}
		}
		surface.Apply(true);
	}
}
