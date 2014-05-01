using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class DisappearingPlatform : MonoBehaviour {

	public float timeToDisappear = 1f;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.name.Equals ("Player")) {
			audio.Play ();
			HOTween.To(GetComponent<tk2dTiledSprite>(), timeToDisappear, new TweenParms().Prop("color", Color.clear).OnComplete(this.RemoveBoxCollider));
		}
	}

	public void RemoveBoxCollider() {
		DestroyImmediate(transform.GetComponent<BoxCollider2D>());
		DestroyImmediate(transform.GetComponent<Rigidbody2D>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
