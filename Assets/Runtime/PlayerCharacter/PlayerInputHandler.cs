using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Input;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.PlayerCharacter
{
    /// <summary>
    /// Responsible for binding the player's inputs to their respective actions in-game.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private PlayerInput playerInput;
        [SerializeField]
        private DirectionalMover mover;
        [SerializeField]
        private DirectionalLooker looker;
        [SerializeField]
        private AttackBehavior attackBehavior;
        
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
            this.gameInput.Gameplay.Look.performed += this.OnLookPerformed;
            this.gameInput.Gameplay.Fire.performed += this.OnFirePerformed;
            this.gameInput.Gameplay.Fire.canceled += this.OnFireCanceled;
        }
        
        private void OnDisable()
        {
            this.gameInput.Gameplay.Disable();
            
            this.gameInput.Gameplay.Move.performed -= this.OnMovePerformed;
            this.gameInput.Gameplay.Move.canceled -= this.OnMoveCancelled;
            this.gameInput.Gameplay.Look.performed -= this.OnLookPerformed;
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

        private void OnFirePerformed(InputAction.CallbackContext context)
        {
            this.attackBehavior.Attack(true);
        }
        
        private void OnFireCanceled(InputAction.CallbackContext obj)
        {
            this.attackBehavior.Attack(false);
        }
        
        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            // Do this when a "look" input is detected

            var input = context.ReadValue<Vector2>();
            
            switch (this.playerInput.currentControlScheme)
            {
                case "KeyboardAndMouse":
                    var cam = this.playerInput.camera;
                    var from = (Vector2) cam.WorldToScreenPoint(this.looker.transform.position);
                    this.looker.Direction = (input - from).normalized;
                    break;
                case "Gamepad":
                    this.looker.Direction = input.normalized;
                    break;
                default:
                    break;
            }
        }
    }
}
