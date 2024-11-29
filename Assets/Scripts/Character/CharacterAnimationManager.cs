using UnityEngine;

namespace GILGAMESH {
    public class CharacterAnimationManager : MonoBehaviour
    {
        CharacterManager character;

        float vertical;
        float horizontal;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }
        public void UpdateAnimatorMovementParameters(float horizontalValues, float verticalValues)
        {
            character.animator.SetFloat("Horizontal", horizontalValues, 0.1f, Time.deltaTime);
            character.animator.SetFloat("Vertical", verticalValues, 0.1f, Time.deltaTime);
        }

        public virtual void PlayTargetActionAnimation(string targetAnimation, bool isPerformingAction, bool applyRootMotion = true) {
            character.animator.applyRootMotion = applyRootMotion;
            character.animator.CrossFade(targetAnimation, 0.2f);
            character.isPerformingAction = isPerformingAction;
        }
    }
}
