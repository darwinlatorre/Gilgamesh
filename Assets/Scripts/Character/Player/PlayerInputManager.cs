using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GILGAMESH 
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager intance;

        PlayerControls playerControls;

        [Header("PLAYER MOVEMENT INPUT")]
        [SerializeField] Vector2 movementInput;
        public float verticalInput;
        public float horizontalInput;
        public float moveAmount;

        [Header("CAMERA MOVEMENT INPUT")]
        [SerializeField] Vector2 cameraInput;
        public float cameraVerticalInput;
        public float cameraHorizontalInput;


        private void Awake()
        {
            if (intance == null)
            {
                intance = this;
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
            intance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, LoadSceneMode newScene)
        {
            // ESTAMOS ENTANDO A LA ESCENA DEL MUNDO, HABILITAMOS EL INPUT
            if (oldScene.buildIndex == WorldSaveGameManager.instance.getWorldSceneIndex())
            {
                intance.enabled = true;
            }
            // ESTAMOS SALIENDO DE LA ESCENA DEL MUNDO, DESHABILITAMOS EL INPUT
            // PARA QUE NO SE PUEDA MOVER EL PERSONAJE, EN UN MENU
            else
            {
                intance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovements.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                playerControls.PlayerCamera.Movement.performed += i => cameraInput = i.ReadValue<Vector2>();
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
            HandlePlayerMovementInput();
            HandleCameraMovementInput();
        }

        private void HandlePlayerMovementInput() {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            if(moveAmount < 0.5f && moveAmount > 0)
            {
                moveAmount = 0.5f;
            }
            else if (moveAmount > 0.5f && moveAmount <= 1)
            {
                moveAmount = 1;
            }
        }

        private void HandleCameraMovementInput() {
            cameraVerticalInput = cameraInput.y;
            cameraHorizontalInput = cameraInput.x;
        }
    }
}
