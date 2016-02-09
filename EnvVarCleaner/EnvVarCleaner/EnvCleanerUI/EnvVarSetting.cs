// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="EnvVarSetting.cs" company="RegularJoeSoftware Corporation">
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
    using System.Linq;
    using System.Text;

    // public classes...
    /// <summary>
    /// Class EnvVarSetting.
    /// </summary>
    public class EnvVarSetting
    {
        #region Public Fields

        // public fields...
        /// <summary>
        /// The default setting
        /// </summary>
        public static readonly EnvVarSetting DefaultSetting = new EnvVarSetting("MyTempVariable", "C:\\Temp");

        #endregion Public Fields

        // public constructors...

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvVarSetting" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="myTarget">My target.</param>
        public EnvVarSetting(
            string name = EmptyString,
            string value = EmptyString,
            EnvironmentVariableTarget myTarget = EnvironmentVariableTarget.Process)
        {
            this.name = name;
            this.value = value;
            Target = myTarget;
        }

        #endregion Public Constructors

        #region Protected Methods

        // protected methods...
        /// <summary>
        /// Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c> true </c> if XXXX, <c> false </c> otherwise.</returns>
        protected bool Equals(EnvVarSetting other)
        {
            return string.Equals(name, other.name) && string.Equals(value, other.value) && Target == other.Target;
        }

        #endregion Protected Methods



        #region Private Fields

        // const fields...
        /// <summary>
        /// The empty string as a compile time constant.
        /// </summary>
        private const string EmptyString = @"";

        // private fields...
        /// <summary>
        /// My target
        /// </summary>
        private EnvironmentVariableTarget myTarget;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The value
        /// </summary>
        private string value;

        #endregion Private Fields



        #region Public Properties

        // public properties...
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                // value = Environment.GetEnvironmentVariable(name);
                return name;
            }

            set
            {
                name = value;

                // Environment.SetEnvironmentVariable(name, this.value);
            }
        }

        /// <summary>
        /// Gets or sets the Target.
        /// </summary>
        /// <value>The Target.</value>
        // ReSharper disable once ConvertToAutoProperty
        public EnvironmentVariableTarget Target
        {
            get
            {
                return myTarget;
            }

            set
            {
                myTarget = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                // value = Environment.GetEnvironmentVariable(name);
                return value;
            }

            set
            {
                this.value = value;

                // Environment.SetEnvironmentVariable(name, this.value);
            }
        }

        #endregion Public Properties



        #region Public Methods

        /// <summary>
        /// Creates a new setting From the string.
        /// </summary>
        /// <param name="envVarString">The environment variable string.</param>
        /// <returns>EnvVarSetting.</returns>
        public static EnvVarSetting FromString(string envVarString)
        {
            var other = new EnvVarSetting();
            var delimiters = new[] { ',' };
            var split = new List<string>(envVarString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));
            var myXName = string.Empty;
            var myXValue = string.Empty;
            var myXTarget = string.Empty;
            foreach (var strVar in split)
            {
                if (strVar.Contains(UIText.XName))
                {
                    myXName = strVar.Remove(0, UIText.XName.Length);
                }
                else {
                    if (strVar.Contains(UIText.XValue))
                    {
                        myXValue = strVar.Remove(0, UIText.XValue.Length);
                    }
                    else {
                        if (strVar.Contains(UIText.XTarget)) { myXTarget = strVar.Remove(0, UIText.XTarget.Length); }
                    }
                }
            }

            if (string.IsNullOrEmpty(myXName) || string.IsNullOrEmpty(myXValue)) { return null; }
            other.Name = myXName;
            other.Value = myXValue;
            if (string.IsNullOrEmpty(myXTarget)) { return other; }
            EnvironmentVariableTarget target;
            Enum.TryParse(myXTarget, true, out target);
            other.Target = target;
            return other;
        }

        // public operators...
        /// <summary>
        /// Performs an implicit conversion from <see cref="EnvVarSetting" /> to <see cref="EditModel" />.
        /// </summary>
        /// <param name="envVarSetting">The environment variable setting.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator EditModel(EnvVarSetting envVarSetting)
        {
            return new EditModel(envVarSetting.Name, envVarSetting.Value, envVarSetting.Target);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EditModel" /> to <see cref="EnvVarSetting" />.
        /// </summary>
        /// <param name="editModel">The edit model.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator EnvVarSetting(EditModel editModel)
        {
            return new EnvVarSetting(editModel.Name, editModel.Value, editModel.Target);
        }

        // public methods...
        // public methods...
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            value = null;
            Environment.SetEnvironmentVariable(name, value);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var setting = obj as EnvVarSetting;
            if (setting == null) { return obj.Equals(this); }
            return Equals(setting);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Value?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)Target;
                return hashCode;
            }
        }

        /// <summary>
        /// Determines whether [has all targets].
        /// EnvironmentVariableTarget.Machine, EnvironmentVariableTarget.Process, EnvironmentVariableTarget.User
        /// </summary>
        /// <returns><c> true </c> if [has all targets]; otherwise, <c> false </c>.</returns>
        public bool HasAllTargets()
        {
            var targets = new List<EnvironmentVariableTarget>{
                                                                   EnvironmentVariableTarget.Machine,
                                                                   EnvironmentVariableTarget.Process,
                                                                   EnvironmentVariableTarget.User
                                                               };
            return IsTarget(targets);
        }

        /// <summary>
        /// Determines whether this instance is of the Target type.
        /// </summary>
        /// <returns><c> true </c> if this instance is Target; otherwise, <c> false </c>.</returns>
        public bool IsTarget()
        {
            return IsTarget(Target);
        }

        /// <summary>
        /// Determines whether the enviornment variable is of the Target type.
        /// </summary>
        /// <param name="target">The Target.</param>
        /// <returns><c> true </c> if the specified Target is Target; otherwise, <c> false </c>.</returns>
        public bool IsTarget(EnvironmentVariableTarget target)
        {
            var targetValue = Environment.GetEnvironmentVariable(name, target);
            return targetValue != null;
        }

        /// <summary>
        /// Determines whether the enviornment variable is one of the specified targets.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <returns><c> true </c> if the specified targets is Target; otherwise, <c> false </c>.</returns>
        public bool IsTarget(IEnumerable<EnvironmentVariableTarget> targets)
        {
            return
                targets.Select(enumValue => Environment.GetEnvironmentVariable(name, enumValue)).
                    All(targetValue => targetValue != null);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(UIText.XName);
            builder.Append(Name);
            builder.Append(UIText.Comma);
            builder.Append(UIText.XValue);
            builder.Append(Value);
            builder.Append(UIText.Comma);
            builder.Append(UIText.XTarget);
            builder.Append(Target);
            builder.Append(UIText.Comma);
            return builder.ToString();
        }

        #endregion Public Methods
    }
}