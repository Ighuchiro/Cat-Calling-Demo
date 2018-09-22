using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoxScript : MonoBehaviour {
    private GameObject playerStatus;
    private playerActions playerAct;
    private GameObject sprinklerGroup1;
    private GameObject sprinklerGroup2;
    private GameObject sprinklerGroup3;
    private int collisionCount = 0;
    public int sprinklerPattern = 1;


    // Use this for initialization
    void Start () {
        playerStatus = GameObject.FindGameObjectWithTag("Player");
        playerAct = playerStatus.GetComponent<playerActions>();
        sprinklerGroup1 = GameObject.FindGameObjectWithTag("SprinklerGroup1");
        sprinklerGroup2 = GameObject.FindGameObjectWithTag("SprinklerGroup2");
        sprinklerGroup3 = GameObject.FindGameObjectWithTag("SprinklerGroup3");
        sprinklerGroup3.SetActive(false);
    }



    void OnTriggerEnter(Collider other)
    {
        print("collide");
        //Destroy(other.gameObject);
        if (other.gameObject.name == "Player")
        {
            print("player");

            collisionCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        print("leaving");
        //Destroy(other.gameObject);
        if (other.gameObject.name == "Player")
        {
            collisionCount--;
        }
    }

    // Update is called once per frame
    void Update () {
        if (collisionCount > 0)
        {
            var group1 = Input.GetKeyDown(KeyCode.Z);
            var group2 = Input.GetKeyDown(KeyCode.X);
            var group3 = Input.GetKeyDown(KeyCode.C);
            if (group1 == true)
            {
                sprinklerPattern = 1;
                sprinklerGroup1.SetActive(true);
                sprinklerGroup2.SetActive(true);
                sprinklerGroup3.SetActive(false);
            }
            if (group2 == true)
            {
                sprinklerPattern = 2;
                sprinklerGroup1.SetActive(true);
                sprinklerGroup2.SetActive(false);
                sprinklerGroup3.SetActive(true);
            }
            else if (group3 == true)
            {
                sprinklerPattern = 3;
                sprinklerGroup1.SetActive(false);
                sprinklerGroup2.SetActive(true);
                sprinklerGroup3.SetActive(true);
            }
        }
    }
}
