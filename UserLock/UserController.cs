using System;
using System.Collections.Generic;
using System.IO; // Это
using System.Runtime.Serialization.Formatters.Binary; // Это

namespace UserLock
{
    public class UserController
    {
        /// <summary>
        /// список наших пользователей
        /// </summary>
        public List<User> Users { get; set; }
        public UserController ()
        {
            Users = LoadUsers();
        }
        private List<User> LoadUsers()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using ( FileStream stream = new FileStream("User.bin" , FileMode.OpenOrCreate) )
            {
                try
                {

                    object userObject = formatter.Deserialize(stream);
                    List<User> users = userObject as List<User>;

                    if (users != null)
                    {
                        return users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
                catch
                {
                    return new List<User>();
                }
            
            }
        }

        public void SaveUser ()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("User.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, Users);
            }
        }

        public  void  AddUser( User user)
        {
            Users.Add(user);
            SaveUser();
        }


    }
}
