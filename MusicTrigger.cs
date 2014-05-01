using UnityEngine;
using System.Collections;

public class MusicTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.name.Equals ("Player")) {
			Music music = GameObject.Find ("Music").GetComponent<Music> ();
			
			music.fadeAllHalf ();
			music.fadeInCave ();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.name.Equals ("Player")) {
			Music music = GameObject.Find ("Music").GetComponent<Music> ();
			
			music.fadeAllIn ();
			music.fadeOutCave ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
