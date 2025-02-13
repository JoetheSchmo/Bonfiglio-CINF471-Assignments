using UnityEngine;

public class FoeController : MonoBehaviour
{

    private enum State 
    {
        Idle, //Pace back and forth
        Chase, //Chase the player
        Stalk, //Hunt last know position of the player
    }

    private State currentState = State.Idle;

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    float speed = 2;
    int health = 4;
    Vector3 lastKnownPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Idle:
                OnPace();
                break;
            case State.Chase:
                OnFollow();
                break;
            case State.Stalk:
                OnStalk();
                break;
        }
    }

    void OnPace()
    {
        print("vibing and thriving");

        //What do we do when we're pacing?
        target = route[routeIndex];

        MoveTo(target.transform.position, speed);

        if(Vector3.Distance(transform.position, target.transform.position) <= 0.1){
            routeIndex++;
            if (routeIndex > route.Length - 1)
            {
                routeIndex = 0;
            }
        }

        //Switch to chase
        GameObject obsticle = CheckForward();

        if (obsticle != null){
            currentState = State.Chase;
            target = obsticle;
        }

        

    }

    void OnFollow()
    {
        print(">:)");

        //what do we do?
        MoveTo(target.transform.position, (speed * 2));

        //when do we stop?
        GameObject obsticle = CheckForward();

        if (obsticle == null){
            currentState = State.Stalk;
        }

    }

    void OnStalk()
    {
        print("imma find you");

        //Go to lastpos
        MoveTo(lastKnownPos, (speed * 2));

        //Reattack Player
        GameObject obsticle = CheckForward();

        if (obsticle != null){
            currentState = State.Chase;
            target = obsticle;
        }

        //on reached pos
        if(Vector3.Distance(transform.position, lastKnownPos) <= 0.1 && obsticle == null){
            currentState = State.Idle;
        }
        
    }

    void MoveTo(Vector3 moveTarget, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, (moveSpeed * Time.deltaTime));
        transform.LookAt(moveTarget, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10)){
            FP_Controller player = hit.transform.gameObject.GetComponent<FP_Controller>();

            if (player != null){
                print(hit.transform.gameObject.name);
                lastKnownPos = hit.transform.position;
                return hit.transform.gameObject;
            }
        }

        return null;
    }
}
