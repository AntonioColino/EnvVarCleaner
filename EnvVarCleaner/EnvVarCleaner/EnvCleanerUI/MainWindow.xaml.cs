// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-04-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="MainWindow.xaml.cs" company="RegularJoeSoftware Corporation">
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
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Public Constructors

        private readonly string helpFile = Path.Combine( App.AppDirectory, "Help\\Index.html" );

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Title = App.AppName;
            OptionTarget = EnvVarTarget.All;
            Dg1.SelectionChanged += Dg1SelectionChanged;
            OptionComboBox.SelectionChanged += OptionComboBoxOnSelectionChanged;
            AllEnvVarSettings = new ObservableCollection<EnvVarSetting>();
            Update(OptionTarget);
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [delete unconfirmed entries].
        /// </summary>
        /// <value><c> true </c> if [delete unconfirmed entries]; otherwise, <c> false </c>.</value>
        public bool DeleteUnconfirmedEntries { get; set; }

        /// <summary>
        /// Gets or sets the option target.
        /// </summary>
        /// <value>The option target.</value>
        public EnvVarTarget OptionTarget { get; set; }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public EnvVarSetting SelectedItem { get; set; }

        public ObservableCollection<EnvVarSetting> AllEnvVarSettings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use short paths].
        /// </summary>
        /// <value><c> true </c> if [use short paths]; otherwise, <c> false </c>.</value>
        public bool UseShortPaths { get; set; }

        #endregion Public Properties



        #region Private Methods

        /// <summary>
        /// Adds the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void AddOnClick(object sender, RoutedEventArgs e)
        {
            var setting = SelectedItem;
            if (SelectedItem == null) { return; }
            setting.Name += UIText.Copy;
            var pair = EditWindow.Show(setting);
            if (pair.Value != MessageBoxResult.OK && pair.Value != MessageBoxResult.Yes) { return; }
            EnvVarActions.SetEnvVar(pair.Key);
            Update(OptionTarget);
        }

        /// <summary>
        /// Cleans the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CleanOnClick(object sender, RoutedEventArgs e)
        {
            var setting = SelectedItem;
            if (setting == null) { return; }
            EnvVarActions.CleanEnvVar(setting, UseShortPaths, DeleteUnconfirmedEntries);
            Update(OptionTarget);
        }

        /// <summary>
        /// DG1s the selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void Dg1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if( e.AddedItems.Count > 0 ){
            //    var addedItem = e.AddedItems[0];
            //    SelectedItem = addedItem as EnvVarSetting;
            //}
            //else
            //{
            //    SelectedItem = Dg1.SelectedCells.FirstOrDefault( ).Item as EnvVarSetting;
            //}
            SelectedItem = Dg1.SelectedCells.FirstOrDefault().Item as EnvVarSetting;
        }

        /// <summary>
        /// Edits the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void EditOnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { return; }
            var pair = EditWindow.Show(SelectedItem);
            if (pair.Value != MessageBoxResult.OK && pair.Value != MessageBoxResult.Yes) { return; }
            EnvVarActions.SetEnvVar(pair.Key);
            Update(OptionTarget);
        }

        /// <summary>
        /// Exports the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ExportOnClick(object sender, RoutedEventArgs e)
        {
            var setting = SelectedItem;
            if (setting == null) { return; }
            EnvVarActions.ExportEnvVar(setting);
        }

        /// <summary>
        /// Imports the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ImportOnClick(object sender, RoutedEventArgs e)
        {
            var setting = SelectedItem;
            if (setting == null) { return; }
            EnvVarActions.ImportEnvVar(setting);
            Update(OptionTarget);
        }

        /// <summary>
        /// Options the ComboBox on selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void OptionComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(OptionTarget);
        }

        /// <summary>
        /// Removes the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void RemoveOnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { return; }
            if (App.Verbose)
            {
                EnvVarActions.QuestionSetting(UIText.PermentDelete, SelectedItem, EnvVarActions.DeleteEnvVar);
            }
            else {
                EnvVarActions.DeleteEnvVar(SelectedItem);
            }

            Update(OptionTarget);
        }

        /// <summary>
        /// Updates the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        private void Update(EnvVarTarget target)
        {
            AllEnvVarSettings.Clear();
            AllEnvVarSettings = EnvVarActions.GetEnvironmentVariables(target);
            Dg1.DataContext = AllEnvVarSettings;
            Dg1.Items.Refresh();
            SelectedItem = Dg1.SelectedCells.FirstOrDefault().Item as EnvVarSetting;
        }

        #endregion Private Methods

        /// <summary>
        /// Helps the on click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HelpOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(helpFile);
            }catch 
            {
                MessageBox.Show(
                   UIText.HelpFileError, App.AppName, MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}