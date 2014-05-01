using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class DestructableWall : MonoBehaviour {
		
	public float delay = 2;

	private int cameraControlId;
	public Vector2 finalDimension;

	// Use this for initialization
	void Start () {
	
	}

	public void DestroyWall() {

		tk2dTileMapDemoFollowCam cam = Camera.main.GetComponent<tk2dTileMapDemoFollowCam> ();
		CameraShake shake = Camera.main.GetComponent<CameraShake> ();

		cameraControlId = cam.RequestControl(tk2dTileMapDemoFollowCam.CameraControlPriority.HIGH, transform);

		shake.Shake (delay, 0.4f, 0.001f);

		tk2dTiledSprite sprite = GetComponent<tk2dTiledSprite> ();

		HOTween.To (sprite, 5f, new TweenParms ().Prop ("dimensions", finalDimension).OnComplete(this.DestroyWallDone).Delay(delay));
	}

	public void DestroyWallDone() {
		tk2dTileMapDemoFollowCam cam = Camera.main.GetComponent<tk2dTileMapDemoFollowCam> ();
		
		cam.ReleaseControl (cameraControlId);

		Destroy (GetComponent<BoxCollider2D>());
	}

	// Update is called once per frame
	void Update () {
	
	}
}
