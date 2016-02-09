// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="EditWindow.xaml.cs" company="RegularJoeSoftware Corporation">
//     Copyright (c) RegularJoeSoftware Corporation. All rights reserved.
// </copyright>
// <summary>
// THIS CODE AND INFORMATION IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
// </summary>
// ***********************************************************************
namespace EnvCleanerUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditWindow" /> class.
        /// </summary>
        public EditWindow()
        {
            InitializeComponent();
            Result = MessageBoxResult.Cancel;
            Title = App.AppName;
            Update(Setting);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Shows the specified setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="canEditName">if set to <c> true </c> [can edit name].</param>
        /// <param name="canEditValue">if set to <c> true </c> [can edit value].</param>
        /// <param name="canEditTarget">if set to <c> true </c> [can edit target].</param>
        /// <returns>EnvVarSetting.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static KeyValuePair<EnvVarSetting, MessageBoxResult> Show(
            EnvVarSetting setting,
            bool canEditName = true,
            bool canEditValue = true,
            bool canEditTarget = true)
        {
            var w = new EditWindow();
            w.Update(setting, canEditName, canEditValue, canEditTarget);
            var dialog = w.ShowDialog();
            if (dialog == null) { throw new ArgumentNullException(nameof(dialog)); }

            return new KeyValuePair<EnvVarSetting, MessageBoxResult>(Setting, Result);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            EditModel = DataContext as EditModel;
            Setting = EditModel;
        }

        #endregion Protected Methods



        #region Public Properties

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public static MessageBoxResult Result { get; set; }

        /// <summary>
        /// Gets or sets the setting.
        /// </summary>
        /// <value>The setting.</value>
        public static EnvVarSetting Setting { get; set; }

        /// <summary>
        /// Gets or sets the edit model.
        /// </summary>
        /// <value>The edit model.</value>
        public EditModel EditModel { get; set; }

        #endregion Public Properties



        #region Private Methods

        /// <summary>
        /// Cancels the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }

        /// <summary>
        /// Deletes the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void DeleteClicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }

        /// <summary>
        /// Saves the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }

        /// <summary>
        /// Updates the specified setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="canEditName">if set to <c> true </c> [can edit name].</param>
        /// <param name="canEditValue">if set to <c> true </c> [can edit value].</param>
        /// <param name="canEditTarget">if set to <c> true </c> [can edit target].</param>
        private void Update(
            EnvVarSetting setting = null,
            bool canEditName = true,
            bool canEditValue = true,
            bool canEditTarget = true)
        {
            if (setting != null)
            {
                Setting = setting;
            }
            else {
                setting = Setting ?? EnvVarSetting.DefaultSetting;
            }

            EditModel = setting;
            EditModel.CanEditName = canEditName;
            EditModel.CanEditValue = canEditValue;
            EditModel.CanEditTarget = canEditTarget;
            DataContext = EditModel;
        }

        #endregion Private Methods
    }
}