using UnityEngine;
using System.Collections;

public class PerpetualRotate : MonoBehaviour {

    
	float rotSpeed;
    public int mult;
    
	// Use this for initialization
	void Start () {
		
		rotSpeed = mult * 15.0f * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0.0f, 0.0f, rotSpeed));
	}
}
