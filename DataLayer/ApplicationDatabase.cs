using KillerApp.DataLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;


namespace DataLayer
{
    /// <summary>
    /// Horen eigenlijk queries te zijn naar een database. (dit is als voorbeeld even)
    /// </summary>
    internal class ApplicationDatabase
    {
        private const string connectionString = "Server=localhost;Port=3306;Database=killerapp;Uid=root;Pwd=;";
        private List<Image> Images { get; set; }

        //internal ApplicationDatabase()
        //{
        //    Images = new List<Image>
        //    {
        //        new Image { Id = 1, Name = "Tandenborstel", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow},
        //        new Image { Id = 2, Name = "Tandpasta", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow},
        //        new Image { Id = 3, Name = "Tandenborstelhouder", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow}
        //    };
        //}
        internal int ExecuteFunctionWithValues(string procedure, Dictionary<string, object> parameters)
        {
            int test = 0;
            //MySqlDataReader mySqlDataReader;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(procedure))
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = procedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ireturnvalue", MySqlDbType.Int32);
                cmd.Parameters["@ireturnvalue"].Direction = ParameterDirection.ReturnValue;
                foreach (KeyValuePair<string, object> item in parameters)
                {
                    MySqlParameter x = new MySqlParameter(item.Key, item.Value);
                    x.MySqlDbType = MySqlDbType.VarChar;

                    cmd.Parameters.Add(x);
                }
                //mySqlDataReader = 
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                test = Convert.ToInt32(cmd.Parameters["@ireturnvalue"].Value);
                connection.Close();
            }
            return test;
        }

        internal T ExecuteProcedureWithValues<T>(string procedure, Dictionary<string, object> parameters, Func<MySqlDataReader, T> func)
        {
            T returnObject;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand())
            {
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Connection = connection;

                foreach (KeyValuePair<string, object> item in parameters)
                {
                    MySqlParameter x = new MySqlParameter(item.Key, item.Value);
                    x.MySqlDbType = MySqlDbType.VarChar;
                    
                    cmd.Parameters.Add(x);
                }
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                    returnObject = func(reader);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    throw;
                }
                connection.Close();
            }
            return returnObject;
        }

        internal MySqlDataReader ExecuteProcedure(string procedure)
        {
            MySqlDataReader mySqlDataReader;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(procedure))
            {
                cmd.Connection.Open();
                mySqlDataReader = cmd.ExecuteReader();
                connection.Close();
            }
            return mySqlDataReader;
        }

        internal List<Image> GetImages()
        {
            return Images;
        }
        internal Image GetImageById(int id)
        {
            return Images.Single(item => item.Id.Equals(id));
        }

        internal bool AddImage(Image image)
        {
            if(Images.Any(itemInItems => itemInItems.Id.Equals(image.Id)))
            {
                return false;
            }
            Images.Add(image);
            return true;
        }

        internal bool RemoveImage(Image image)
        {
            if (Images.Any(itemInItems => itemInItems.Equals(image)))
            {
                return Images.Remove(image);
            }
            return false;
        }
    }
}
