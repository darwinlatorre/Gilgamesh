using UnityEngine;

namespace GILGAMESH
{
    [CreateAssetMenu(menuName = "Character Effects / Instant Effects / Take Stamina Damage")]
    public class TakeStaminaDamageEffect : InstantCharacterEffect
    {
        public float staminaDamage;
        override public void ProcessEffect(CharacterManager character)
        {
            CalculateStaminaDamage(character);
        }

        private void CalculateStaminaDamage(CharacterManager character)
        {
            if (character.IsOwner)
            {
                Debug.Log("CHARACTER IS TAKING: " + staminaDamage + " STAMINA DAMAGE");
                character.characterNetworkManager.currentStamina.Value -= staminaDamage;
            }
        }
    }
}