using UnityEngine;
namespace GILGAMESH
{
    public class WeaponItem: Item
    {
        [Header("Weapon Model")]
        public GameObject weaponModel;

        [Header("Weapon Requirementes")]
        public int strengthREQ = 0;
        public int dexREQ = 0;
        public int intREQ = 0;
        public int faithREQ = 0;

        [Header("Weapon Bade Damage")]
        public int physicalDamge = 0;
        public int magicDamage = 0;
        public int fireDamage = 0;
        public int holyDamage = 0;
        public int lightningDamage = 0;

        [Header("Weapon Base Poise Damage")]
        public float poiseDamage = 10;

        [Header("Stamina Costs")]
        public int baseStaminaCost = 20;
    }
}