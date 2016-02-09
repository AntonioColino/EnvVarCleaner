// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-04-2016
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-07-2016
// ***********************************************************************
// <copyright file="App.xaml.cs" company="RegularJoeSoftware">
//     Copyright ©  2016
// </copyright>
// <summary>
// THIS CODE AND INFORMATION IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
// </summary>
// ***********************************************************************
namespace EnvCleanerUI
{
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Reflection;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Private Fields

        /// <summary>
        /// The appname
        /// </summary>
        private static readonly string Appname = typeof(App).Assembly.GetName(false).Name;
        /// <summary>
        /// The appdirectory
        /// </summary>
        private static readonly string Appdirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        #endregion Private Fields

        // ReSharper disable once ConvertToAutoProperty



        #region Public Properties

        /// <summary>
        ///     Gets the name of the application.
        /// </summary>
        /// <value> The name of the application. </value>
        public static string AppName
        {
            get
            {
                // ReSharper disable once ConvertPropertyToExpressionBody
                Contract.Ensures(Contract.Result<string>() != null);
                return Appname;
            }
        }

        /// <summary>
        /// Gets the application directory.
        /// </summary>
        /// <value>The application directory.</value>
        public static string AppDirectory
        {
            get
            {
                // ReSharper disable once ConvertPropertyToExpressionBody
                Contract.Ensures(Contract.Result<string>() != null);
                return Appdirectory;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="App" /> is verbose.
        /// </summary>
        /// <value> <c> true </c> if verbose; otherwise, <c> false </c>. </value>
        public static bool Verbose { get; set; } = true;

        #endregion Public Properties
    }
}