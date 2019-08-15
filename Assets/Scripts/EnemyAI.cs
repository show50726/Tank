using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //all left wheels
    public GameObject[] LeftWheels;
    //all right wheels
    public GameObject[] RightWheels;

    public GameObject LeftTrack;

    public GameObject RightTrack;

    public GameObject Cannon;
    public GameObject Bullet;

    public Transform LaunchPoint;

    public float wheelsSpeed = 2f;
    public float tracksSpeed = 2f;
    public float forwardSpeed = 1f;
    public float rotateSpeed = 1f;
    public float cannonSpeed = 1.5f;

    public float dis;
    public float foundDis = 50f;
    public float attackDis = 10f;
    private Transform player;
    public Player p;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!p.isDeath())
        {
            dis = (player.position - transform.position).magnitude;

            if (dis < foundDis)
            {
                if (player.position.z - transform.position.z >= 0)
                {
                    GoForward();
                }
                else
                {
                    GoBackward();
                }

                /*if (player.position.x - transform.position.x > 0)
                {
                    GoRight();
                }
                else
                {
                    GoLeft();
                }
                */

                if (dis < attackDis)
                {
                    /*Vector3 targetDir = player.transform.position - transform.position;

                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0.0F);

                    Cannon.transform.rotation = Quaternion.LookRotation(newDir);
                    */
                    Cannon.transform.Rotate(new Vector3(0f, 0f, cannonSpeed));
                    count++;
                    if(count >= 10)
                    {
                        Attack();
                        count = 0;
                    }
                    
                }


            }
        }
    }

    private void GoForward()
    {
        if (player.position.x - transform.position.x > 0)
        {
            GoRight();
        }
        else
        {
            GoLeft();
        }
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);

        //Move Tank

        transform.Translate(new Vector3(0f, 0f, forwardSpeed * Time.deltaTime));

    }

    private void GoBackward()
    {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //Move Tank
        transform.Translate(new Vector3(0f, 0f, -forwardSpeed * Time.deltaTime));
    }

    private void GoRight()
    {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f));
    }

    private void GoLeft()
    {
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, -rotateSpeed, 0f));
    }

    private void Attack()
    {
        Instantiate(Bullet, LaunchPoint);
    }


}
