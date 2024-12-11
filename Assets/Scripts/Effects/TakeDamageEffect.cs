using UnityEngine;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName = "Character Effects / Instant Effects / Take Damage")]
    public class TakeDamageEffect : InstantCharacterEffect
    {
        [Header("Character Causing Damage")]
        public CharacterManager characterCausingDamage; // If the damage is cause by another characterers attack it will be stored here

        [Header("Damage")]
        public float physicalDamage = 0; // (In the furure will be split into "Standard", "Strike")
        public float magicDamage = 0;
        public float fireDamage = 0;
        public float lightningDamage = 0;
        public float holyDamage = 0;

        [Header("Final Damage")]
        private int finalDamageDealt = 0; // The damage the character will take after all calculations has beem made

        [Header("Poise")]
        public float poiseDamage = 0;
        public bool poiseIsBroken = false;

        // (TODO) BUILD UPS

        [Header("Animation")]
        public bool playDamageAnimation = true;
        public bool manuallySelectDamageAnimation = false;
        public string damageAnimation;

        [Header("Direction Damage Taken From")]
        public float angleHitFrom;  // USED TO DETERMINE WHAT DAMAGE ANIMATION TO PLAY 
        public Vector3 contactPoint;    // USED TO DETERMINE WHERE THE BLOOD FX INSTANTIATES

        public override void ProcessEffect(CharacterManager character)
        {
            base.ProcessEffect(character);
            // IF THE CHARACTER IS DEAD, NO ADDITIONAL DAMAGE EFFECTS SHOULD BE PROCESSED
            if (character.isDead.Value)
                return;

            // CHECK FOR "INVULNERABILITY"

            CalculateDamage(character);
            // CHECK WHICH DIRECTION DAMAGE CAME FROM
            // PLAY A DAMAGE ANIMATION
            // CHECK FOR BUILD UPS (POISON, BLEED, ETC)
            // PLAY DAMAGE VFX (BLOOD)

            // IF CHARACTER IS AI, CHECK FOR NEW TARGET IF CHARACTER IS CAUSING DAMAGE IS PRESENT
        }

        private void CalculateDamage(CharacterManager character)
        {
            if (!character.IsOwner)
                return;

            if (characterCausingDamage != null) 
            {
                // CHECK FOR DAMAGE MODIFIERS AND MODIFY BASE DAMAGE (PHYSICAL, MAGIC, FIRE,...)
            }

            // CHECK CHARACTER FOR FLAT DEFENSES AND SUBTRACT THEM FORM THE DAMAGE

            // CHECK CHARACTER FOR ARMOR ABSORPTIONS, AND SUBTRACT THE PERCENTAGE OF DAMAGE

            // ADD ALL DAMAGE TYPES TOGETHER, AND APPLY FINAL DAMAGE
            finalDamageDealt = Mathf.RoundToInt(physicalDamage + magicDamage + fireDamage + lightningDamage + holyDamage);

            if(finalDamageDealt <= 0)
            {
                finalDamageDealt = 1;
            }

            character.characterNetworkManager.currentHealth.Value -= finalDamageDealt;

            // CALCULATE POISE DAMAGE TO DETERMINE IF THE CHARACTER WILL BE STUNNED
        }
    }

}
