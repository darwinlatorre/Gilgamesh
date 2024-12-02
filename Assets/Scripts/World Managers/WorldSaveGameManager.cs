using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GILGAMESH
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager instance;

        [SerializeField] int worldSceneIndex = 1;

        private void Awake()
        {
            //SOLO PUEDE HABER UNA INSTANCIA DE ESTE OBJETO
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

        public IEnumerator LoadNewGame() {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
            yield return null;
        }

        public int getWorldSceneIndex()
        {
            return worldSceneIndex;
        }
    }
}
