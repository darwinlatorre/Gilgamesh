using UnityEngine;

namespace GILGAMESH
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;



        [HideInInspector] public PlayerInventoryManager playerInventoryManager;
        override protected void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();

            playerInventoryManager = GetComponent<PlayerInventoryManager>();
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
            }
        }

    }
}