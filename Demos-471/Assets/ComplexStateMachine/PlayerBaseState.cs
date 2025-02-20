using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void EnterState(PlayerStateManager player);

    // Update is called once per frame
    public abstract void UpdateState(PlayerStateManager player);
}
