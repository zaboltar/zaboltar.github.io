using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_new_area : MonoBehaviour {

	public GameObject sp1, sp2;
	


	// Use this for initialization
	void Start () {
		
		sp1 = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D trig){
		if (Input.GetButtonDown("Jump")){
			trig.gameObject.transform.position = sp2.gameObject.transform.position;
			
		}
		

	

	}
}
