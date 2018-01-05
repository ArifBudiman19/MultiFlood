using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public PlayerCharacter player;
	public int maxJump;
	private int _jumpCounter;
	private bool _jumping;
	private float _axisX;
	void Update(){
		if(player.isLanded){
			_jumpCounter = 0;
		}

		if(Input.GetButton("Jump") && !_jumping && _jumpCounter < maxJump){
			_jumping = true;
			player.Jumping();
		}

		if(player.isLanded){
			_jumping = false;
		}

	}

	void FixedUpdate()
	{
		_axisX = Input.GetAxis("Horizontal");
		if(_axisX != 0){
			if(_axisX < 0){
				player.isFacingRight = false;
			}else if(_axisX > 0){
				player.isFacingRight = true;
			}
			
			//if(player.rigid2D.velocity.x < player.maxSpeed)
			
			player.Move(_axisX);
		}


	}

	IEnumerator Jumping(float delay){
		_jumping = true;
		_jumpCounter++;
		player.Jumping();
		yield return new WaitForSeconds(delay);
		_jumping = false;
	}
}
