// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="EditModel.cs" company="RegularJoeSoftware Corporation">
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

    /// <summary>
    /// Class EditModel.
    /// </summary>
    public class EditModel
    {
        #region Private Fields

        /// <summary>
        /// The empty string
        /// </summary>
        private const string EmptyString = @"";

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EditModel" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="target">The target.</param>
        /// <param name="canEditName">if set to <c> true </c> [can edit name].</param>
        /// <param name="canEditValue">if set to <c> true </c> [can edit value].</param>
        /// <param name="canEditTarget">if set to <c> true </c> [can edit target].</param>
        public EditModel(
            string name = EmptyString,
            string value = EmptyString,
            EnvironmentVariableTarget target = EnvironmentVariableTarget.Process,
            bool canEditName = true,
            bool canEditValue = true,
            bool canEditTarget = true)
        {
            this.CanEditName = canEditName;
            this.CanEditValue = canEditValue;
            this.CanEditTarget = canEditTarget;
            this.Value = value;
            this.Name = name;
            this.Target = target;
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance can edit name.
        /// </summary>
        /// <value><c> true </c> if this instance can edit name; otherwise, <c> false </c>.</value>
        public bool CanEditName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can edit target.
        /// </summary>
        /// <value><c> true </c> if this instance can edit target; otherwise, <c> false </c>.</value>
        public bool CanEditTarget { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can edit value.
        /// </summary>
        /// <value><c> true </c> if this instance can edit value; otherwise, <c> false </c>.</value>
        public bool CanEditValue { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public EnvironmentVariableTarget Target { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        #endregion Public Properties



        #region Public Methods

        /// <summary>
        /// Performs an explicit conversion from <see cref="EnvVarSetting" /> to <see cref="EditModel" />.
        /// </summary>
        /// <param name="envVarSetting">The environment variable setting.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator EditModel(EnvVarSetting envVarSetting)
        {
            return new EditModel(envVarSetting.Name, envVarSetting.Value, envVarSetting.Target);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="EditModel" /> to <see cref="EnvVarSetting" />.
        /// </summary>
        /// <param name="editModel">The edit model.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator EnvVarSetting(EditModel editModel)
        {
            return new EnvVarSetting(editModel.Name, editModel.Value, editModel.Target);
        }

        #endregion Public Methods
    }
}