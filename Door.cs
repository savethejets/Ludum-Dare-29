using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Door : MonoBehaviour {
	
	public CarryWater.NoteType note1;
	public CarryWater.NoteType note2;
	public CarryWater.NoteType note3;
	
	private tk2dSprite water1Sprite;
	private tk2dSprite water2Sprite;
	private tk2dSprite water3Sprite;

	private bool isUnlocked;
	
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
		
		if (other.transform.name.Equals ("Player")) {
			CarryWater water = other.transform.GetComponent<CarryWater>();
			if(water.GetNote1().Equals(this.note1) &&
			   water.GetNote2().Equals(this.note2) && 
			   water.GetNote3().Equals(this.note3))
			{
				if (!isUnlocked) {
					water.ReleaseAllNotes();
				
					HOTween.To(water1Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water2Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));
					HOTween.To(water3Sprite, 0.3f, new TweenParms().Prop("color", new Color(1,1,1,0)));

					isUnlocked = true;

					Destroy(transform.gameObject, 0.5f);
				} 

			} else {
				water.ReleaseAllNotes();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
