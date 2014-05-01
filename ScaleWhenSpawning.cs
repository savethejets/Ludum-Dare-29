using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class ScaleWhenSpawning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpawnObject> ().addSpawnEvent (new SpawnObject.SpawnEvent (this.scaleWhenSpawn));
	}

	void scaleWhenSpawn(Transform instance) {
		tk2dSprite sprite = instance.GetComponentInChildren<tk2dSprite> ();
		sprite.scale = new Vector2 (0, 0);
		HOTween.To (sprite, 0.5f, new TweenParms ().Prop ("scale", new Vector3(1,1,1)));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
