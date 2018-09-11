using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CatMovement : MonoBehaviour
{

    public int timeMin = 0;
    public int timeMax = 10;
    private GameObject playerStatus;
    private playerActions playerAct;
    private Rigidbody catBody;
    private float defaultHeight = 0.8f;
    float timer = 0.0f;
    float timeLimit = 0.0f;
    static System.Random rand;
    public float dist;
    public float effectDistLim;
    Vector3 targetDir = Vector3.zero;
    Vector3 randomDir = Vector3.zero;
    Vector3 rotation = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player");
        playerAct = playerStatus.GetComponent<playerActions>();
        catBody = this.GetComponent<Rigidbody>();
        Debug.Log(playerStatus.name);
        rand = new System.Random();
        rand.Next();
        timeLimit = rand.Next(timeMin, timeMax);
        rotation = new Vector3(0, rand.Next(), 0);
        transform.Rotate(rotation);
        randomDir = this.transform.forward;
        effectDistLim = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(playerStatus.transform.position, this.transform.position);

        
        if (playerAct.itemID == 1 && dist < effectDistLim)
        {
            //timer = 0.0f;
            //timeLimit = rand.Next(timeMin, timeMax);
            Vector3 target = new Vector3(playerStatus.transform.position.x, this.transform.position.y, playerStatus.transform.position.z);
            this.transform.LookAt(target);
            targetDir = new Vector3(playerStatus.transform.position.x - this.transform.position.x, this.transform.position.y, playerStatus.transform.position.z - this.transform.position.z);  //= this.transform.forward;
            Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 5.0f;
            catBody.MovePosition(nextPos);
        }
        else if (playerAct.itemID == 2 && dist < effectDistLim)
        {
            //timer = 0.0f;
            // timeLimit = rand.Next(timeMin, timeMax);
            Vector3 target = new Vector3(playerStatus.transform.position.x, this.transform.position.y, playerStatus.transform.position.z);
            this.transform.LookAt(target);
            targetDir = new Vector3(playerStatus.transform.position.x - this.transform.position.x, this.transform.position.y, playerStatus.transform.position.z - this.transform.position.z);  //= this.transform.forward;
            Vector3 nextPos = this.transform.position + -targetDir.normalized * Time.deltaTime * 5.0f;
            catBody.MovePosition(nextPos);

        }

        else if (playerAct.itemID == 0 || dist>= effectDistLim)
        {
            timer += Time.deltaTime;
            if (timer >= timeLimit)
            {
                timer = 0.0f;
                timeLimit = rand.Next(timeMin, timeMax);
                rotation = new Vector3(0, rand.Next(), 0);
                randomDir = this.transform.forward;
                transform.Rotate(rotation);


            }
            else
            {

            }
            transform.Translate(randomDir * Time.deltaTime);
        }


    }
}
