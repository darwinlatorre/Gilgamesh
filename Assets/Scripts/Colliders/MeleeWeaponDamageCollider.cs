using GILGAMESH;
using UnityEngine;

namespace GILGAMESH
{
    public class MeleeWeaponDamageCollider : DamageCollider
    {
        [Header("Attacking Character")]
        public CharacterManager characterCausingDamage; 
    }
}