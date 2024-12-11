using UnityEngine;

namespace GILGAMESH
{
    public class AICharacterAnimatorManager : CharacterAnimationManager
    {
        AICharacterManager aiCharacter;

        protected override void Awake()
        {
            base.Awake(); 
            aiCharacter = GetComponent<AICharacterManager>();
        }

        private void OnAnimatorMove()
        {
            //host
            if (aiCharacter.IsOwner)
            {
                if (!aiCharacter.isGrounded)
                    return;

                Vector3 velocity = aiCharacter.animator.deltaPosition;

                aiCharacter.characterController.Move(velocity);
                aiCharacter.transform.rotation *= aiCharacter.animator.deltaRotation;
            }
            //client
            else
            {
                if (!aiCharacter.isGrounded)
                    return;

                Vector3 velocity = aiCharacter.animator.deltaPosition;

                aiCharacter.characterController.Move(velocity);
                aiCharacter.transform.position = Vector3.SmoothDamp(transform.position,
                    aiCharacter.aiCharacterNetworkManager.networkPosition.Value, ref aiCharacter.characterNetworkManager.networkPositionSmoothTime);
                aiCharacter.transform.rotation *= aiCharacter.animator.deltaRotation;
            }
        }
    }
}

