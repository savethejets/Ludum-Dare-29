using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int numberOfBoxesToWin = 4;

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 1;
	}


	
	// Update is called once per frame
	void Update () {
	
//		if(Input.GetKeyDown(KeyCode.Alpha1)) {
//			GameObject.Find("Player").GetComponent<CarryWater>().addNote(CarryWater.NoteType.ONE);
//		}
//		if(Input.GetKeyDown(KeyCode.Alpha2)) {
//			GameObject.Find("Player").GetComponent<CarryWater>().addNote(CarryWater.NoteType.TWO);
//		}
//		if(Input.GetKeyDown(KeyCode.Alpha3)) {
//			GameObject.Find("Player").GetComponent<CarryWater>().addNote(CarryWater.NoteType.THREE);
//		}
//		if(Input.GetKeyDown(KeyCode.Alpha4)) {
//			GameObject.Find("Player").GetComponent<CarryWater>().addNote(CarryWater.NoteType.FOUR);
//		}
	}
}
