using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour {
    private GameObject playerStatus;
    private GameObject ratGoal;
    private int ratCount = 1;
    private bool returned;
    public bool returning;
    public float dist;
    Vector3 targetDir = Vector3.zero;
    private Rigidbody ratBody;

    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        playerStatus = GameObject.FindGameObjectWithTag("Player");
        ratGoal = GameObject.FindGameObjectWithTag("RatGoal");
        ratBody = this.GetComponent<Rigidbody>();



    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.name == "Rat Source")
        {
            print("source");

            this.gameObject.SetActive(false);
            returning = false;

            ratCount--;

        }
    }
        // Update is called once per frame
    void Update () {

        if (ratCount > 0)
        {
            if (returned != true)
            {
                var ratUse = Input.GetKeyDown(KeyCode.F);
                if (ratUse == true || returning == true)
                {
                    if(ratUse == true && returning == false)
                    {
                        this.transform.position = new Vector3(playerStatus.transform.position.x, this.transform.position.y, playerStatus.transform.position.z);
                        
                    }
                    returning = true;
                    this.gameObject.SetActive(true);
                    //print("Rat");
                    //this.gameObject.SetActive(true);
                    Vector3 target = new Vector3(ratGoal.transform.position.x, this.transform.position.y, ratGoal.transform.position.z);
                    this.transform.LookAt(target);
                    targetDir = new Vector3(ratGoal.transform.position.x - this.transform.position.x,0.5f, ratGoal.transform.position.z - this.transform.position.z);  //= this.transform.forward;
                    print(targetDir);
                    Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 5.0f;
                    nextPos.y = ratGoal.transform.position.y;
                    print(nextPos);
                    ratBody.MovePosition(nextPos);

                    /*
                    Vector3 target = new Vector3(ratGoal.transform.position.x, this.transform.position.y, ratGoal.transform.position.z);
                    this.transform.LookAt(target);
                    targetDir = new Vector3(ratGoal.transform.position.x - this.transform.position.x, this.transform.position.y, ratGoal.transform.position.z - this.transform.position.z);  //= this.transform.forward;
                    Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 5.0f;
                    ratBody.MovePosition(nextPos);
                    */
                }
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
	}
}
