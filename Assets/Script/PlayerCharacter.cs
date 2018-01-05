using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
	public Animator animator;
	public Rigidbody2D rigid2D;
	public SpriteRenderer sprite;
	public bool isLanded;
	public bool isFacingRight;
	public float jumpPower;
	public float speed;

	void FixedUpdate()
	{	
		 //Physics2D.Raycast(transform.position, Vector2.down, 0.1f, 1 << 8);
		RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.0f, 1 << 8);
		if(hit2D.collider != null){
			isLanded = true;
			rigid2D.velocity = rigid2D.velocity * 0.95f;
		}else{
			isLanded = false;
		}
		animator.SetBool("IsLanded", isLanded);

		Vector2 velocity = rigid2D.velocity;
		animator.SetFloat("SpeedX", Mathf.Abs(velocity.x));
		animator.SetFloat("SpeedY", velocity.y);

		if(sprite.flipX == isFacingRight){
			sprite.flipX = !isFacingRight;
		}
	}

	public void Jumping(){
		animator.SetTrigger("Jump");
		rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0f);
		rigid2D.AddForce(Vector2.up * jumpPower);
	}

	public void Move(float axis){
		//rigid2D.AddForce(Vector2.right * axis * speedPower);
		rigid2D.AddForce((speed*axis - rigid2D.velocity.x) * Vector2.right * rigid2D.mass / Time.fixedDeltaTime);
	}
}
