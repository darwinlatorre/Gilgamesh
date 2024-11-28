using UnityEngine;

namespace GILGAMESH
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        PlayerManager player;
        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;

        private Vector3 moveDirection;
        private Vector3 targetRotationDirection;

        [SerializeField] private float waltingSpeed = 2;
        [SerializeField] private float runnigSpeed = 5;
        [SerializeField] private float rotationSpeed = 15;

        protected override void Awake()
        {
            base.Awake();
            player = GetComponent<PlayerManager>();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
        }

        public void GetVerticalAndHorizontalMovement()
        {
            verticalMovement = PlayerInputManager.intance.verticalInput;
            horizontalMovement = PlayerInputManager.intance.horizontalInput;
            
            // CLAMP MOVEMENTS

        }

        private void HandleGroundedMovement()
        {
            GetVerticalAndHorizontalMovement();
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
    }
}