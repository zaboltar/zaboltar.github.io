using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

	public int playerSpeed = 10;
	
	public int playerJumpPower = 2250;
	private float moveX;
	public bool isGrounded;
	public float distanceToBottomOfPlayer = 1.1f;

	// Update is called once per frame
	void Update () {
		PlayerMove ();
		PlayerRaycast ();
	}

	void PlayerMove(){
		//controls
		moveX = Input.GetAxis("Horizontal");
		if(Input.GetButtonDown("Jump") && isGrounded == true){
			Jump();
		}
		//animations

		if (moveX != 0){
			GetComponent<Animator>().SetBool ("isRunning", true);
			} else {
			GetComponent<Animator>().SetBool ("isRunning", false);
				}		
			
		//directionofplayer
		if (moveX < 0.0f)  {
			GetComponent<SpriteRenderer>().flipX = true;
		} else if (moveX > 0.0f){
			GetComponent<SpriteRenderer>().flipX = false;
		}
		//physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		//Jumping code
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	} 

	void PlayerRaycast () {

		// fix this, dice el youtuber, como siempre ptm.
		// ray up
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "box2stone") {
			Destroy (rayUp.collider.gameObject);
			
		}
		
		// ray down
		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			rayDown.collider.gameObject.GetComponent<Enemy_Move> ().enabled = false;

			// Destroy (hit.collider.gameObject);
			// esto funcionaba arriba, pero ahora se le quita el collider y el enemy se queda sin piso
		}
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy") {
			isGrounded = true;
		}
	}

}
