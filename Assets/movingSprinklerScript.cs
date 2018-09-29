using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingSprinklerScript : MonoBehaviour {
    private Vector3 target;
    private Vector3 startPos;
    private Vector3 endPos;
    public float scale;
    public float maxRotation;
    public float originalRot;
    public float currrentGoal;
    public float minRot;
    private bool rotated;
    public  Vector3 targetDir;
    public  Vector3 newDir;


    // Use this for initialization
    void Start () {
        startPos = transform.position;
        scale = 0.08f;
        maxRotation = 45f;
        originalRot = transform.rotation.y;
        currrentGoal = maxRotation;
        minRot = transform.rotation.y;
        rotated = false;
        if(transform.position.x >= 0.0f && transform.rotation.y > 0)
        {
            target = new Vector3(startPos.x + 1, startPos.y, startPos.z);
        }
        else
        {
            target = new Vector3(startPos.x - 1, startPos.y, startPos.z);

        }
    }

// Update is called once per frame
void Update () {
        //float angle = Quaternion.Angle(a, b);

        //bool sameRotation = Mathf.Abs(angle) < 1e-3f;
        //if (transform.eulerAngles == )
        /*
        if (this.transform.rotation.y >= maxRotation || this.transform.rotation.y <= minRot)
        {
            currrentGoal = -currrentGoal;
            print("direction change");
        }
        target = transform.eulerAngles + currrentGoal * Vector3.up;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, target, scale * Time.deltaTime);
        */
        /*
        transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * scale), 0f);
        */
        targetDir = target - transform.position;

        // The step size is equal to speed times frame time.
        float step = scale * Time.deltaTime;

        newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        if((rotated == false && Mathf.Abs(targetDir.x - newDir.x) <= .0001) || (rotated == true && Mathf.Abs(targetDir.z - newDir.z) <= .0001))
        {

            if(rotated == true)
            {
                rotated = false;
                if (transform.position.x >= 0.0f && transform.rotation.y > 0)
                {
                    target = new Vector3(startPos.x+ 1, startPos.y, startPos.z);
                }
                else
                {
                    target = new Vector3(startPos.x - 1, startPos.y, startPos.z);

                }
                targetDir = target - transform.position;
                newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            }

            else
            {
                rotated = true;
                if (transform.position.x >= 0.0f && transform.rotation.y > 0)
                {
                    target = new Vector3(startPos.x, startPos.y, startPos.z - 1);
                }
                else
                {
                    target = new Vector3(startPos.x, startPos.y, startPos.z + 1);

                }
                targetDir = target - transform.position;
                newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            }

        }
        //Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
