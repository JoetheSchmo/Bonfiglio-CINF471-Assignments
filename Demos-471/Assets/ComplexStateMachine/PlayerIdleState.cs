using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("about to vibe and thrive!");

    }

    // Update is called once per frame
    public override void UpdateState(PlayerStateManager player)
    {
        //Water we doing?
        Debug.Log("vibing and thriving!");

        //When do we gtfo?
        if (player.movement.magnitude > 0.1){
            if (!player.isSneaking){
                player.SwitchState(player.walk);
            }else{
                player.SwitchState(player.sneak);
            }
           
        }

    }
}
