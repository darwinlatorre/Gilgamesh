using UnityEngine;

namespace GILGAMESH
{
    public class CharacterEffectsManager : MonoBehaviour
    {
        CharacterManager character;
        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }
        public virtual void ProcessInstantEffect(InstantCharacterEffect effect)
        {
            effect.ProcessEffect(character);
        }
    }
}