using UnityEngine;
using System.Collections;

public class InteractivePlant : MonoBehaviour {

	private AudioSource audioSource;
	private tk2dSpriteAnimator anim;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		anim = GetComponent<tk2dSpriteAnimator> ();
	}

	void OnCollisionEnter2D(Collision2D other) {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.name.Equals ("Player")) {
			audioSource.Play();
			anim.Play();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.name.Equals ("Player")) {
			anim.StopAndResetFrame();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
