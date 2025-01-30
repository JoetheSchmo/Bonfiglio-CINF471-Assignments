using UnityEngine;
using UnityEngine.InputSystem;

public class RAB_Player : MonoBehaviour
{

    private Vector2 inputMvm;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputMvm = new Vector2(0,0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_dir = inputMvm.x;

        float z_dir = inputMvm.y;

        Vector3 mvm = new Vector3(x_dir, 0, z_dir);

        //print(mvm);

        rb.AddForce(mvm);
    }

    void OnMove(InputValue movement)
    {

        inputMvm = movement.Get<Vector2>();

    }
}
