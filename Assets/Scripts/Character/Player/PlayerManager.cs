using UnityEngine;

namespace GILGAMESH
{
    public class PlayerManager : CharacterManager
    {
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;
        [HideInInspector] public PlayerNetworkManager playerNetworkManager;
        override protected void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
            playerNetworkManager = GetComponent<PlayerNetworkManager>();
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