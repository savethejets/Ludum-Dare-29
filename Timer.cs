using UnityEngine;
using System.Collections.Generic;
using System;

public class Timer : MonoBehaviour
{

	public List<TimerEvent> events;

	// Use this for initialization
	void Start ()
	{

	}

	public void Init() {
		this.events = new List<TimerEvent> ();
	}
    
	// Update is called once per frame
	void Update ()
	{
		if (this.events != null) {
            for (int i = this.events.Count - 1; i >= 0; i--) {
                TimerEvent timerEvent = events [i];
                if (Time.time >= timerEvent.timeShouldFire) {
                    timerEvent.doAction ();
                    if (!timerEvent.repeat) {
                        this.events.Remove (timerEvent);
                    } else {
                        timerEvent.Renew ();
                    }
                }
            }
        }

	}
      
	public class TimerEvent
	{

		public Action method;
		public float timeShouldFire;
		public bool repeat;
		public float delay;
		public bool fired;

		public TimerEvent (Action method, float delay, bool repeat)
		{
			this.method = method; 
			this.timeShouldFire = Time.time + delay;
			this.delay = delay;
			this.repeat = repeat;
		}

		public void doAction ()
		{
			method ();
			this.fired = true;
		}
    		
		public void Renew ()
		{
			this.timeShouldFire = Time.time + this.delay;	
		}
	}

	public void AddEvent (TimerEvent timerEvent)
	{
		this.events.Add (timerEvent);
	}
}
