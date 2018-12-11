//Game Programming HW1 
//===========================================================================================
// Name        : RunAwayAI.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Attached to Enemy 3. Will turn around and run if player gets in front of it.
//===========================================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RunAwayAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;
    public float closeDistance = 15.0F; //distance between player and enemy

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public Transform target;
    private bool _alive;
    private bool _isSeen;
    private bool _isSaved= false; //HW3 Bystander has been seen and ready for rescue
    //private bool _aliveAnim;
    private Animator _animator;
    private NavMeshAgent agent;


    void Start()
    {
        _alive = true;
        //_animator.SetBool("isDeadBy", false);
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_alive)
        {
            _animator = GetComponent<Animator>();

            if (_isSeen)
            {

                //transform.Translate(0, 0, speed * Time.deltaTime); // will not move 
            }
            if (_isSaved) {
                target = GameObject.FindWithTag("Player").transform;
                transform.rotation = Quaternion.Slerp(transform.rotation,
Quaternion.LookRotation(target.position - transform.position), 3 * Time.deltaTime);
                transform.position += transform.forward * 3 * Time.deltaTime;
                SceneManager.LoadScene("scene3"); //it does change 
            }

            ////If player is next to enemy2it shall lock on to them
            //Vector3 offset = GameObject.Find("Player").transform.position - transform.position;
            //float sqrLen = offset.sqrMagnitude;
            //if (sqrLen < closeDistance * closeDistance)
            //{
            //    print("The other transform is close to me!");
            //    transform.LookAt(GameObject.Find("Player").transform.position);
            //}

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 1.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {

                    //transform.Rotate(0, Random.Range(180, 360), 0);
                    //transform.Translate(0, 0, speed * Time.deltaTime);
                    _isSeen = true;
                    _animator.SetBool("isSeen", true);
                    //agent.destination = GameObject.Find("HelpStop").transform.position;
                    Debug.Log("Bystander should run to base for help");
                    if (GameObject.Find("Player").transform.position != null)
                    {
                        _isSaved = true;
                        //agent.destination = GameObject.Find("HelpStop").transform.position; //to go to a specific location
                        //Debug.Log("The player position is " + GameObject.Find("Player").transform.position);
                        //Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
                      



                    }
                    //transform.LookAt(GameObject.Find("Player").transform.position);
                    //PlayerCharacter playerPosition = GetComponent<PlayerCharacter>();

                    if (_fireball == null)
                    {
                        // transform.LookAt(GameObject.Find("Player").transform.position);
                        // _fireball = Instantiate(fireballPrefab) as GameObject;
                        // _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        // _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    //float angle = Random.Range(180, 360);
                    //transform.Rotate(0, angle, 0);
                }
            }
        }
        else
        {
            _animator.SetBool("isDeadBy", true);
            agent.SetDestination(transform.position);
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}