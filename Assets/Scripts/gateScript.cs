using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateScript : MonoBehaviour
{
    int collisionCount = 0;
    bool open = false;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.name == "Player")
        {

            collisionCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.name == "Player")
        {
            collisionCount--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (collisionCount > 0)
        {
            var group1 = Input.GetKeyDown(KeyCode.O);
            if(group1 == true)
            {
                print("open");
                if (open == false)
                {
                    this.transform.Rotate(new Vector3(0, 90, 0));
                    open = true;
                }
                else
                {
                    this.transform.Rotate(new Vector3(0, -90, 0));
                    open = false;
                }
            }
        }
    }
}
