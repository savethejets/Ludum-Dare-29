using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour {

	private float x;

	public int offset;
	public bool followCamera;

	// Use this for initialization
	void Start () {
		x = Camera.main.transform.position.x;
		Debug.Log (x);
	}
	
	// Update is called once per frame
	void Update () {
		if (followCamera) {
			transform.position = new Vector3((Camera.main.transform.position.x - x) / offset , transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3((x - Camera.main.transform.position.x)/ offset, transform.position.y, transform.position.z);
		}
	}
}
