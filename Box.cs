using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Holoville.HOTween;

public class Box : MonoBehaviour {

	public CarryWater.NoteType note1;
	public CarryWater.NoteType note2;
	public CarryWater.NoteType note3;

	private tk2dSprite water1Sprite;
	private tk2dSprite water2Sprite;
	private tk2dSprite water3Sprite;

	private bool isFired = false;

	private List<BoxFilledEvent> boxFilledEvents;

	void Awake() {
		boxFilledEvents = new List<BoxFilledEvent> ();
	}

	public void AddEvent(BoxFilledEvent e) {
		boxFilledEvents.Add (e);
	}

	// Use this for initialization
	void Start () {
		water1Sprite = transform.Find ("WaterIcon1").GetComponent<tk2dSprite> ();
		water2Sprite = transform.Find ("WaterIcon2").GetComponent<tk2dSprite> ();
		water3Sprite = transform.Find ("WaterIcon3").GetComponent<tk2dSprite> ();

		water1Sprite.color = CarryWater.getColorFromNoteType (note1);
		water2Sprite.color = CarryWater.getColorFromNoteType (note2);
		water3Sprite.color = CarryWater.getColorFromNoteType (note3);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.transform.name.Equals ("Player") && !isFired) {
			CarryWater water = other.transform.GetComponent<CarryWater>();
			if (water != null) {
				if(water.GetNote1().Equals(this.note1) &&
				   water.GetNote2().Equals(this.note2) && 
				   water.GetNote3().Equals(this.note3))
				{
					GetComponent<PlaySoundAndScale>().isEnabled = true;
									
					Music music = GameObject.Find ("Music").GetComponent<Music> ();
					
					music.AddBox();
					water.ReleaseAllNotes();
				
					GetComponent<AudioSource>().Play();

					foreach(tk2dSpriteAnimator child in transform.GetComponentsInChildren<tk2dSpriteAnimator>()) {
						child.Play();

					}				
					Camera.main.GetComponent<CameraShake>().Shake(0f,0.2f, 0.003f, this.CompleteEvents);
					
					HOTween.To(water1Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water2Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water3Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					
					isFired = true;
				} else {
					water.ReleaseAllNotes();
				}
			}
		}
	}

	public void CompleteEvents() {
		foreach (BoxFilledEvent e in boxFilledEvents) {
			e.doAction();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public class BoxFilledEvent {
		public Action method;
		
		public BoxFilledEvent (Action method)
		{
			this.method = method; 		
		}
		
		public void doAction ()
		{
			method();
		}
		
	}
}
