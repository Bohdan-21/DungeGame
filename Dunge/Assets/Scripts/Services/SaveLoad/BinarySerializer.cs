using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Scripts.Services.SaveLoad
{
    public static class BinarySerializer
    {
        private static string PathForSaveFile = Application.persistentDataPath;

        public static void Serialize(object data, string fileName)
        {
            using (FileStream stream = new FileStream(PathForSaveFile + fileName, FileMode.OpenOrCreate))
            {
                Debug.Log(PathForSaveFile);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            using (FileStream stream = new FileStream(PathForSaveFile + fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                T data = (T) formatter.Deserialize(stream);

                return data;
            }
        }
    }
}
