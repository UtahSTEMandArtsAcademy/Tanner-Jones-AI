using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



// create state machiene to change how the ai funcitions 
public enum Thought {
    Chasing,
    Running,
    Wander
}

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    //float closestDistance = Mathf.Infinity;
    private NavMeshAgent agent;
    //public Transform Target;
    public float wait;
    public bool Run;
    public GameObject bullet;
    public FloatData speed;
    //ublic int number;
    public Material mat, mat2, mat3;
    public Thought tot;
    //public GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {
        //number = Random.Range(0, 2);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (tot)
        {
            case Thought.Chasing:
                gameObject.tag = "Chase";
                GameObject targ = null;
                GameObject[] ChaseObject = GameObject.FindGameObjectsWithTag("Chased");
                this.gameObject.GetComponent<Renderer>().material = mat;
                for (int i = 0; i < ChaseObject.Length; i++)
                {
                    float NewDistance = Vector3.Distance(transform.position, ChaseObject[i].transform.position);
                    float distance = Vector3.Distance(transform.position, targ?.transform.position ?? transform.position);
                    if (distance == 0 || NewDistance <= distance)
                    {
                        targ = ChaseObject[i];
                    }
                }
                if (targ == null)
                {
                    int chance = Random.Range(0, 1);
                    if (chance == 0)
                    {
                        Vector3 spawn = new Vector3(Random.Range(-50, 50), Random.Range(0, 50), Random.Range(-50, 50)) + Random.insideUnitSphere * 100f;//Random.insideunitcircle to determin position
                        NavMeshHit hit;
                        if (NavMesh.SamplePosition(spawn, out hit, 1.0f, NavMesh.AllAreas))
                        {
                            transform.position = hit.position;
                        }
                        tot = Thought.Wander;
                        Debug.Log("Shrek");

                    }
                }
                if (agent.isPathStale)
                {
                    agent.autoRepath = true;
                }
                else
                {
                    agent.autoRepath = false;
                }
                agent.SetDestination(targ.transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10))); //error nullref after a little bit
                agent.speed = speed.value;
                break;

            case Thought.Running:
                this.gameObject.GetComponent<Renderer>().material = mat2;
                gameObject.tag = "Chased";
                GameObject targ1 = null;
                GameObject[] ChaseObject1 = GameObject.FindGameObjectsWithTag("Chase");



                for (int i = 0; i < ChaseObject1.Length; i++)
                {
                    float NewDistance = Vector3.Distance(transform.position, ChaseObject1[i].transform.position);
                    float distance = Vector3.Distance(transform.position, targ1?.transform.position ?? transform.position);

                    if (distance == 0 || NewDistance <= distance)
                    {
                        targ1 = ChaseObject1[i];

                    }
                }




                Vector3 speculative = transform.position + (transform.position - targ1.transform.position);
                //agent.SetDestination(Quaternion.AngleAxis(Random.Range(-15f, 15f), ));   SetDestination requires a Vector
                if (speculative.x <= 10 || speculative.z <= 10)
                {
                    agent.SetDestination(speculative + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
                    if (agent.velocity.x > 0 || agent.velocity.z > 0)
                    {
                        //this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                    }
                }
                else
                {
                    tot = Thought.Wander;
                }
                
                if (agent.isPathStale)
                {
                    agent.autoRepath = true;
                }
                else
                {
                    agent.autoRepath = false;
                }

                agent.speed = speed.valueTwo;
                break;

            case Thought.Wander:
                this.gameObject.GetComponent<Renderer>().material = mat3;
                gameObject.tag = "Chased";
                wait -= Time.deltaTime;
                if (wait <= 0)
                {
                    Vector3 wander = new Vector3(Random.Range(-50, 50), Random.Range(1, 22), Random.Range(-50, 50));
                    agent.SetDestination(wander);
                    wait = 24f;
                }
                GameObject targ2 = null;
                GameObject[] ChaseObject2 = GameObject.FindGameObjectsWithTag("Chase");
                for (int i = 0; i < ChaseObject2.Length; i++)
                {
                    float NewDistance = Vector3.Distance(transform.position, ChaseObject2[i].transform.position);
                    float distance = Vector3.Distance(transform.position, targ2?.transform.position ?? transform.position);
                    if (distance == 0 || NewDistance <= distance)
                    {
                        targ2 = ChaseObject2[i];
                    }
                }
                    Vector3 speculative2 = transform.position + (transform.position - targ2.transform.position);
                    //agent.SetDestination(Quaternion.AngleAxis(Random.Range(-15f, 15f), ));   SetDestination requires a Vector
                    if (speculative2.x <= 10 || speculative2.z <= 10)
                    {
                        tot = Thought.Running;
                    }
                    break;
                



        }
    }

        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Chase") && gameObject.tag == "Chased")
            {
                StartCoroutine(chagneTag());

            }
            //if (other.gameObject.CompareTag("Chased") && gameObject.tag == "Chase")
            //{
            //    Debug.Log("E");
            //    Run = !Run;
            //}
        }
        IEnumerator chagneTag()
        {
            yield return new WaitForSeconds(0.1f);
            tot = Thought.Chasing;
            

        }
    
}