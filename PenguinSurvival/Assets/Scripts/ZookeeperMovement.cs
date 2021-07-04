using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZookeeperMovement : MonoBehaviour
{
    Transform target;
    [SerializeField] float trackingTime;
    [SerializeField] NavMeshAgent agent;
    bool isFollowing;
    [SerializeField] float speed;
    float resetSpeed;
    [SerializeField] float reducedSpeed = 2f;
    [SerializeField] bool flank = false;
    [SerializeField] float distanceToFlank = 5f;
    int rand;


    private void Awake()
    {
        resetSpeed = speed;
        rand = Random.Range(0, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.GetPlayerTransform();

        agent.speed = speed;
        
        //StartCoroutine(TrackPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFollowing && agent.isOnNavMesh)
        {
            StartCoroutine(TrackPlayer());
        }
    }

    IEnumerator TrackPlayer()
    {
        isFollowing = true;
        while (true)
        {
            if (!agent.isOnNavMesh)
            {
                isFollowing = false;
                StopAllCoroutines();
                break;
            }

            if (flank)
            {
                //Try to flank player
                agent.SetDestination(Flank());


            } else
            {
                agent.SetDestination(target.position);
            }

            
            


            if(target == null)
            {
                break;
            }else
            {
                yield return new WaitForSeconds(trackingTime);
            }
        }
    }


    public void Slowed()
    {
        agent.speed = reducedSpeed;
    }

    public void ResetSpeed()
    {
        agent.speed = resetSpeed;
    }

    Vector3 Flank()
    {
        

        if(rand == 0)
        {
            Vector3 dir = target.position - this.transform.position;
            dir.Normalize();
            // dir =  -dir* distanceToFlank;

            Vector3 actualPos = (target.position) + -target.right * distanceToFlank;

            return actualPos;
        }
        else
        {
            Vector3 dir = target.position - this.transform.position;
            dir.Normalize();
            // dir =  -dir* distanceToFlank;

            Vector3 actualPos = (target.position) + target.right * distanceToFlank;

            return actualPos;
        }
        


    }

    public float DistanceToTarget()
    {
        return Vector3.Distance(this.transform.position, target.position);
    }


}
