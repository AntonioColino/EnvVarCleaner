// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-07-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="EnvVarActions.cs" company="RegularJoeSoftware">
//     Copyright ©  2016
// </copyright>
// <summary>
// THIS CODE AND INFORMATION IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
// </summary>
// ***********************************************************************

// ReSharper disable RedundantArgumentDefaultValue

namespace EnvCleanerUI
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;

    /// <summary>
    /// Class EnvVarActions.
    /// </summary>
    public class EnvVarActions
    {
        #region Public Delegates

        /// <summary>
        /// Delegate EnvVarSettingFunction
        /// </summary>
        /// <param name="setting">The setting.</param>
        public delegate void EnvVarSettingFunction(EnvVarSetting setting);

        #endregion Public Delegates



        #region Public Methods

        /// <summary>
        /// Cleans the environment variable.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="useShortPaths">if set to <c>true</c> [use short paths].</param>
        /// <param name="deleteNonPath">if set to <c>true</c> [delete non path].</param>
        public static void CleanEnvVar(EnvVarSetting setting, bool useShortPaths, bool deleteNonPath)
        {
            if (setting == null)
            {
                HandleError(UIText.NoEnvSelected);
                return;
            }

            var environmentVariableValue = setting.Value;
            if (environmentVariableValue != null)
            {
                var list =
                    new List<string>(
                        environmentVariableValue.Split(
                            new[] { UIText.Delimitter },
                            StringSplitOptions.RemoveEmptyEntries));
                var varBuilder = new StringBuilder(UIText.MaxPath);
                foreach (var str in list)
                {
                    if (!deleteNonPath || PathExists(str))
                    {
                        var shortname = useShortPaths
                                            ? PathName.GetShortPathName(str)
                                            : PathName.GetLongPathName(str);
                        varBuilder.Append(shortname);
                        varBuilder.Append(UIText.Delimitter);
                    }
                    else {
                        if (!App.Verbose) { continue; }
                        var builder = new StringBuilder();
                        builder.Append(UIText.EnvVarEntry);
                        builder.Append(str);
                        builder.Append(UIText.DiscardPath);
                        var result = MessageBox.Show(
                            builder.ToString(),
                            App.AppName,
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Warning);
                        if (result == MessageBoxResult.OK || result == MessageBoxResult.Yes) { continue; }
                        var shortname = useShortPaths
                                            ? PathName.GetShortPathName(str)
                                            : PathName.GetLongPathName(str);
                        varBuilder.Append(shortname);
                        varBuilder.Append(UIText.Delimitter);
                    }
                }

                setting.Value = varBuilder.ToString();
                SetEnvVar(setting);
            }
            
        }

        /// <summary>
        /// Deletes the environment variable completely.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public static void DeleteEnvVar(EnvVarSetting setting)
        {
            if (setting == null)
            {
                HandleError(UIText.NoEnvSelected);
                return;
            }
            Environment.SetEnvironmentVariable(setting.Name, null, setting.Target);
        }

        /// <summary>
        /// Exports the environment variable to the chosen text file.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public static void ExportEnvVar(EnvVarSetting setting)
        {
            if (setting == null)
            {
                HandleError(UIText.NoEnvSelected);
                return;
            }

            var desktop = Environment.SpecialFolder.DesktopDirectory.ToString();
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = UIText.SaveFileFilter,
                Title = UIText.SaveFileTitle,
                InitialDirectory = desktop,
                FileName = $"{setting.Name}.{UIText.SaveFileExt}",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() == null) { return; }
            if (saveFileDialog1.FileName == UIText.EmptyString) { return; }
            File.WriteAllText(saveFileDialog1.FileName, setting.ToString());
        }

        /// <summary>
        /// Gets the environment variables.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>ObservableCollection&lt;EnvVarSetting&gt;.</returns>
        public static ObservableCollection<EnvVarSetting> GetEnvironmentVariables(
            EnvVarTarget target = EnvVarTarget.All)
        {
            var nsetting = new ObservableCollection<EnvVarSetting>();
            switch (target)
            {
                case EnvVarTarget.Process:
                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.Process))
                    {
                        nsetting.Add(setting);
                    }

                    break;

                case EnvVarTarget.User:
                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.User))
                    {
                        nsetting.Add(setting);
                    }

                    break;

                case EnvVarTarget.Machine:
                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.Machine))
                    {
                        nsetting.Add(setting);
                    }

                    break;

                case EnvVarTarget.All:
                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.Process))
                    {
                        nsetting.Add(setting);
                    }

                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.User))
                    {
                        nsetting.Add(setting);
                    }

                    foreach (
                        var setting in
                            from DictionaryEntry entry in
                                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine)
                            select
                                new EnvVarSetting(
                                entry.Key.ToString(),
                                entry.Value.ToString(),
                                EnvironmentVariableTarget.Machine))
                    {
                        nsetting.Add(setting);
                    }

                    break;

                default:
                    HandleError(UIText.UnknownEnvVarTarget);
                    break;
            }

            return nsetting;
        }

        /// <summary>
        /// Handles the error.
        /// Just a messagebox with the app name and an error icon.
        /// </summary>
        /// <param name="errorMsg">The error MSG.</param>
        public static void HandleError(string errorMsg)
        {
            MessageBox.Show(errorMsg, App.AppName, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Handles the MSG.
        /// Just a messagebox with the app name and an information icon.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void HandleMsg(string msg)
        {
            MessageBox.Show(msg, App.AppName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Imports the environment variable.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public static void ImportEnvVar(EnvVarSetting setting)
        {
            if (setting == null) { setting = EnvVarSetting.DefaultSetting; }
            var desktop = Environment.SpecialFolder.DesktopDirectory.ToString();
            var saveFileDialog1 = new OpenFileDialog
            {
                Filter = UIText.OpenFileFilter,
                Title = UIText.OpenFileTitle,
                InitialDirectory = desktop,
                FileName = $"{setting.Name}.{UIText.OpenFileExt}",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() == null) { return; }
            if (saveFileDialog1.FileName == UIText.EmptyString) { return; }
            var allText = File.ReadAllText(saveFileDialog1.FileName);
            setting = EnvVarSetting.FromString(allText);
            if (setting != null)
            {
                SetEnvVar(setting);
            }
            else {
                HandleError(UIText.ParseError);
            }
        }

        /// <summary>
        /// Determines whether the specified setting is an existing enviornment variable.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns><c> true </c> if [is existing enviornment variable] [the specified setting]; otherwise, <c> false </c>.</returns>
        public static bool IsExistingEnvVar(EnvVarSetting setting)
        {
            if (setting == null) { return false; }
            return GetEnvironmentVariables().Any(envVarSetting => string.Equals(setting.Name, envVarSetting.Name));
        }

        /// <summary>
        /// Pathes the exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool PathExists(string path)
        {
            return !string.IsNullOrEmpty(path) && (File.Exists(path) || Directory.Exists(path));
        }

        /// <summary>
        /// Sends a confirm question to the ui to check if the setting is correct.
        /// If it is, it fires the given delegate.
        /// The function must match the signature, public void MyFunction(EnvVarSetting setting); .
        /// </summary>
        /// <param name="actionMsg">The action MSG.</param>
        /// <param name="setting">The setting.</param>
        /// <param name="function">The function.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void QuestionSetting(string actionMsg, EnvVarSetting setting, EnvVarSettingFunction function)
        {
            var builder = new StringBuilder();
            builder.Append(UIText.AreYouSure);
            builder.Append(actionMsg);
            builder.Append(UIText.EnvVarXName);
            builder.Append(setting.Name);
            builder.Append(UIText.Comma);
            builder.Append(UIText.XValue);
            builder.Append(setting.Value);
            builder.Append(UIText.Comma);
            builder.Append(UIText.XTarget);
            builder.Append(setting.Target);
            builder.Append(UIText.EndCap);
            var result = MessageBox.Show(
                builder.ToString(),
                App.AppName,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.OK:
                case MessageBoxResult.Yes:
                    function(setting);
                    break;

                case MessageBoxResult.None:
                case MessageBoxResult.Cancel:
                case MessageBoxResult.No:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(UIText.MboxRangeError);
            }
        }

        /// <summary>
        /// Sets the enviornment variable.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public static void SetEnvVar(EnvVarSetting setting)
        {
            if (setting == null)
            {
                HandleError(UIText.NoEnvSelected);
                return;
            }

            if (!IsExistingEnvVar(setting) || !App.Verbose)
            {
                // If the variable does not exist or the app does not have tight checking,
                // we can write it without worry that it will overwrite something.
                Environment.SetEnvironmentVariable(setting.Name, setting.Value, setting.Target);
            }
            else {
                // If the variable does exist than we have to check.
                var builder = new StringBuilder();
                builder.Append(UIText.AreYouSureOw);
                builder.Append(setting.Name);
                builder.Append(UIText.AreYouSureWv);
                builder.Append(setting.Value);
                builder.Append(UIText.AreYouSureIt);
                builder.Append(setting.Target);
                builder.Append(UIText.AreYouSureG);
                var result = MessageBox.Show(
                    builder.ToString(),
                    App.AppName,
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK || result == MessageBoxResult.Yes)
                {
                    // if it is approved...
                    Environment.SetEnvironmentVariable(setting.Name, setting.Value, setting.Target);
                }
                else {
                    HandleMsg(UIText.NoChanges);
                }
            }
        }

        #endregion Public Methods
    }
}