using ScringloGames.ColorClash.Runtime.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    /// <summary>
    /// Responsible for binding the player's inputs to their respective actions in-game.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField]
        private DirectionalMover mover;
        private GameInput gameInput;

        private void Awake()
        {
            this.gameInput = new GameInput();
        }

        private void OnEnable()
        {
            this.gameInput.Gameplay.Enable();
            
            this.gameInput.Gameplay.Move.performed += this.OnMovePerformed;
            this.gameInput.Gameplay.Move.canceled += this.OnMoveCancelled;
        }

        private void OnDisable()
        {
            this.gameInput.Gameplay.Disable();
            
            this.gameInput.Gameplay.Move.performed -= this.OnMovePerformed;
            this.gameInput.Gameplay.Move.canceled -= this.OnMoveCancelled;
        }
        
        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            // Do this when the move input is pressed

            var direction = context.ReadValue<Vector2>();
            
            this.mover.Direction = direction;
            this.mover.StartAccelerating();
        }
        
        private void OnMoveCancelled(InputAction.CallbackContext context)
        {
            // Do this when the move input is released
            
            this.mover.IsAccelerating = false;
            this.mover.StopAccelerating();
        }
    }
}
