using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace GILGAMESH
{
    public class WorldCharactersEffectsManager : MonoBehaviour
    {
        public static WorldCharactersEffectsManager instance;

        [Header("Damage")]
        public TakeDamageEffect takeDamageEffect;

        [SerializeField] List<InstantCharacterEffect> instantEffects;

        private void Awake()
        {
             if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
             GenerateEffectsIDs();
        }

        private void GenerateEffectsIDs() 
        {
            for (int i = 0; i < instantEffects.Count; i++)
            {
                instantEffects[i].instatEffectID = i;
            }
        }
    }
}