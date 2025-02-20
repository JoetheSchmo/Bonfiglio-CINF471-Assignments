using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSneakState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("about to sneak and freak!");

    }

    // Update is called once per frame
    public override void UpdateState(PlayerStateManager player)
    {
        //Water we doing?
        Debug.Log("sneaking and freaking!");

         player.MovePlayer(player.defaultSpeed/2);

        //When do we gtfo?
        if (player.movement.magnitude < 0.1){
            player.SwitchState(player.idle);
        }else if (!player.isSneaking){
            player.SwitchState(player.walk);
        }

    }
}
