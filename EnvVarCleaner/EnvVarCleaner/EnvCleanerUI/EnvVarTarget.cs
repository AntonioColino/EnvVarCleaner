// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="EnvVarTarget.cs" company="RegularJoeSoftware">
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
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enum EnvVarTarget
    /// Akin to EnvironmentVariableTarget but adding member all.
    /// </summary>
    [ComVisible( true )]
    public enum EnvVarTarget
    {
        /// <summary>
        /// The process
        /// </summary>
        Process = 0,

        /// <summary>
        /// The user
        /// </summary>
        User = 1,

        /// <summary>
        /// The machine
        /// </summary>
        Machine = 2,

        /// <summary>
        /// All
        /// </summary>
        All = 3
    }
}