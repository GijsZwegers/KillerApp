using KillerApp.DataLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    /// <summary>
    /// Horen eigenlijk queries te zijn naar een database. (dit is als voorbeeld even)
    /// </summary>
    internal class ApplicationDatabase
    {
        private const string connectionString = "INSERT CONNECTION STRING HERE";
        private List<Image> Images { get; set; }

        internal ApplicationDatabase()
        {
            Images = new List<Image>
            {
                new Image { Id = 1, Name = "Tandenborstel", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow},
                new Image { Id = 2, Name = "Tandpasta", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow},
                new Image { Id = 3, Name = "Tandenborstelhouder", Width = 52, Height = 52, ContentType = ".png", Length = 52, InsertDate = DateTime.UtcNow, EditDate = DateTime.UtcNow}
            };
        }
        internal MySqlDataReader ExecuteProcedureWithValues(string procedure, Dictionary<string, object> parameters)
        {
            MySqlDataReader mySqlDataReader;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(procedure))
            {
                connection.Open();
                parameters.Select(xd => cmd.Parameters.AddWithValue(xd.Key, xd.Value));
                mySqlDataReader = cmd.ExecuteReader();
                connection.Close();
            }
            return mySqlDataReader;
        }
        internal MySqlDataReader ExecuteProcedure(string procedure)
        {
            MySqlDataReader mySqlDataReader;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(procedure))
            {
                connection.Open();
                mySqlDataReader = cmd.ExecuteReader();
                connection.Close();
            }
            return mySqlDataReader;
        }

        //select * from db.images; idk
        internal List<Image> GetImages()
        {
            return Images;
        }
        internal Image GetImageById(int id)
        {
            return Images.Single(item => item.Id.Equals(id));
        }

        internal bool AddImage(Image item)
        {
            if(Images.Any(itemInItems => itemInItems.Id.Equals(item.Id)))
            {
                return false;
            }
            Images.Add(item);
            return true;
        }

        internal bool RemoveItem(Image item)
        {
            if (Images.Any(itemInItems => itemInItems.Equals(item)))
            {
                return Images.Remove(item);
            }
            return false;
        }
    }
}
