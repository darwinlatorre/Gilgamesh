using UnityEngine;
using System.IO;
using System;
namespace GILGAMESH
{
    public class SaveFileDataWriter
    {
        public string saveDataDirectoryPath = "";
        public string saveFileName = "";

        // BEFORE WE CREATE A NEW SAVE FILE, WE MUST CHECK TO SEE IF ONE OF THIS CHARACTER SLOT ALREDY EXISTS (MAX 10 CHARACTERS)
        public bool CheckToSeeIfSaveFileExists()
        {
            if (File.Exists(Path.Combine(saveDataDirectoryPath, saveFileName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // USED TO DELETE CHARACTER SAVE FILES
        public void DeleteSaveFile()
        {
            File.Delete(Path.Combine(saveDataDirectoryPath, saveFileName));
        }

        // USED TO CREATE A NEW CHARACTER SAVE FILE
        public void CreateNewCharacterSaveFile(CharacterSaveData characterData)
        {
            // MAKE A PATH TO SAVE THE FILE (A LOCATION ON THE COMPUTER)
            string savePath = Path.Combine(saveDataDirectoryPath, saveFileName);
            try
            {
                // CREATE THE DIRECTORY THE FILE WILL BE WRITTEN TO, IF IT DOESN'T ALREADY EXIST
                Directory.CreateDirectory(Path.GetDirectoryName(saveDataDirectoryPath));
                Debug.Log("CREATING SAVE FILE, AT SAVE PATH: " + savePath);

                // SERIALIZE THE C# GAME DATA OBJECT INTO A JSON STRING
                string dataToStore = JsonUtility.ToJson(characterData, true);

                // WRITE THE JSON STRING TO A FILE
                using (FileStream stream = new FileStream(savePath, FileMode.Create))
                {
                    using (StreamWriter fileWriter = new StreamWriter(stream))
                    {
                        fileWriter.Write(dataToStore);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("ERROR WHILST TRYING TO SAVE CHARACTER DATA, GAME NOT SAVED" + savePath + "\n" + ex);
            }
        }

        // USED TO LOAD A SAVE FILE UPON LOADING A PREVIOUS GAME
        public CharacterSaveData LoadSaveFile()
        {
            CharacterSaveData characterData = null;

            // MAKE A PATH TO LOAD THE FILE (A LOCATION ON THE COMPUTER)
            string loadPath = Path.Combine(saveDataDirectoryPath, saveFileName);

            if (File.Exists(loadPath))
            {
                try 
                {
                    string dataToLoad = "";

                    using (FileStream stream = new FileStream(loadPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    // DESERIALIZE THE DATA FORM JSON BACK TO UNITY C# OBJECTS
                    characterData = JsonUtility.FromJson<CharacterSaveData>(dataToLoad);
                }
                catch (Exception ex)
                {
                    Debug.LogError("ERROR WHILST TRYING TO LOAD CHARACTER DATA, GAME NOT LOADED" + loadPath + "\n" + ex);
                }
            }

            return characterData;
        }

    }
}
