// MoveTo.cs
using PixelCrushers.DialogueSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    public GameObject clickImage;
    private NavMeshAgent agent;
    private GameObject hitImage;
    private Animator animator;
    private DoorHandler doorHandler;
    public bool entered = false;
    public bool alley = false;
    public bool chopshop = false;
    private Vector3 doorPos;
    

    void Start()
    {
        doorHandler = GetComponent<DoorHandler>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitinfo, 100f, 1 << 6))
            {
                if (hitImage)
                {
                    hitImage.GetComponent<ParticleSystem>().Stop();
                    Destroy(hitImage);
                }
                agent.SetDestination(hitinfo.point);
                hitImage = Instantiate(clickImage, hitinfo.point, Quaternion.identity);
                hitImage.GetComponent<ParticleSystem>().Play();
                if (agent.velocity.magnitude >= 0)
                {
                    animator.SetBool("isWalking", true);
                } else
                {
                    animator.SetBool("isWalking", false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            if (!entered) {
                doorHandler.moveDoor = true;
                //agent.SetDestination(doorHandler.exitPoint.position);
                StartCoroutine(WaitForDoor(doorHandler.exitPoint.position));
            }
            else if (entered)
            {
                doorHandler.moveDoor = true;
                //agent.SetDestination(doorHandler.enterPoint.position);
                StartCoroutine(WaitForDoor(doorHandler.enterPoint.position));

            }
        }
        else if (other.tag == "Alley")
        {
        }
        else if (other.tag == "AI")
        {
            //other.GetComponent<DialogueSystemTrigger>().SendMessage();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            entered = !entered;
            doorHandler.moveDoor = false;
        }
        else if (other.tag == "Alley")
        {
            alley = !alley;
        }
        else if (other.tag == "Chopshop")
        {
            chopshop = !chopshop;
        }
    }

    IEnumerator WaitForDoor(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(pos);
    }
}
