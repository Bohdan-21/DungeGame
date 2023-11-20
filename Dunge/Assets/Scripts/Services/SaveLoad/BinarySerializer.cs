using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Scripts.Services.SaveLoad
{
    public static class BinarySerializer
    {
        private const string PathForSaveFile = "E:\\Unity proj\\Project 16 Dunge Game\\Saves\\";

        public static void Serialize(object data, string fileName)
        {
            using (FileStream stream = new FileStream(PathForSaveFile + fileName, FileMode.OpenOrCreate))
            {
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
