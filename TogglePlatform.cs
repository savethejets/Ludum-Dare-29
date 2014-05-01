using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class TogglePlatform : MonoBehaviour {

	public float timeAlive;

	// Use this for initialization
	void Start () {
		GetComponent<tk2dTiledSprite> ().color = Color.clear;

		HOTween.To (GetComponent<tk2dTiledSprite> (), 0.2f, new TweenParms ().Prop ("color", Color.white));
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.name.Equals ("Player")) {
			audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
