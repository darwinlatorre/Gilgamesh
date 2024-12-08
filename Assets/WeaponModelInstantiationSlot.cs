using UnityEngine;

namespace GILGAMESH
{
    public class WeaponModelInstantiationSlot : MonoBehaviour
    {
        //WHAT SLOT IS THIS? (L HAND OR R?, OR HIPS OR BACK)
        public WeaponModelSlot weaponSlot;
        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if(currentWeaponModel != null) {                
                Destroy(currentWeaponModel);
             }
        }


        public void LoadWeapon(GameObject weaponModel)
        {
            currentWeaponModel = weaponModel;
            weaponModel.transform.parent = transform;

            weaponModel.transform.localPosition = Vector3.zero;
            weaponModel.transform.localRotation = Quaternion.identity;  
            weaponModel.transform.localScale = Vector3.one;
        }
    }
}
