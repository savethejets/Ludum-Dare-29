using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public CarryWater.NoteType noteType;

	public bool isDead = false;

	// Use this for initialization
	void Start () {
		tk2dSprite sprite = GetComponentInChildren<tk2dSprite> ();
		float alpha = sprite.color.a;
		sprite.color = CarryWater.getColorFromNoteType (noteType, (byte) Mathf.Floor(alpha == 1.0f ? 255 : alpha * 256.0f));
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.transform.name.Equals ("Player") && !isDead) {
			CarryWater water = other.transform.GetComponent<CarryWater>();
			water.addNote(noteType);
			this.isDead = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
