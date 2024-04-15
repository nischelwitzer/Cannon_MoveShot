using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Debug.Log("destroy Shot");
        Destroy(this.gameObject, 5f); // delete after 5 sec 
    }

}
