// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    private NavMeshAgent agent;
    private GameObject hitImage;
    public GameObject clickImage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitinfo, 100f))
            {
                if(agent.velocity.magnitude <= 0)
                {
                    if(hitImage)
                    {
                        hitImage.GetComponent<ParticleSystem>().Stop();
                        Destroy(hitImage);
                    }
                    agent.SetDestination(hitinfo.point);
                    hitImage = Instantiate(clickImage, hitinfo.point, Quaternion.identity);
                    hitImage.GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
}
