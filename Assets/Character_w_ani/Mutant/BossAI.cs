﻿//Game Programming HW1 
//===================================================================================================================
// Name        : HidingAI.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to Enemy2. Enemy 2 will turn and shoot player if within 15units.
//===================================================================================================================

using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 0.1f;
    public float closeDistance = 15.0F; //distance between player and enemy

    [SerializeField] private GameObject fireballPrefab1;
    [SerializeField] private GameObject fireballPrefab2;
    [SerializeField] private GameObject fireballPrefab3;
    [SerializeField] private GameObject fireballPrefab4;
    [SerializeField] private GameObject fireballPrefab5;
    [SerializeField] private GameObject fireballPrefab6;
    private GameObject _fireball;
    public Transform target;
    private bool _alive;
    private Animator _animator;

    float timer = 0;
    float waitingTime = 3.5f;

    void Start()
    {
        _alive = true;
    }


    void Update()
    {
        if (_alive)
        {
            _animator = GetComponent<Animator>();
            //transform.Translate(0, 0, speed * Time.deltaTime); // since enemy hides, no need to move

            if (GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health > 0)
            {
                Vector3 offset = GameObject.Find("Player").transform.position - transform.position;
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen < closeDistance * closeDistance && GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health > 0)
                {
                    //_animator.SetBool("isBreath", false);
                    //_animator.SetBool("isBreath", true);
                    //print("The other transform is close to me!");
                    //Debug.Log("THE PLAYERS Y VALUE: " + transform.position);
                    //transform.LookAt(GameObject.Find("Player").transform.position);

                    if (GameObject.Find("Player").transform.position != null)
                    {
                        //Debug.Log("The player position is " + GameObject.Find("Player").transform.position);

                    }
                    transform.LookAt(GameObject.Find("Player").transform.position);
                    timer += Time.deltaTime;
                    //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();
                    if (timer > waitingTime)
                    {

                        _animator.SetBool("isBreath", false);
                         _animator.SetBool("isBreath", true);
                        //Debug.Log("Is shooting");
                        transform.LookAt(GameObject.Find("Player").transform.position);

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(0, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(-1.25f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(1.25f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(-1.75f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(1.75f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(0.5f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;

                        _fireball = Instantiate(fireballPrefab1) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(-0.5f, 0.5f, 1 * 1.5f);
                        _fireball.transform.rotation = transform.rotation;



                        timer = 0;
                    }

                    

                }
                //has not seen me so just patrol
                else
                {
                    ////int randomPost = Random.Range(0,10);
                    //if (agent.remainingDistance < 0.5f)
                    //    GotoNextPoint();
                }

            }
            /* UNCOMMENT THIS FOR EXTREME MODE lol*/
            //      Ray ray = new Ray(transform.position, transform.forward);
            //      RaycastHit hit;
            //      GameObject hitObject;
            //          if (GameObject.Find("Player") && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health >= 0)
            //          {
            ////              if (GameObject.Find("Player").transform.position != null)
            ////              {
            ////                  //Debug.Log("The player position is " + GameObject.Find("Player").transform.position);
            ////              }
            ////              transform.LookAt(GameObject.Find("Player").transform.position);
            ////              //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();
            ////              if (_fireball == null)
            ////              {


            ////                  transform.LookAt(GameObject.Find("Player").transform.position);
            ////                  _fireball = Instantiate(fireballPrefab) as GameObject;
            ////_fireball.transform.position = transform.TransformPoint(0, 1.2f, 1 * 1.5f);
            ////                  _fireball.transform.rotation = transform.rotation;
            ////              }
            //          }
            //  }
        }
        else
        {
            _animator.SetBool("isDeadMut", true);
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}