using UnityEngine;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName = "A.I/Actions/Attack")]
    public class AICharacterAttackAction : ScriptableObject
    {
        [Header("Attack")]
        [SerializeField] private string attackAnimation;
        [Header("Combo Action")]
        public AICharacterAttackAction comboAction;

        [Header("Action Values")]
        [SerializeField] AttackType attackTYpe;
        public int attackWeight = 50;

        public float actionRecoveryTime = 1.5f;
        public float minimumAttackAngle = -35;
        public float maximumAttackAngle = 35;
        public float minimumAttackDistance = 0;
        public float maximumAttackDistance = 2;

        public void AttempToPerformAction(AICharacterManager aiCharacter)
        {
            aiCharacter.characterAnimatorManager.PlayTargetAttackAtionAnimation(attacktyoe, attackAnimation, true);
        }
    }
}

