using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName ="A.I/States/Idle")]
    public class IdleState : AIState
    {
        public override AIState Tick(AICharacterManager aiCharacter)
        {
            if (aiCharacter.charactercombatManager.currentTarget != null)
            {
       
                SwitchState(aiCharacter, aiCharacter.pursueTarget);
                return this;

            }
            else
            {
                // return this state, to continually search for a target(keep the state here, until a taerget is found)
                aiCharacter.aiCharacterCombatManager.FindATargetViaLineOfSight(aiCharacter);
                Debug.Log("Searching target");
                return this;
            }

            
        }

        
    }
}

