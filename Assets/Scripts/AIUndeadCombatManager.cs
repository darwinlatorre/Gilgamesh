using Unity.VisualScripting;
using UnityEngine;

namespace GILGAMESH
{
    public class AIUndeadCombatManager : AICharacterCombatManager
    {
        [Header("Damage colliders")]
        [SerializeField] UndeadHandDamageCollider rightHandDamageCollider;
        [SerializeField] UndeadHandDamageCollider leftHandDamageCollider;

        [Header("Damage")]
        [SerializeField] int baseDamage = 25;
        [SerializeField] float attack01DamageModifier = 0.1f;
        [SerializeField] float attack02DamageModifier = 1.4f;

        // poner en Events-Function de las animaciones de ataque para abrir y cerrar el collider de daño ver video pt7
        public void SetAttack01Damage()
        { 
            rightHandDamageCollider.physicalDamage = baseDamage * attack01DamageModifier;
            leftHandDamageCollider.physicalDamage = baseDamage * attack01DamageModifier;
        }

        public void SetAttack02Damage()
        {
            rightHandDamageCollider.physicalDamage = baseDamage * attack02DamageModifier;
            leftHandDamageCollider.physicalDamage = baseDamage * attack02DamageModifier;
        }

        public void  OpenRigtHandDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }

        public void CloseRightHandDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }

        public void  OpenLeftHandDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();
        }

        public void CloseLeftHandDamageCollider()
        {
           leftHandDamageCollider.DisableDamageCollider();
        }
    }
    
}

