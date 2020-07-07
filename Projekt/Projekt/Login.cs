using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using MySqlX.XDevAPI.Common;
using System.Security.Cryptography;
using Projekt.DAL.Repositories;

namespace Projekt
{
    class Login
    {
        public static readonly int MinPasswordLength = 6;
        public static readonly int MaxPasswordLength = 16;
        public static readonly int MinLoginLength = 5;
        public static readonly int MaxLoginLength = 10;

        public static bool LOGIN_STATUS = false;

        private static string login = "";
        public static string UserLogin
        {
            get { return login; } 
            set { login = value; }
        }

        public static bool CheckPasswords(string p1, string p2)
        {
            if(p2 == "" && p1 != "")
                MessageBox.Show(Properties.Resources.errorUserDoesNotExist,
                    Properties.Resources.warning);

            else
            if (p1 != p2)
                MessageBox.Show(Properties.Resources.errorDifferentPasswords,
                    Properties.Resources.warning);
            return p1 == p2;
        }

        public static bool HasCorrectChars(string p)
        { 
            var result = p.Any(char.IsUpper) &&
                         p.Any(char.IsLower) &&
                         p.Any(char.IsDigit);

            if (!result)
            {
                MessageBox.Show(Properties.Resources.errorHasCorrectChars,
                    Properties.Resources.warning);
                return false;
            }

            return true;
        }

        public static bool IsCorrectLong(string p)
        { 
            var result = p.Length >= MinPasswordLength &&
                         p.Length <= MaxPasswordLength;

            if (!result)
            {
                MessageBox.Show(Properties.Resources.errorIsCorrectLong,
                    Properties.Resources.warning);
                return false;
            }

            return true;
        }

        public static bool IsPasswordCorrect(string p1, string p2)
            => CheckPasswords(p1, p2) &&
               HasCorrectChars(p1) &&
               IsCorrectLong(p1);

        public static bool IsCorrectLogin(string login)
        {
            var result = login.Length >= MinLoginLength &&
                         login.Length <= MaxLoginLength;

            if (!result)
            {
                MessageBox.Show(Properties.Resources.errorIsCorrectLogin,
                    Properties.Resources.warning);
                return false;
            }

            return true;
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter
                    .ToString(sha256
                    .ComputeHash(Encoding.UTF8
                    .GetBytes(password)))
                    .Replace("-", "");
            }
        }

        public static string GetPassword(string login)
        {
            var Users = UsersRepos.GetAll();
            string password = "";

            foreach (var user in Users)
                if (login == user.Login)
                {
                    password = user.Password;
                    break;
                }

            return password;
        }
    }
}
