using UnityEngine;
using Unity.Netcode;

namespace GILGAMESH {
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;
        [Header("NETWORK JOIN")]
        [SerializeField] bool startGameAsClient;
        private void Awake()
        {
            if (instance == null) {
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

        private void Update()
        {
            if (startGameAsClient)
            {
                startGameAsClient = false;
                // WE MUST FIRST DOWN, BECAUSE WE HAVE STARTED AS HOST
                NetworkManager.Singleton.Shutdown();
                // WE THEN RESTART AS CLIENT
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}
