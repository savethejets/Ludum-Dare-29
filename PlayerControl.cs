using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	public float isGroundedTimeAllowance = 50f;

	float timeSinceOnPlatform = 0;
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private RaycastHit2D grounded;			// Whether or not the player is grounded.

	private tk2dSpriteAnimator anim;

	private AudioSource jumpSound;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");

		anim = GetComponent<tk2dSpriteAnimator> ();

		jumpSound = GetComponent<AudioSource> ();
	}


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump") && ((bool)grounded || timeSinceOnPlatform > 0)) {
			jump = true;
		}

		if (!(bool)grounded) {
			timeSinceOnPlatform -= 60 * Time.deltaTime;
		} else {
			timeSinceOnPlatform = isGroundedTimeAllowance;
		}
	}


	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		float maxSpeedTemp = maxSpeed;

		if (!((bool)grounded)) {
			anim.Play("jump");
			jumpSound.Play();
		} else {
			if(h > 0 && !anim.IsPlaying("walk")) {
				anim.Play("walk");
			} else {
				anim.Play("stand");
			}
		}

		if(h * rigidbody2D.velocity.x < maxSpeedTemp)
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
					
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeedTemp)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeedTemp, rigidbody2D.velocity.y);
			
		if(h > 0 && !facingRight)
			Flip();

		else if(h < 0 && facingRight)
			Flip();

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
//			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
//			int i = Random.Range(0, jumpClips.Length);
//			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
