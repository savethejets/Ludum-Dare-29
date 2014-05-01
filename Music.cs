using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Music : MonoBehaviour {

	private AudioSource baseClick;
	private AudioSource track1;
	private AudioSource track2;
	private AudioSource track3;
	private AudioSource track4;

	private AudioSource cave;

	private bool isMuted = false;

	private bool isTrack1Playing = false;
	private bool isTrack2Playing = false;
	private bool isTrack3Playing = false;
	private bool isTrack4Playing = false;

	// Use this for initialization
	void Awake () {
	
		baseClick = transform.Find ("baseClick").GetComponent<AudioSource>();

		track1 = transform.Find ("track1").GetComponent<AudioSource>();
		track2 = transform.Find ("track2").GetComponent<AudioSource>();
		track3 = transform.Find ("track3").GetComponent<AudioSource>();
		track4 = transform.Find ("track4").GetComponent<AudioSource>();
		cave = transform.Find ("cave").GetComponent<AudioSource>();

		track1.volume = 0;
		track2.volume = 0;
		track3.volume = 0;
		track4.volume = 0;
		cave.volume = 0;

		baseClick.volume = 100;
	}

	public void AddBox() {
		if (!isTrack1Playing) {
			isTrack1Playing = true;
			track1.volume = 100;
		} else if (!isTrack2Playing) {
			isTrack2Playing = true;
			track2.volume = 100;
		} else if (!isTrack3Playing) {
			isTrack3Playing = true;
			track3.volume = 100;
		} else if (!isTrack4Playing) {
			isTrack4Playing = true;
			track4.volume = 100;
		}


	}

	public void toggleMusic() {
		if (isMuted) {
			isMuted = false;
			fadeAllIn();
			fadeOutCave();
		} else {
			isMuted = true;
			fadeAllOut();
			fadeInCave();
		}
	}

	public void fadeAllOut() {

		HOTween.To (track1, 1.0f, new TweenParms ().Prop ("volume", 0f));
		HOTween.To (track2, 1.0f, new TweenParms ().Prop ("volume", 0f));
		HOTween.To (track3, 1.0f, new TweenParms ().Prop ("volume", 0f));
		HOTween.To (track4, 1.0f, new TweenParms ().Prop ("volume", 0f));

//		GameObject.Find ("ScreenFader").GetComponent<FadeInOut> ().FadeToBlack ();
	}

	public void fadeInCave() {
		HOTween.To (cave, 0.5f, new TweenParms ().Prop ("volume", 0.4f));
	}

	public void fadeOutCave() {
		HOTween.To (cave, 0.5f, new TweenParms ().Prop ("volume", 0f));
	}

	public void fadeAllHalf() {
		baseClick.volume = 100;
		if (isTrack1Playing) {
			HOTween.To (track1, 1.0f, new TweenParms ().Prop ("volume", 0.5f));
		} 
		if (isTrack2Playing) {
			HOTween.To (track2, 1.0f, new TweenParms ().Prop ("volume", 0.5f));
		} 
		if (isTrack3Playing) {
			HOTween.To (track3, 1.0f, new TweenParms ().Prop ("volume", 0.5f));
		} 
		if (isTrack4Playing) {
			HOTween.To (track4, 1.0f, new TweenParms ().Prop ("volume", 0.5f));
		}
	}

	public void fadeAllIn() {
		baseClick.volume = 100;

		if (isTrack1Playing) {
			HOTween.To (track1, 1.0f, new TweenParms ().Prop ("volume", 1f));
		} 
		if (isTrack2Playing) {
			HOTween.To (track2, 1.0f, new TweenParms ().Prop ("volume", 1f));
		} 
		if (isTrack3Playing) {
			HOTween.To (track3, 1.0f, new TweenParms ().Prop ("volume", 1f));
		} 
		if (isTrack4Playing) {
			HOTween.To (track4, 1.0f, new TweenParms ().Prop ("volume", 1f));
		}

//		GameObject.Find ("ScreenFader").GetComponent<FadeInOut> ().FadeToClear ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
