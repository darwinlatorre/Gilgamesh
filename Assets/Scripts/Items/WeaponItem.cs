using GILGAMESH;
using JetBrains.Annotations;
using UnityEngine;

namespace GILGAMESH
{
    public class WeaponItem : Item
    {
        // ANIMATOR CONTROLLER OVERRIDE (CHANGE ATTACK ANIMATIONS BASED ON WEAPON YOU ARE CURRENTLY USING)

        [Header("Weapon Model")]
        public GameObject weaponModel;

        [Header("Weapon Requirements")]
        public int strengthREQ = 0;
        public int dexREQ = 0;
        public int intReq = 0;
        public int faithREQ = 0;

        [Header("Weapon Base Damage")]
        public int physicalDamge = 0;
        public int magicDamge = 0;
        public int fireDamage = 0;
        public int holyDamge = 0;
        public int lightningDamge = 0;

        //WEAPON GUARD ABSORPTIONS (BLOKING POWER)

        [Header("Weapon Base Poise Damge")]
          public float poiseDamage = 10;
        //OFFENSIVE POISE BONUS WHEN ATTACKING

        //WEAPON MODIFIER
        // LIGHT ATTACK MODIFIER
        //HEAVY ATTACK MODIFIER
        // CRITICAL DAMAGE MODIFIER

        [Header("Stamina Costs")]
        public int baseStaminaCost = 20;


        //ITEM BASED ACTIONS (RB, RT, LB, LT)


        //ASH OF WAR

        //BLOCKING SOUNDS

    }
}