using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;
	private Transform playerPos;
	private Player player;
	public GameObject pfx;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		speed = 6f;
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}


	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			Instantiate(pfx, transform.position, Quaternion.identity);
			player.health--;
			Debug.Log(player.health);
			Destroy(gameObject);
		}
	
		if (other.CompareTag("bolt")){
			Instantiate(pfx, transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}




	}









}
