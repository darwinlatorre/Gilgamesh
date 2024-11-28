using UnityEngine;

namespace GILGAMESH
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;
        public Camera cameraObject;
        public PlayerManager player;

        [Header("Camera Settings")]
        private Vector3 cameraVelocity;
        private float cameraSmoothSpeed = 1; //Entre mas grande el valor, mas lento el movimiento de la camara para seguir al jugador


        public void Awake()
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
        }

        public void HandleAllCameraActions()
        {
            if (player != null)
            {
                FollowTarget();
            }
        }
        private void FollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }
    }
}