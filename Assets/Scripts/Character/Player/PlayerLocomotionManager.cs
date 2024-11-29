using UnityEngine;

namespace GILGAMESH
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        PlayerManager player;

        [HideInInspector] public float verticalMovement;
        [HideInInspector] public float horizontalMovement;
        [HideInInspector] public float moveAmount;

        [Header("Movements Settings")]
        private Vector3 moveDirection;
        private Vector3 targetRotationDirection;
        [SerializeField] private float waltingSpeed = 2;
        [SerializeField] private float runnigSpeed = 5;
        [SerializeField] private float rotationSpeed = 15;

        [Header("Dodge")]
        private Vector3 rollDirection;

        protected override void Awake()
        {
            base.Awake();
            player = GetComponent<PlayerManager>();
        }

        protected override void Update()
        {
            base.Update();
            if (player.IsOwner) {
                player.characterNetworkManager.verticalMovement.Value = verticalMovement;
                player.characterNetworkManager.horizontalMovement.Value = horizontalMovement;
                player.characterNetworkManager.moveAmount.Value = moveAmount;
            }
            else
            {
                verticalMovement = player.characterNetworkManager.verticalMovement.Value;
                horizontalMovement = player.characterNetworkManager.horizontalMovement.Value;
                moveAmount = player.characterNetworkManager.moveAmount.Value;

                // Si no es el dueño del jugador, actualiza el animator del jugador
                player.playerAnimatorManager.UpdateAnimatorMovementParameters(0, moveAmount);
            }
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
        }

        public void GetMovementValues()
        {
            verticalMovement = PlayerInputManager.intance.verticalInput;
            horizontalMovement = PlayerInputManager.intance.horizontalInput;
            moveAmount = PlayerInputManager.intance.moveAmount;
            // CLAMP MOVEMENTS

        }

        private void HandleGroundedMovement()
        {
            GetMovementValues();
            //EL MOVIMIENTO ESTA BASADO EN LA DIRECCION DE LA CAMARA
            moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
            moveDirection = moveDirection + PlayerCamera.instance.transform.right * horizontalMovement;
            moveDirection.Normalize();
            moveDirection.y = 0;

            if (PlayerInputManager.intance.moveAmount > 0.5f) {
                player.characterController.Move(moveDirection * runnigSpeed * Time.deltaTime);
            }
            else if (PlayerInputManager.intance.moveAmount <= 0.5f)
            {
                player.characterController.Move(moveDirection * waltingSpeed * Time.deltaTime);
            }
        }

        private void HandleRotation()
        {
            targetRotationDirection = Vector3.zero;
            targetRotationDirection = PlayerCamera.instance.cameraObject.transform.forward * verticalMovement;
            targetRotationDirection = targetRotationDirection + PlayerCamera.instance.cameraObject.transform.right * horizontalMovement;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            if (targetRotationDirection == Vector3.zero)
            {
                targetRotationDirection = transform.forward;
            }

            Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }

        public void AttemptToPerformDodge() {
            //Si no estamos moviento hacemos un roll en la direccion de la camara
            if (player.isPerformingAction)
                return;

            if (PlayerInputManager.intance.moveAmount > 0)
            {
                rollDirection = PlayerCamera.instance.cameraObject.transform.forward * PlayerInputManager.intance.verticalInput;
                rollDirection += PlayerCamera.instance.cameraObject.transform.right * PlayerInputManager.intance.horizontalInput;
                rollDirection.y = 0;
                rollDirection.Normalize();

                Quaternion playerRotation = Quaternion.LookRotation(rollDirection);
                player.transform.rotation = playerRotation;

                player.playerAnimatorManager.PlayTargetActionAnimation("Roll_Forward_01", true, true);
            }
            //Si estamos quietos hacemos un backstep
            else {
            }
            
        }
    }
}