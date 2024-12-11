using UnityEngine;

namespace GILGAMESH
{
    public class InstantCharacterEffect : ScriptableObject
    {
        [Header("Effect ID")]
        public int instatEffectID;

        public virtual void ProcessEffect(CharacterManager character)
        {
            // Process instant effect
        }
    }
}
