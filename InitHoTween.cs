using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class InitHoTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HOTween.Init(true, false, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
