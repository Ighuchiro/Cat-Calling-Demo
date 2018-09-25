using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedAttractorScript : MonoBehaviour {

    private GameObject playerStatus;
    private playerActions playerAct;

    // Use this for initialization

    void Start () {
        this.transform.gameObject.SetActive(false);
        playerStatus = GameObject.FindGameObjectWithTag("Player");
        playerAct = playerStatus.GetComponent<playerActions>();
    }
	
	// Update is called once per frame
	void Update () {
        if(playerAct.itemID == 1)
        {

        }
        else
        {

        }
		
	}
}
