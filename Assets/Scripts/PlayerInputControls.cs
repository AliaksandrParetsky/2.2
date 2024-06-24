using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControls : MonoBehaviour
{
    private GameControls gameControl;
    private GameControls.CharacterActions characterActions;



    private void OnEnable()
    {
        gameControl = new GameControls();
        characterActions = gameControl.Character;

        gameControl.Enable();

        characterActions.MousePosition.started += MousePosition;
        characterActions.AddMate.started += AddMate;
    }

    private void AddMate(InputAction.CallbackContext obj)
    {
        MessageBroadcastSystem.Broadcast(InputEvent.ADD_MATE);
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        Vector3 pos = Mouse.current.position.ReadValue();
        MessageBroadcastSystem<Vector3>.Broadcast(InputEvent.MOVING_TO, pos);
    }

    private void OnDisable()
    {
        gameControl.Disable();

        characterActions.MousePosition.started -= MousePosition;
        characterActions.AddMate.started -= AddMate;
    }
}
