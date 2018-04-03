using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSync : MonoBehaviour, IPunObservable  {

	//data you want to pass to the network
	public float cr;
	public float cg;
	public float cb;

	//pull values from some other script on this gameobject
	public ChangeOwner co;

	//you need a PhotonView on this object, that sends the messages to the network
	PhotonView m_PhotonView;

	void Awake(){
		this.m_PhotonView = GetComponent<PhotonView>(); // make sure you have photon view attached to this gameobject and observe this script
	}
	void Start () {
		co = GetComponent<ChangeOwner> ();
	}
	
	// Update is called once per frame
	void Update () {


		//the if statement makes sure only the one that belongs to the master client can run the code inside
		if (m_PhotonView.isMine) {
			//pulling from script, and then writing the values to the variables that you want to send out
			cr = co.mycolor.r;
			cg = co.mycolor.g;
			cb = co.mycolor.b;
		}

		//you can check if you are the master client or not
		//Debug.Log (photonView.isMine);

		//update the color with the data you get, either from receiving(below) or from writing/pulling(above)
		this.GetComponent<Renderer> ().material.color = new Color (cr, cg, cb);

	}

	#region IPunObservable implementation
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		//only the object on the master client can stream out data
		if (stream.isWriting)
		{
			//sending
			stream.SendNext(this.cr);
			stream.SendNext(this.cg);
			stream.SendNext(this.cb);

		}
		else
		{
			//otherwise, everyone else in the room receives data
			//receiving
			this.cr = (float)stream.ReceiveNext();
			this.cg = (float)stream.ReceiveNext();
			this.cb = (float)stream.ReceiveNext();
		}
	}
	#endregion
}
