using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Zorgt dat CameraObject(Het object waar de camera op orbit) op dezelfde positie zit als de player
        transform.position = player.position; 
	}
}
