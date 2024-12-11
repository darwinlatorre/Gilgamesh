using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GILGAMESH
{
    public class AICharacterCombatManager : CharacterCombatManager
    {
        [Header("Action Recovery")]
        public float actionRecoveryTimer = 0;

        [Header("Target Information")]
        public float distanceFromTarget;
        public float viewableAngle;
        public Vector3 targetsDirection;

        [Header("Detection")]
        [SerializeField] float detectionRadius = 15;
        public float minimumFOV = -35;
        public float maximumFOV = 35;

        [Header("Atta Rotation Speed")]
        public float attackRotationSpeed = 25;

        protected override void Awake()
        {
            base.Awake();
            lockOnTransform = GetComponentInChildren<LockOnTransform>().transform;
            
        }

        public void FindATargetViaLineOfSight(AICharacterManager aiCharacter)
        {
            
            if (currentTarget != null)   
                return;

            Collider[] colliders = Physics.OverlapSphere(aiCharacter.transform.position, detectionRadius, WorldUtilityManager.Instance.GetCharacterLayers());
            
            for (int i=0; i<colliders.Length; i++)
            {
                CharacterManager targetCharacter = colliders[i].transform.GetComponent<CharacterManager>();

                if (targetCharacter == null)
                    continue;
                if (targetCharacter == aiCharacter)
                    continue;
                if (targetCharacter.isDead.Value)
                    continue;
                
                if (WorldUtilityManager.Instance.CanIDamageThisTarget(aiCharacter.characterGroup, targetCharacter.characterGroup))
                {
                    //if a potential target is found, it has to be infront of us
                    Vector3 targetsDirecction = targetCharacter.transform.position  - aiCharacter.transform.position;
                    float AngleOfPotentialTarget = Vector3.Angle(targetsDirecction, aiCharacter.transform.forward);

                    if (AngleOfPotentialTarget> minimumFOV && AngleOfPotentialTarget < maximumFOV)
                    {
                        //Check for enviro blocks
                        if (Physics.Linecast(aiCharacter.characterCombatManager.lockOnTransform.position,
                            targetCharacter.characterCombatManager.lockOnTransform.position.WorldUtiliManager.Instance.GetEnviroLayers()))
                        {
                            Debug.DrawLine(aiCharacter.characterCombatManager.lockOnTransform.position, targetCharacter.characterCombatManager.lockOnTransform.position);
                            Debug.Log("BLOCKED");
                        }
                        else
                        {
                            
                            targetsDirection = aiCharacterCombatManager.currentTarget.transform.position = transform.position;
                            viewableAngle = WorldUtilityManager.Instance.GetAngleOfTarget(transform, aiCharacterCombatManager.targetsDirection);
                            aiCharacter.characterCombatManager.SetTarget(targetCharacter);
                            PivotTowardsTarget(aiCharacter);
                        }
                    }
                }
        }
    }

        public void PivotTowardsTarget(AICharacterManager aiCharacter)
        {
            if (aiCharacter.isPerformingAction)
                return;
            if (viewableAngle >= 20 && viewableAngle <= 60)
            {
                aiCharacter.characterAnimationManager.PlayTargetActionAnimation("Turn_Right_45", true);
            }
            else if (viewableAngle <= -20 && viewableAngle >= -60)
            {
                aiCharacter.characterAnimationManager.PlayTargetActionAnimation("Turn_Left_45", true);

            }
            else if (viewableAngle >= 61 && viewableAngle <= 110)
            {
                aiCharacter.characterAnimationManager.PlayTargetActionAnimation("Turn_Right_90", true);

            }
            else if (viewableAngle <= -61 && viewableAngle >= -110)
            {
                aiCharacter.characterAnimationManager.PlayTargetActionAnimation("Turn_Left_90", true);

            }
        }

        public void RotateTowardsAgent(AICharacterManager aiCharacter)
        {
            if (aiCharacter.aiCharacterNetworkManager.isMoving.Value)
            {
                aiCharacter.transform.rotation = aiCharacter.navMeshAgent.transform.rotation;
            }
        }

        public void RotateTowardsTargetWhilstAttacking(AICharacterManager aiCharacter)
        {
            if (currentTarget == null)
                return;
            if (!aiCharacter.canRotate)
                return;

            if (!aiCharacter.isPerformingAction)
                return;

            Vector3 targetDirection = currentTarget.transform.position = aiCharacter.transform.position;
            targetDirection.y = 0;
            targetDirection.Normalize();

            if (targetDirection == Vector3.zero)
                targetDirection = aiCharacter.transform.forward;    

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection); 
            
            aiCharacter.transform.rotation = Quaternion.Slerp(aiCharacter.transform.rotation, targetRotation, attackRotationSpeed * Time.deltaTime);    

        }

        public void HandleActionRecovery(AICharacterManager aiCharacter)
        {
            if (actionRecoveryTimer > 0)
            {
                if (!aiCharacter.isPerformingAction)
                {
                    actionRecoveryTimer-= Time.deltaTime;
                }
            }
        }
    }
}

