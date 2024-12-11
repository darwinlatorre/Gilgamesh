using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName = "A.I/States/Combat Stance")]
    public class CombatStanceState : AIState
    {
        [Header("Attack")]
        public List<AICharacterAttackAction> aiCharacterAttacks;
        protected List<AICharacterAttackAction> potentialAttacks;
        private AICharacterAttackAction choosenAttack;
        private AICharacterAttackAction previousAttack;
        protected bool hasAttack = false;

        [Header("Combo")]
        [SerializeField] protected bool canPerformCombo = false;
        [SerializeField] protected int chanceToPerformCombo = 25;
        [SerializeField] bool hasRolledForComboChance = false;

        [Header("Engagement Distance")]
        [SerializeField] public float maximumEngagementDistance = 5;

        public override AIState Tick(AICharacterManager aiCharacter)
        {
            if (aiCharacter.isPerformingAction)
                return this;

            Debug.Log("1");

            if (aiCharacter.navMeshAgent.enabled)
                aiCharacter.navMeshAgent.enabled = true;

            Debug.Log("2");

            if (aiCharacter.aiCharacterNetworkManager.isMoving.Value)
            {
                if (aiCharacter.aiCharacterCombatManager.viewableAngle < -30
                    || aiCharacter.aiCharacterCombatManager.viewableAngle > 30)
                    aiCharacter.aiCharacterCombatManager.PivotTowardsTarget(aiCharacter);

            }

            aiCharacter.aiCharacterCombatManager.RotateTowardsAgent(aiCharacter); ;

            if (aiCharacter.aiCharacterCombatManager.currentTarget == null)
                    return SwitchState(aiCharacter, aiCharacter.idle);

            if (!hasAttack)
            {
                Debug.Log("3");
                GetNewAttack(aiCharacter);
            }
            else
            {
                Debug.Log("4");
                aiCharacter.attack.currentAttack = choosenAttack;
                //roll for combo chance
                return SwitchState(aiCharacter, aiCharacter.attack);
            }

            if (aiCharacter.aiCharacterCombatManager.distanceFromTarget > maximumEngagementDistance)              
                    return SwitchState(aiCharacter, aiCharacter.pursueTarget);

            NavMeshPath path = new NavMeshPath();
            aiCharacter.navMeshAgent.CalculatePath(aiCharacter.aiCharacterCombatManager.currentTarget.transform.position, path);
            aiCharacter.navMeshAgent.SetPath(path);
            return this;
            
        }

        protected virtual void GetNewAttack(AICharacterManager aiCharacter)
        { 
            potentialAttacks = new List<AICharacterAttackAction>();

          
            foreach (var potentialAttack in aiCharacterAttacks)
            {
                if (potentialAttack.minimumAttackDistance > aiCharacter.aiCharacterCombatManager.distanceFromTarget)
                    continue;

                if (potentialAttack.maximumAttackDistance < aiCharacter.aiCharacterCombatManager.distanceFromTarget)
                    continue;

                if(potentialAttack.minimumAttackAngle > aiCharacter.aiCharacterCombatManager.viewableAngle)
                    continue;

                if (potentialAttack.macimumAttackAngle < aiCharacter.aiCharacterCombatManager.viewableAngle)
                    continue;
            
                potentialAttacks.Add(potentialAttack);
            }

            if (potentialAttacks.Count <= 0)
                return;

            var totalWeight = 0;

            foreach (var attack in potentialAttacks)
            {
                totalWeight += attack.weight;
            }

            var randomWeightValue = Random.Range(1, totalWeight + 1);
            var processedWeight =0;

            foreach (var attack in potentialAttacks)
            {
                processedWeight += attack.attackWeight;

                if (randomWeightValue <= processedWeight)
                {
                    choosenAttack = attack;
                    previousAttack = choosenAttack;
                    hasAttack = true;
                    return;
                }
            }

        }

        protected virtual bool RollForOutcomeChance(int outcomeChance)
        {
            bool outcomeWillBePerformed = false;

            int randomPercentage = Random.Range(0, 100);

            if (randomPercentage < outcomeChance)
                outcomeWillBePerformed = true;

            return outcomeWillBePerformed;
        }

        protected override void ResetStateFlags(AICharacterManager aICharacter)
        {
            base.ResetStateFlags(aICharacter);

            hasAttack = false;
            hasRolledForComboChance = false;
            
        }
    }
}

