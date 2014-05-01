using UnityEngine;
using System;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Vector3 originPosition;
    Quaternion originRotation;
    
    public float shake_decay;
    public float shake_intensity;
	public float delay;
    Quaternion quat;

	private Action onCompleteAction;
          
    void Start() {
        quat = new Quaternion (0f, 0f, 0f, 0f);
        transform.rotation = quat;
    }

    void Update() {
        if (Time.time >= delay) {
			if (shake_intensity > 0) {
				transform.position = originPosition + UnityEngine.Random.insideUnitSphere * shake_intensity;
				quat.Set (
	        	originRotation.x + UnityEngine.Random.Range (-shake_intensity, shake_intensity) * .2f,
	        	originRotation.y + UnityEngine.Random.Range (-shake_intensity, shake_intensity) * .2f,
	        	originRotation.z + UnityEngine.Random.Range (-shake_intensity, shake_intensity) * .2f,
	        	originRotation.w + UnityEngine.Random.Range (-shake_intensity, shake_intensity) * .2f);
				shake_intensity -= shake_decay;
			} else if (onCompleteAction != null) {
				onCompleteAction ();
				onCompleteAction = null;
			}
		} else {
			originPosition = transform.position;
			originRotation = transform.rotation;
		}
    }

	public void Shake(float delay, float intensity, float decay, Action onCompleteAction){
		if (shake_intensity <= 0) {
			originPosition = transform.position;
			originRotation = transform.rotation;
			shake_intensity = intensity;
			shake_decay = decay;
		}
		this.delay = Time.time + delay;
		this.onCompleteAction = onCompleteAction;
	}

	public void Shake(float delay, float intensity, float decay){
		this.Shake (delay, intensity, decay, null);
	}

    public void Shake(float intensity, float decay){
		this.Shake (0, intensity, decay, null);
    }        
}
