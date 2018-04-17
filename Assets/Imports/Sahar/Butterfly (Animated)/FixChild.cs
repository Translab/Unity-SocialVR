using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localPosition = Vector3.zero;
	}
}
