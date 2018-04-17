using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOwner : Photon.MonoBehaviour {

	public VRTK.VRTK_InteractableObject toss;
	float spinSpeed = 60f;
	public Color mycolor = Color.white;

	void Start(){
		toss.InteractableObjectGrabbed += Toss_InteractableObjectGrabbed;
		toss.InteractableObjectUngrabbed += Toss_InteractableObjectUngrabbed;
	}

	void Update(){
		transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
	}

	void Toss_InteractableObjectGrabbed (object sender, VRTK.InteractableObjectEventArgs e)
	{
		toss.GetComponent<PhotonView> ().TransferOwnership (PhotonNetwork.player.ID);
		mycolor = Color.blue;
		spinSpeed = 0f;

	}
	void Toss_InteractableObjectUngrabbed (object sender, VRTK.InteractableObjectEventArgs e)
	{
		// set the object's owner to be scene, which is 0, so that they dont get destroyed when the player leave the room
		toss.GetComponent<PhotonView> ().TransferOwnership (0); 
		mycolor = Color.white;
		spinSpeed = 60f;
	}


		
}
