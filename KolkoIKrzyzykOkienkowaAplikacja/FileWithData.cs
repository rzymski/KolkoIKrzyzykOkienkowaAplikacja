using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    static class FileWithData
    {
        public static void Save<T>(string path, T objectToSave) //Binarna serializacja obiektu
        {
            FileStream stream = null;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                stream = File.Create(path);
                formatter.Serialize(stream, objectToSave);
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        public static T Load<T>(string path)//Binarna deserializacja obiektu
        {
            FileStream stream = null;
            BinaryFormatter formatter = new BinaryFormatter();
            T obj;
            try
            {
                stream = new FileStream(path, FileMode.Open);
                obj = (T)formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return obj;
        }
    }
}
