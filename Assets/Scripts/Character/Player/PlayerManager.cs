using UnityEngine;

namespace GILGAMESH
{
    public class PlayerManager : CharacterManager
    {
<<<<<<< HEAD
        PlayerLocomotionManager playerLocomotionManager;



        [HideInInspector] public PlayerInventoryManager playerInventoryManager;
=======
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;
>>>>>>> e9aa1c18b8d2c12cea23d1d6456e6269c020e490
        override protected void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
<<<<<<< HEAD

            playerInventoryManager = GetComponent<PlayerInventoryManager>();
=======
            playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
>>>>>>> e9aa1c18b8d2c12cea23d1d6456e6269c020e490
        }

        override protected void Update()
        {
            base.Update();
            // SOLO EL DUEÑO DEL JUGADOR PUEDE MOVERLO
            if (!IsOwner)
                return;
            // MANEJA TODOS LOS MOVIMIENTOS DEL JUGADOR
            playerLocomotionManager.HandleAllMovement();
        }

        protected override void LateUpdate()
        {
            if (!IsOwner)
                return;
            base.LateUpdate();

            PlayerCamera.instance.HandleAllCameraActions();
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            if (IsOwner)
            {
                PlayerCamera.instance.player = this;
                PlayerInputManager.instance.player = this;
            }
        }

    }
}