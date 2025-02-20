using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("about to move and/or groove!");

    }

    // Update is called once per frame
    public override void UpdateState(PlayerStateManager player)
    {
        //Water we doing?
        player.MovePlayer(player.defaultSpeed);

        Debug.Log("we movin' and/or groovin'");

        //When do we gtfo?
        if (player.movement.magnitude < 0.1){
            player.SwitchState(player.idle);
        }else if (player.isSneaking){
            player.SwitchState(player.sneak);
        }
        
    }
}
