using DashboardApp.Models;
using DashboardApp.Services.Interfaces;
using SQLite;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;

namespace DashboardApp.Services
{
    public class UserService : IUserService
    {
        const string _databaseFilename = "DashboardAppSQLite.db3";
        string _databasePath => Path.Combine(FileSystem.AppDataDirectory, _databaseFilename);

        SQLiteConnection _database;

        public UserService()
        {
            _database = new SQLiteConnection(_databasePath);
            _database.CreateTable<User>();
        }

        public void AddUser(User user)
        {
            try
            {
                _database.DeleteAll<User>();
                _database.Insert(user);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public User GetCurrentUser()
        {
            try
            {
                return _database.Table<User>()?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return default;
        }

        public bool CheckIfExists(string login, string pass)
        {
            try
            {
                return _database.Table<User>()?.FirstOrDefault(u => u.Login == login && u.Password == pass) != null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
