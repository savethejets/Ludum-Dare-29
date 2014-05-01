using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class FinishLevelScript : MonoBehaviour {

	public int levelToTransitionTo;

	// Use this for initialization
	void Start () {
		GetComponent<Box> ().AddEvent (new Box.BoxFilledEvent(this.FinishLevel));
	}

	public void FinishLevel() {
		HOTween.To (Camera.main.GetComponent<tk2dCamera> ().camera, 8.0f, new TweenParms ().Prop ("backgroundColor", (Color) new Color32 (129, 184, 209, 255)).OnComplete(this.TransitionLevel));
	}

	public void TransitionLevel() {
		HOTween.To(GameObject.Find ("Fade").GetComponent<SpriteRenderer> (), 4f, new TweenParms().Prop("color", Color.black).OnComplete(this.LoadLevel));	
	}

	public void LoadLevel() {
		Application.LoadLevel(levelToTransitionTo);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
