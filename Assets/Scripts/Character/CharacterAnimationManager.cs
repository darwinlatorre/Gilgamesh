using UnityEngine;
using Unity.Netcode;

namespace GILGAMESH {
    public class CharacterAnimationManager : MonoBehaviour
    {
        CharacterManager character;

        int vertical;
        int horizontal;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();

            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }
        public void UpdateAnimatorMovementParameters(float horizontalMovement, float verticalMovement, bool isSprinting)
        {
            float horizontalAmount = horizontalMovement;
            float verticalAmount = verticalMovement;

            if (isSprinting)
            {
                verticalAmount = 2;
            }

            character.animator.SetFloat(horizontal, horizontalAmount, 0.1f, Time.deltaTime);
            character.animator.SetFloat(vertical, verticalAmount, 0.1f, Time.deltaTime);
        }

        public virtual void PlayTargetActionAnimation(
            string targetAnimation, 
            bool isPerformingAction, 
            bool applyRootMotion = true, 
            bool canRotate = false, 
            bool canMove = false) {

            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);

            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;

            character.characterNetworkManager.NotityTheServerOfActionAnimationServerRpc(
                NetworkManager.Singleton.LocalClientId,
                targetAnimation,
                applyRootMotion);
        }

        public virtual void PlayTargetAttackActionAnimation(
           string targetAnimation,
           bool isPerformingAction,
           bool applyRootMotion = true,
           bool canRotate = false,
           bool canMove = false)
        {

            character.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);

            character.isPerformingAction = isPerformingAction;
            character.canRotate = canRotate;
            character.canMove = canMove;

            character.characterNetworkManager.NotityTheServerOfAttackActionAnimationServerRpc(
                NetworkManager.Singleton.LocalClientId,
                targetAnimation,
                applyRootMotion);
        }
    }
}
