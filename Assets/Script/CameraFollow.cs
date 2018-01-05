using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;
	public float speed = 1.0f;

	void FixedUpdate()
	{
		Vector2 playerPosition = player.transform.position;
		Vector3 newPos;
		if(playerPosition.y > 0){
			newPos = new Vector3(transform.position.x + offset.x, playerPosition.y + offset.y, transform.position.z + offset.z);
			transform.position = Vector3.Lerp(transform.position, newPos, Time.fixedDeltaTime * speed);
		}else{
			newPos = new Vector3(transform.position.x + offset.x, 0 , transform.position.z + offset.z);
			transform.position = Vector3.Lerp(transform.position, newPos, Time.fixedDeltaTime * speed * 5);
		}
	}
}
