using UnityEngine;
using System.Collections;

public class CarryWater : MonoBehaviour {

	public enum NoteType
	{
		NULL, ONE, TWO, THREE, FOUR
	}

	private NoteType water1 = NoteType.NULL;
	private NoteType water2 = NoteType.NULL;
	private NoteType water3 = NoteType.NULL;

	private tk2dSprite water1Sprite;
	private tk2dSprite water2Sprite;
	private tk2dSprite water3Sprite;

	// Use this for initialization
	void Start () {
		water1Sprite = transform.Find ("WaterIcon1").GetComponent<tk2dSprite> ();
		water2Sprite = transform.Find ("WaterIcon2").GetComponent<tk2dSprite> ();
		water3Sprite = transform.Find ("WaterIcon3").GetComponent<tk2dSprite> ();
	}

	public void addNote(NoteType note) {
		if (water1.Equals(NoteType.NULL)) {
			water1 = note;
			water1Sprite.color = getColorFromNoteType(note);
		} else if (water2.Equals(NoteType.NULL)) {
			water2 = note;
			water2Sprite.color = getColorFromNoteType(note);
		} else if (water3.Equals(NoteType.NULL)) {
			water3 = note;
			water3Sprite.color = getColorFromNoteType(note);
		}
	}

	public NoteType GetNote1() {
		return water1;
	}

	public NoteType GetNote2() {
		return water2;
	}

	public NoteType GetNote3() {
		return water3;
	}

	public void ReleaseAllNotes() {
		water1 = NoteType.NULL;
		water2 = NoteType.NULL;
		water3 = NoteType.NULL;

		water1Sprite.color = new Color (1, 1, 1);
		water2Sprite.color = new Color (1, 1, 1);
		water3Sprite.color = new Color (1, 1, 1);
	}

	public static Color getColorFromNoteType(NoteType type, byte alpha = 255) {

		if (type.Equals(NoteType.ONE)) {
			return new Color32(40,102,210, alpha);
		} else if (type.Equals(NoteType.TWO)) {
			return new Color32(37,208,64, alpha);
		} else if (type.Equals(NoteType.THREE)) {
			return new Color32(250,255,65, alpha);
		} else if (type.Equals(NoteType.FOUR)) {
			return new Color32(244,40,42, alpha);
		}
		return new Color (0,0,0, alpha);
	}

		
	// Update is called once per frame
	void Update () {
		water1Sprite.transform.localScale = new Vector3 (1, 1, 1);
		water2Sprite.transform.localScale = new Vector3 (1, 1, 1);
		water3Sprite.transform.localScale = new Vector3 (1, 1, 1);
	}
	
}
