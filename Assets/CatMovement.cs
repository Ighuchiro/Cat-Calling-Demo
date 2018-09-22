using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CatMovement : MonoBehaviour
{

    public int timeMin = 0;
    public int timeMax = 10;
    private GameObject playerStatus;
    private GameObject currentHazard;
    private GameObject ratObject;
    private GameObject noiseObject;

    private playerActions playerAct;
    private RatScript ratAct;

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
    private int collisionCount = 0;
    private float dist2=100.0f;
    public float ratDist;
    private int health;


    // Use this for initialization
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player");
        ratObject = GameObject.FindGameObjectWithTag("rat");
        ratAct = ratObject.GetComponent<RatScript>();
        noiseObject = GameObject.FindGameObjectWithTag("noise");
        playerAct = playerStatus.GetComponent<playerActions>();
        catBody = this.GetComponent<Rigidbody>();
        Debug.Log(playerStatus.name);
        rand = new System.Random();
        rand.Next();
        timeLimit = rand.Next(timeMin, timeMax);
        rotation = new Vector3(0, rand.Next(), 0);
        transform.Rotate(rotation);
        randomDir = this.transform.forward;
        effectDistLim = 5.0f;
        currentHazard = GameObject.FindGameObjectWithTag("Sphere");
        health = 2;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Noise")
        {
            if (noiseObject.GetComponent<Renderer>().enabled == true)
            {
                health--;
            }

        }
        if (other.gameObject.name == "Sphere")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere");
            health--;

        }
        if (other.gameObject.name == "Sphere (1)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (1)");
            health--;


        }
        if (other.gameObject.name == "Sphere (2)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (2)");
            health--;


        }
        if (other.gameObject.name == "Sphere (3)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (3)");
            health--;


        }
        if (other.gameObject.name == "Sphere (4)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (4)");
            health--;


        }
        if (other.gameObject.name == "Sphere (5)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (5)");
            health--;


        }
        if (other.gameObject.name == "Sphere (6)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (6)");
            health--;


        }
        if (other.gameObject.name == "Sphere (7)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (7)");
            health--;


        }
        if (other.gameObject.name == "Sphere (8)")
        {
            collisionCount++;
            currentHazard = GameObject.FindGameObjectWithTag("Sphere (8)");
            health--;


        }

    }
    void OnTriggerExit(Collider other)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(health == 2)
        {
            ///this.gameObject.gameObject.GetComponent<Material>().
        }
        if(health == 1)
        {

        }
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        dist = Vector3.Distance(playerStatus.transform.position, this.transform.position);
        dist2 = Vector3.Distance(currentHazard.transform.position, this.transform.position);
        ratDist = Vector3.Distance(ratObject.transform.position, this.transform.position);

        if (collisionCount > 0)
        {
            if (dist2 <= 10.0f)
            {
                Vector3 target = new Vector3(currentHazard.transform.position.x, this.transform.position.y, currentHazard.transform.position.z);
                this.transform.LookAt(target);
                targetDir = new Vector3(currentHazard.transform.position.x - this.transform.position.x, this.transform.position.y, currentHazard.transform.position.z - this.transform.position.z);  //= this.transform.forward;
                Vector3 nextPos = this.transform.position + -targetDir.normalized * Time.deltaTime * 5.0f;
                catBody.MovePosition(nextPos);
            }
            else
            {
                collisionCount = 0;
            }
        }
        else if (ratAct.returning == true && ratDist < 20.0f)
        {
            Vector3 target = new Vector3(ratObject.transform.position.x, this.transform.position.y, ratObject.transform.position.z);
            this.transform.LookAt(target);
            targetDir = new Vector3(ratObject.transform.position.x - this.transform.position.x, this.transform.position.y, ratObject.transform.position.z - this.transform.position.z);  //= this.transform.forward;
            Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 5.0f;
            catBody.MovePosition(nextPos);
        }
        else if (playerAct.itemID == 1 && dist < effectDistLim)
        {
            Vector3 target = new Vector3(playerStatus.transform.position.x, this.transform.position.y, playerStatus.transform.position.z);
            this.transform.LookAt(target);
            targetDir = new Vector3(playerStatus.transform.position.x - this.transform.position.x, this.transform.position.y, playerStatus.transform.position.z - this.transform.position.z);  //= this.transform.forward;
            Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 5.0f;
            catBody.MovePosition(nextPos);
        }
        else if (playerAct.itemID == 2 && dist < effectDistLim)
        {
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
