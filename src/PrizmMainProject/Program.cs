﻿using System;
using System.Configuration;
using System.Windows.Forms;

using Ninject;

using Data.DAL.Hibernate;

using PrizmMain.Forms.MainChildForm;
using PrizmMain.Properties;
using PrizmMain.Forms.Common;
using PrizmMain.Security;
using Data.DAL.Security;
using Domain.Entity.Security;

namespace PrizmMain
{
    internal static class Program
    {
        public static IKernel Kernel { get; private set; }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool cmdLineMode = false;
            try
            {
                // Database
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["PrizmDatabase"];

                HibernateUtil.Initialize(settings.ConnectionString);

                // Ninject
                Kernel = new StandardKernel(new PrizmModule());

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                while (!Login())
                {
                   MessageBox.Show(Resources.AuthenticationFailed, "PRIZMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   
                
                Application.Run(new PrizmApplicationXtraForm());
            }
            catch (Exception ex)
            {
                String error = ex.ToString();//String.Format(Resources.IDS_ERROR + Environment.NewLine + "{0}\n{01}", ex.InnerException.Message + Environment.NewLine, ex.InnerException.InnerException.Message + Environment.NewLine);
                if (cmdLineMode)
                {
                    Console.Error.WriteLine(error);
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }

        static bool Login()
        {
           LoginForm dlg = new LoginForm();
           if (dlg.ShowDialog() == DialogResult.OK)
           {
              string login = dlg.Login;
              string password = dlg.Password;

              IUserRepository userRepo = Kernel.Get<IUserRepository>();
              User user = userRepo.FindByLogin(login);

              if (user == null)
                 return false;

              string hash = PasswordEncryptor.EncryptPassword(password);

              if (user.PasswordHash != hash)
                 return false;
              
              ISecurityContext ctx = Kernel.Get<ISecurityContext>();
              ctx.LoggedUser = user;

              HibernateUtil.CurrentUser = ctx.GetLoggedPerson();
              return true;
           }
           else
           {
              System.Environment.Exit(0);
           }

           return false;
        }
    }
}