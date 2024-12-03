using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GILGAMESH 
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance;
        public PlayerManager player;

        PlayerControls playerControls;

        [Header("CAMERA MOVEMENT INPUT")]
        [SerializeField] Vector2 cameraInput;
        public float cameraVerticalInput;
        public float cameraHorizontalInput;

        [Header("PLAYER MOVEMENT INPUT")]
        [SerializeField] Vector2 movementInput;
        public float verticalInput;
        public float horizontalInput;
        public float moveAmount;

        [Header("PLAYER ACTIONS INPUT")]
        [SerializeField] bool dodgeInput = false;
        [SerializeField] bool sprintInput = false;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneChange;
            instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, LoadSceneMode newScene)
        {
            // ESTAMOS ENTANDO A LA ESCENA DEL MUNDO, HABILITAMOS EL INPUT
            if (oldScene.buildIndex == WorldSaveGameManager.instance.getWorldSceneIndex())
            {
                instance.enabled = true;
            }
            // ESTAMOS SALIENDO DE LA ESCENA DEL MUNDO, DESHABILITAMOS EL INPUT
            // PARA QUE NO SE PUEDA MOVER EL PERSONAJE, EN UN MENU
            else
            {
                instance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovements.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                playerControls.PlayerCamera.Movement.performed += i => cameraInput = i.ReadValue<Vector2>();
                playerControls.PlayerActions.Dodge.performed += i => dodgeInput = true;

                //Maneniendo el boton de sprint, activa el sprint
                playerControls.PlayerActions.Sprint.performed += i => sprintInput = true;
                //Soltando el boton de sprint, desactiva el sprint
                playerControls.PlayerActions.Sprint.canceled += i => sprintInput = false;
            }
            playerControls.Enable();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneChange;
        }

        private void OnApplicationFocus(bool focus)
        {
            if (enabled)
            {
                if (focus)
                {
                    playerControls.Enable();
                }
                else
                {
                    playerControls.Disable();
                }
            }
        }

        private void Update()
        {
            HandleAllInputs();
        }

        private void HandleAllInputs() {
            HandlePlayerMovementInput();
            HandleCameraMovementInput();
            HandleDodgeInput();
            HandleSprinting();
        }

        // MOVIMIENTO DEL JUGADOR

        private void HandlePlayerMovementInput() {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;

            moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

            if(moveAmount <= 0.5f && moveAmount > 0)
            {
                moveAmount = 0.5f;
            }
            else if (moveAmount > 0.5 && moveAmount <= 1)
            {
                moveAmount = 1;
            }

            if (player == null)
                return;

            player.playerAnimatorManager.UpdateAnimatorMovementParameters(0, moveAmount, player.playerNetworkManager.isSprinting.Value);
        }

        private void HandleCameraMovementInput() {
            cameraVerticalInput = cameraInput.y;
            cameraHorizontalInput = cameraInput.x;
        }

        // ACCIONES DEL JUGADOR

        private void HandleDodgeInput() {
            if (dodgeInput)
            {
                dodgeInput = false;
                player.playerLocomotionManager.AttemptToPerformDodge();
            }
        }

        private void HandleSprinting() {
            if (sprintInput)
            {
                player.playerLocomotionManager.HandleSprinting();
            }
            else
            {
                player.playerNetworkManager.isSprinting.Value = false;
            }
        }
    }
}
