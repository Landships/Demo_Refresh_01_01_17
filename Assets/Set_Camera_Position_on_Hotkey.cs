using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Camera_Position_on_Hotkey : MonoBehaviour {

    public GameObject cameraRig;
    public GameObject correctPos;
    public GameObject cameraHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("c") == true) {

            

            Vector3 distanceToMove =  correctPos.transform.position - cameraHead.transform.position;

            Debug.Log(distanceToMove);

            cameraRig.transform.Translate(distanceToMove, Space.World);

        }



    }
}
