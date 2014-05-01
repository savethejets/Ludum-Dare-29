using UnityEngine;
using System.Collections;

public class PlaySoundOnContact : MonoBehaviour {

	private AudioSource audio;
	private bool wasTriggered = false;
		
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(!wasTriggered && !other.transform.name.Equals("UndergroundTrigger")) {
			audio.Play ();
			GameObject obj = (GameObject) GameObject.Instantiate (Resources.Load("WaterParticle"), transform.position, Quaternion.Euler(new Vector3(270,0,0)));
			obj.GetComponent<ParticleSystem> ().startColor = CarryWater.getColorFromNoteType(GetComponent<Note>().noteType);
			wasTriggered = true;
			DestroyObject(transform.GetComponentInChildren<tk2dSprite>());
			Destroy (obj, 1);
			Destroy(GetComponent<BoxCollider2D>());
			Destroy(GetComponent<Rigidbody2D>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (wasTriggered && !audio.isPlaying) {
			DestroyObject (transform.parent);
			DestroyObject (transform.gameObject);
		}
	}
}
