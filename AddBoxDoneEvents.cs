using UnityEngine;
using System;
using System.Collections;

public class AddBoxDoneEvents : MonoBehaviour {

	public DestructableWall wall;

	// Use this for initialization
	void Start () {
		GetComponent<Box> ().AddEvent (new Box.BoxFilledEvent (wall.DestroyWall));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
