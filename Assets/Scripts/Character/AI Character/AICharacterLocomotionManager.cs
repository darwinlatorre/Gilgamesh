using UnityEngine;

namespace GILGAMESH
{
    public class AICharacterLocomotionManager : CharacterLocomotionManager
    {
        public void RotateTowardsAgent(AICharacterManager aiCharacter)
        {
            aiCharacter.transform.rotation = aiCharacter.navMeshAgent.transform.rotation;
        }
    }
}

