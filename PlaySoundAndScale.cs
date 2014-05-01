using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlaySoundAndScale : MonoBehaviour {

	private AudioSource audioSource;
	public float secondsBetweenPlayAndScale;
	
	private Timer timer; 
	private tk2dSprite sprite;

	public bool isEnabled = false;
	
	// Use this for initialization
	void Awake () {
		timer = this.GetComponent<Timer> ();
		audioSource = this.GetComponent<AudioSource> ();
		timer.Init ();
		timer.AddEvent(new Timer.TimerEvent(this.ScaleSprite, secondsBetweenPlayAndScale, true));
		sprite = this.GetComponent<tk2dSprite> ();
	}
	
	void ScaleSprite() {
		if (isEnabled) {
			HOTween.To (sprite, 0.1f, new TweenParms ().Prop ("scale", new Vector3 (3f, 3f, 1f)).OnComplete (this.ReverseScale));
		}
	}

	void ReverseScale() {
		HOTween.To (sprite, 0.4f, new TweenParms().Prop("scale", new Vector3 (2f, 2f, 1f)));
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
