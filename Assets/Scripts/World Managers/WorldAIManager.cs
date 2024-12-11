using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace GILGAMESH
{
    public class WorldAIManager : MonoBehaviour
    {
        public static WorldAIManager instance;

        

        [Header("Characters")]
        [SerializeField] List<AICharacterSpawner> aiCharacterSpawners;
        
        [SerializeField] List<GameObject> spawnedinCharacters;

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

       /* private void Start()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                StartCoroutine(WaitForScheneToLoadThenSpawnCharacters());
            }
        }*/
       /*private IEnumerator WaitForScheneToLoadThenSpawnCharacters()
        {
            while(!SceneManager.GetActiveScene().isLoaded)
            {
                yield return null;
            }
        }*/

        public void SpawnCharacter(AICharacterSpawner aiCharacterSpawner)
        {
            if (NetworkManager.Singleton.IsServer)
            {
                aiCharacterSpawners.Add(aiCharacterSpawner);
                aiCharacterSpawner.AttemptToSpawnCharacter();
            }
        }

        private void DespawnAllCharacters()
        {
            foreach (var character in spawnedinCharacters)
            {
                character.GetComponent<NetworkObject> ().Despawn();
            }
        }

        private void DisableAllCharacters()
        {
            // TO DO DISABLE CHARACTER GAMEOBJECTS, SYNC DISABLES STATUS ON NETWORK
            // DISABLE GAMEOBJECTS FOR VLIENT UPON CONNECTING IF DISABLED STATUS IS TRUE
            // CAN BE USED TO DISABLE CHARACTERS THAT ARE FAR FROM PLAYERS TO SAVE MEMORY
            // CHARACTERS CAN BE SPLIT INTO AREAS 
        }
    }
}
