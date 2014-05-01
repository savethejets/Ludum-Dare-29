using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class JumpPad : MonoBehaviour {
	
	public CarryWater.NoteType note1;
	public CarryWater.NoteType note2;
	public CarryWater.NoteType note3;
	
	private tk2dSprite water1Sprite;
	private tk2dSprite water2Sprite;
	private tk2dSprite water3Sprite;

	public bool isActivated = false;

	public float jumpForceModifier;

	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		water1Sprite = transform.Find ("WaterIcon1").GetComponent<tk2dSprite> ();
		water2Sprite = transform.Find ("WaterIcon2").GetComponent<tk2dSprite> ();
		water3Sprite = transform.Find ("WaterIcon3").GetComponent<tk2dSprite> ();
		
		water1Sprite.color = CarryWater.getColorFromNoteType (note1);
		water2Sprite.color = CarryWater.getColorFromNoteType (note2);
		water3Sprite.color = CarryWater.getColorFromNoteType (note3);

		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.name.Equals ("Player")) {
			CarryWater water = other.transform.GetComponent<CarryWater>();
			if (!isActivated) {
				if(this.note1.Equals(water.GetNote1()) &&
				   this.note2.Equals(water.GetNote2()) &&
				   this.note3.Equals(water.GetNote3()))
				{
				
					water.ReleaseAllNotes();
					
					HOTween.To(water1Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water2Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water3Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));

					isActivated = true;


				
				} else {
					water.ReleaseAllNotes();
				}
			}

			if(isActivated) {
				other.transform.GetComponent<PlayerController>().Bounce(jumpForceModifier);
				Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.03f);
				audioSource.Play();
			}
			                
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
