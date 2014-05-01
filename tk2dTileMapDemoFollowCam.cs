using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Holoville.HOTween;

public class tk2dTileMapDemoFollowCam : MonoBehaviour {
	
	public enum CameraControlPriority {
		NONE = 0,
		LOW = 1,
		MEDIUM = 2,
		HIGH = 3
	}
	
	public class CameraControl { 
		public int id;
		public CameraControlPriority priority;
		public Transform target;
		public Action onControlGained;
		public Action onControlLost;
	}
	
	tk2dCamera cam;
	public float followSpeed = 1.0f;
	
	public float minZoomSpeed = 20.0f;
	public float maxZoomSpeed = 40.0f;
	
	public float maxZoomFactor = 0.6f;

	public float minYPosition = 4.537476f;
	
	private List<CameraControl> listOfControls;
	private CameraControl currentControl;
	private Transform target;
	
	private int idCounter;
	private bool cameraControlDirty = false;
	
	void Start() {
		HOTween.Init( true, false, true );
		listOfControls = new List<CameraControl> ();
		Transform playerTransform = GameObject.Find ("Player").transform;
		RequestControl(CameraControlPriority.NONE, playerTransform);
		HOTween.To(GameObject.Find ("Fade").GetComponent<SpriteRenderer> (), 4f, new TweenParms().Prop("color", Color.clear));
	}
	
	void Awake() {
		cam = GetComponent<tk2dCamera>();
	}
	
	void FixedUpdate() {
		
		if (cameraControlDirty) {
			CameraControl control = null;
			
			foreach(CameraControl cameraControl in listOfControls) {
				if(control == null || control.priority < cameraControl.priority) {
					control = cameraControl;
				}
			}
			
			if (control != null) {
				
				if (this.currentControl != null && this.currentControl.onControlLost != null) {
					this.currentControl.onControlLost();
				}
				
				this.currentControl = control;
				
				if (this.currentControl.onControlLost != null) {
					control.onControlGained();
				}
				
				this.cameraControlDirty = false;
			}
		}
		
		Vector3 start = transform.position;
		Vector3 end = Vector3.MoveTowards(start, this.currentControl.target.position, followSpeed * Time.deltaTime);
		end.z = start.z;
		transform.position = end;
		
		if (this.currentControl.target.rigidbody != null && cam != null) {
			float spd = this.currentControl.target.rigidbody.velocity.magnitude;
			float scl = Mathf.Clamp01((spd - minZoomSpeed) / (maxZoomSpeed - minZoomSpeed));
			float targetZoomFactor = Mathf.Lerp(1, maxZoomFactor, scl);
			cam.ZoomFactor = Mathf.MoveTowards(cam.ZoomFactor, targetZoomFactor, 0.2f * Time.deltaTime);
		}

		if (transform.position.y < minYPosition) {
			transform.position = new Vector3(transform.position.x, minYPosition, transform.position.z);
		}
	}
	
	public void ReleaseControl(int id) {
		
		int index = -1;
		foreach(CameraControl cam in listOfControls) {
			if(cam.id == id) {
				index = listOfControls.IndexOf(cam);
			}
		}
		if (index > -1) {
			listOfControls.RemoveAt (index);
			this.cameraControlDirty = true;
		}
	}
	
	public int RequestControl(CameraControlPriority priority, Transform target, Action onControlGained, Action onControlLost) {
		
		this.cameraControlDirty = true;
		
		CameraControl control = new CameraControl ();
		
		control.priority = priority;
		control.target = target;
		control.onControlGained = onControlGained;
		control.onControlLost = onControlLost;
		control.id = ++idCounter;
		
		listOfControls.Add (control);
		
		return control.id;
	}
	
	public int RequestControl(CameraControlPriority priority, Transform target) {
		return this.RequestControl (priority, target, null, null);
	}
	
	
}

