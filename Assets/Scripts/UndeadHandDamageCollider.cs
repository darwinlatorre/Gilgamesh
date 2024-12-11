using UnityEngine;

namespace GILGAMESH
{
    public class UndeadHandDamageCollider : DamageCollider
    {
        
        [SerializeField] AICharacterManager undeadCharacter;
        protected override void Awake()
        {
            base.Awake();

            damageCollider = GetComponent<Collider>();
            undeadCharacter = GetComponentInParent<AICharacterManager>();
            
        }
        protected override void DamageTarget(CharacterManager damageTarget)
        {
            if (charactersDamaged.contains(damageTarget))
                return;

            charactersDamaged.Add(damageTarget);

            TakeDamageEffect damageEffect = Instantiate(WorldCharacterEffectsManager.instance.takeDamageEffect);
            damageEffect.physicalDamage = physicalDamage;
            damageEffect.magicDamage = magicDamage;
            damageEffect.fireDamage = fireDamage;
            damageEffect.holyDamage = holyDamage;
            damageEffect.contactPoint = ContactPoint;
            damageEffect.angleHitFrom = Vector3.SingedAngle(undeadCharacter.transform.forward, damageTarget.transform.forward, Vector3.up);

            if (undeadCharacter.IsOwner)
            {
                damageTarget.characterNetworkManager.NotityTheServerOfActionAnimationServerRpc(
                    damageTarget.NetworkObjectId,
                     undeadCharacter.NetworkObjectId,
                    damageEffect.physicalDamage,
                    damageEffect.magicDamage,
                    damageEffect.fireDamage,
                    damageEffect.holyDamage,
                    damageEffect.poiseDamage,
                    damageEffect.angleHitFrom,
                    damageEffect.contactPoint.x,
                    damageEffect.contactPoint.y,
                    damageEffect.contactPoint.z);
            }
        }
    }
}

