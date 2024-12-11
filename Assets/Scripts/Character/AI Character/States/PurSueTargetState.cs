using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName = "A.I/States/Pursue Target")]
    public class PurSueTargetState : AIState
    {

        public override AIState Tick(AICharacterManager aiCharacter)
        {

            //check if we are performing an action(do nothinf until action is complete)
            if (aiCharacter.isPerformingAction)
                return this;

            //check if target null, if so, return to idle state
            if (aiCharacter.aiCharacterCombatManager.currentTarget == null)
                return SwitchState(aiCharacter, aiCharacter.idle);

            //make sure our navmesh agent is active, if its not enable it
            if (!aiCharacter.navMeshAgent.enabled)
                aiCharacter.navMeshAgent.enabled = true;

            if (aiCharacter.aiCharacterCombatManager.viewableAngle < aiCharacter.aiCharacterCombatManager.minimumFOV
                || aiCharacter.aiCharacterCombatManager.viewableAngle > aiCharacter.aiCharacterCombatManager.maximumFOV)
                aiCharacter.aiCharacterCombatManager.PivotTowardsTarget(aiCharacter);

            aiCharacter.aiCharacterLocomotionManager.RotateTowardsAgent(aiCharacter);

            if (aiCharacter.aiCharacterCombatManager.distanceFromTarget <= aiCharacter.navMeshAgent.stoppingDistance)
                return SwitchState(aiCharacter, aiCharacter.combatStance);

            //if the target is not reacheable, and they are far away, return home

            //pursue the target
            NavMeshPath path = new NavMeshPath();
            aiCharacter.navMeshAgent.CalculatePath(aiCharacter.aiCharacterCombatManager.currentTarget.transform.position, path);
            aiCharacter.navMeshAgent.SetPath(path);
            return this;
        }
    }

}
