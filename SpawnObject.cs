using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpawnObject : MonoBehaviour {

	public GameObject objectToSpawn;
	public float secondsBetweenSpawn;

	public bool destroyObjectAfterTime;
	public float timeTillDestroy;

	private Timer timer;

	private List<SpawnEvent> events;

	void Awake() {
		events = new List<SpawnEvent> ();
	}

	// Use this for initialization
	void Start () {
		timer = this.GetComponent<Timer> ();
		timer.Init ();
		timer.AddEvent(new Timer.TimerEvent(this.Spawn, secondsBetweenSpawn, true));
	}

	void Spawn() {
		GameObject instance = (GameObject) GameObject.Instantiate (objectToSpawn, transform.position, transform.rotation);

		if (destroyObjectAfterTime) {
			Destroy(instance, timeTillDestroy);
		}

		foreach (SpawnEvent e in events) {
			e.doAction(instance.transform);
		}
	}

	public void addSpawnEvent(SpawnEvent spawnEvent) {
		events.Add (spawnEvent);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public class SpawnEvent {
		public Action<Transform> method;

		public SpawnEvent (Action<Transform> method)
		{
			this.method = method; 		
		}
		
		public void doAction (Transform instance)
		{
			method.Invoke (instance);
		}

	}
}
