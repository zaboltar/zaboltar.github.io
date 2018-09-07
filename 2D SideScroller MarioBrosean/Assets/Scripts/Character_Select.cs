using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character_Select : MonoBehaviour {

	

	public void ChooseCharacter (int characterIndex) {
		PlayerPrefs.SetInt("SellectedCharacter", characterIndex);
	}


	public void LoadScene () {
		SceneManager.LoadScene ("proto1");
	}

	void Update (){
		
	}
}