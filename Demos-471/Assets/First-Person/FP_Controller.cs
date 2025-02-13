using UnityEngine;
using UnityEngine.InputSystem;

public class FP_Controller : MonoBehaviour
{
    Vector2 movement;
    CharacterController controller;
    Vector2 mouseMove;

    [SerializeField]
    public float speed = 2.0f;

    [SerializeField]
    public GameObject cam;
    float camUpRotation = 0;

    [SerializeField]
    public float sensi = 100;

    [SerializeField]
    public GameObject booletSpawn;

    [SerializeField]
    public GameObject boolet;

    bool hasJumped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize controller
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //initialize cam movement
        float camLookX = mouseMove.x;
        float camLookY = mouseMove.y;

        // set the Up rotation
        camUpRotation -= camLookY;

        //Clamp the rotation
        camUpRotation = Mathf.Clamp(camUpRotation, -90, 90);

        //move the cam up and down
        cam.transform.localRotation = Quaternion.Euler(camUpRotation,0,0);

        transform.Rotate(Vector3.up * camLookX);

        //Initialize movement
        float moveX = movement.x * Time.deltaTime * sensi;
        float moveZ = movement.y * Time.deltaTime * sensi;

        //turn movement into a vec3
        Vector3 movementReal = (transform.forward * moveZ) + (transform.right * moveX);

        if (hasJumped){
            hasJumped = false;
            movementReal.y = 10;
        }

        movementReal.y -= 10 * Time.deltaTime;

        //use vec 3 to move
        controller.Move(movementReal * Time.deltaTime * speed);

    }
    void OnMove(InputValue moveVal)
    {

        movement = moveVal.Get<Vector2>();
        
    }

    void OnLook(InputValue lookVal)
    {
        mouseMove = lookVal.Get<Vector2>();
    }

    void OnAttack()
    {
        Instantiate(boolet, booletSpawn.transform.position, booletSpawn.transform.rotation);
    }

    void OnJump()
    {
        hasJumped = true;
    }
}
