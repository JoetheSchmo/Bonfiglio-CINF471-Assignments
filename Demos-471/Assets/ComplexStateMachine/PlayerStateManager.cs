using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{

    public PlayerBaseState currentState;
    public PlayerIdleState idle = new PlayerIdleState();
    public PlayerWalkState walk = new PlayerWalkState();
    public PlayerSneakState sneak = new PlayerSneakState();

    [HideInInspector]
    public bool isSneaking = false;

    [HideInInspector]
    public Vector2 movement;
    CharacterController controller;
    public float defaultSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        controller = GetComponent<CharacterController>();

        SwitchState(idle);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }
    void OnSprint()
    {
        isSneaking = !isSneaking;

        Debug.Log("sneak toggled");
    }

    //move the player
    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float movez = movement.y;

        Vector3 realMove = new Vector3(moveX, 0, movez);

        controller.Move(realMove * speed * Time.deltaTime);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;

        currentState.EnterState(this);
    }
}
