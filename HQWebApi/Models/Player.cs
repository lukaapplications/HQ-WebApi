using HQWebApi.Helpers;
using System;
using System.Data;

namespace HQWebApi.Models
{
    public class Player
    {
        // Basic info
        public String Name { get; set; }
        public long Id { get; set; }

        // Attributes
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Charisma { get; set; }
        public int Good { get; set; }
        public int Evil { get; set; }

        public Player() { }

        public Player(DataRow row)
        {
            Name = ValidationHelper.GetString(row[nameof(Name)]);
            Id = ValidationHelper.GetLong(row[nameof(Id)]);
            Intelligence = ValidationHelper.GetInt(row[nameof(Intelligence)]);
            Strength = ValidationHelper.GetInt(row[nameof(Strength)]);
            Charisma = ValidationHelper.GetInt(row[nameof(Charisma)]);
            Good = ValidationHelper.GetInt(row[nameof(Good)]);
            Evil = ValidationHelper.GetInt(row[nameof(Evil)]);
        }
    }
}