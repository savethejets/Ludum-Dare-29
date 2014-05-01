using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum MoveDirection
	{
		Right,
		Left,
		Up,
		Down
	}

	public MoveDirection facingDirection;

	private tk2dSpriteAnimator _anim;
	private CharacterController2D _characterController;
	private tk2dSprite _sprite;

	public float runVelocity;
	public float maxVelocityX;
	public float drag;
	public float airDrag;
	public float runVelocityAirModifier;
	public float jumpVelocity;
	public float gravity;
	public float jumpErrorTickAllowance;

	private bool wasNotGroundedLastUpdate = false;

	private float bounceVelocity = 0;

	private float jumpPostGroundedTimer;
	private AudioSource _audio;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<tk2dSpriteAnimator>();
		_characterController = GetComponent<CharacterController2D>();
		_sprite = GetComponent<tk2dSprite> ();
		_audio = GetComponent<AudioSource> ();
		_audio.volume = 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

		Vector3 velocity = _characterController.velocity;

		if (_characterController.isGrounded) {
			velocity.y = 0;
		}
						
		float h = Input.GetAxis("Horizontal");

		if(h > 0) {
			if (_characterController.isGrounded) {
				velocity.x += runVelocity;
			} else {
				velocity.x += runVelocity * runVelocityAirModifier;
			}
			Flip(MoveDirection.Right);
		} else if(h < 0) {
			if (_characterController.isGrounded) {
				velocity.x += -runVelocity;
			} else {
				velocity.x += -runVelocity * runVelocityAirModifier;
			}
			Flip(MoveDirection.Left);
		} else {
			if(_characterController.isGrounded) {
				velocity.x -= velocity.x * drag;
			} else {
				velocity.x -= velocity.x * airDrag;
			}
		}

		velocity.x = Mathf.Clamp (velocity.x, -maxVelocityX, maxVelocityX);

		if (!_characterController.isGrounded) {
			_anim.Play("jump");
		} else {

			double velocityForStop = 0.1;
			if((h > velocityForStop || h < -velocityForStop) && !_anim.IsPlaying("walk")) {
				_anim.Play("walk");
			} 

			if(velocity.x < velocityForStop && velocity.x > -velocityForStop) {
				_anim.Play("stand");
			}
		}

		if (Input.GetButtonDown ("Jump") && (_characterController.isGrounded || jumpPostGroundedTimer > 0)) {
			velocity.y = jumpVelocity;
			_audio.Play();
		}

		velocity.y += bounceVelocity;

		bounceVelocity = 0;

		if(!_characterController.isGrounded) {
			jumpPostGroundedTimer -= 60 * Time.deltaTime;
		} else {
			jumpPostGroundedTimer = jumpErrorTickAllowance;
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			GetComponent<CarryWater>().ReleaseAllNotes();
		}

		velocity.y += gravity * Time.deltaTime;

		_characterController.move (velocity * Time.deltaTime);
	}

	public void Bounce(float jumpForceModifier) {
		bounceVelocity = jumpVelocity + jumpForceModifier;
	}

	void Flip (MoveDirection moveDirection)
	{
		if (moveDirection != facingDirection) {
			facingDirection = moveDirection;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}		
	}
}
