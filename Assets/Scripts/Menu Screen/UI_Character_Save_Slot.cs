using TMPro;
using UnityEngine;

namespace GILGAMESH
{
    public class UI_Character_Save_Slot : MonoBehaviour
    {
        SaveFileDataWriter saveFileWriter;

        [Header("Game Slot")]
        public CharacterSlot characterSlot;

        [Header("Character Info")]
        public TextMeshProUGUI characterName;
        public TextMeshProUGUI timePlayer;

        private void OnEnable()
        {
            LoadSaveSlots();
        }

        private void LoadSaveSlots()
        {
            saveFileWriter = new SaveFileDataWriter();
            saveFileWriter.saveDataDirectoryPath = Application.persistentDataPath;

            if (characterSlot == CharacterSlot.CharacterSlot_01) 
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
               
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot01.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_02)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot02.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if(characterSlot == CharacterSlot.CharacterSlot_03)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot03.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_04)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot04.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_05)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot05.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_06)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot06.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_07)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot07.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_08)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot08.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_09)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot09.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_10)
            {
                saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                // IF THE FILE EXISTS, GET INFORMACION FROM IT
                if (saveFileWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot10.characterName;
                }
                // IF IT DOES NOT, DISABLE THE GAME OBJECT
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public void LoadGameFromCharacterSlot()
        {
            WorldSaveGameManager.instance.currentCharacterSlotBeingUsed = characterSlot;
            WorldSaveGameManager.instance.LoadGame();
        }

        public void SelectCurrentSlot() 
        {
            TitleScreenManager.Instance.SelectCharacterSlot(characterSlot);
        }
    }
}
