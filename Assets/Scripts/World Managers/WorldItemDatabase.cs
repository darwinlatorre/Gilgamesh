using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

namespace GILGAMESH
{
    public class WorldItemDatabase : MonoBehaviour
    {
        public static WorldItemDatabase Instance;

        public WeaponItem unarmedWeapon;

        [Header("Weapons")]
        [SerializeField] List<WeaponItem> weapons = new List<WeaponItem>();

        [Header("Items")]
        private List<Item> items = new List<Item>();


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            foreach (var weapon in weapons) {
                items.Add(weapon);
            }

            for (int i = 0; i < items.Count; i++) {
                items[i].itemID = i;
            }
        }

        public WeaponItem GetWeaponByID(int ID)
        {
            return weapons.FirstOrDefault(weapon => weapon.itemID == ID);
        }

    }
}