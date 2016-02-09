// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-09-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="PathName.cs" company="RegularJoeSoftware">
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
#if !MANAGED_METHODS || NATIVE_METHODS

    using System.Runtime.InteropServices;
    using System.Text;

#elif MANAGED_METHODS && !NATIVE_METHODS
    using System;
    using System.IO;
#endif

    /// <summary>
    /// Class PathName.
    /// </summary>
    public static class PathName
    {
        /// <summary>
        /// The maximum path
        /// </summary>
        internal const int MaxPath = 255;

#if !MANAGED_METHODS || NATIVE_METHODS

        /// <summary>
        /// Class NativeMethods.
        /// </summary>
        internal static class NativeMethods
        {
            /// <summary>
            /// Gets the long name of the path.
            /// </summary>
            /// <param name="path">The path.</param>
            /// <param name="longPath">The long path.</param>
            /// <param name="longPathLength">Long length of the path.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetLongPathName(
                [MarshalAs(UnmanagedType.LPTStr)] string path,
                [MarshalAs(UnmanagedType.LPTStr)] StringBuilder longPath,
                int longPathLength);

            /// <summary>
            /// Gets the short name of the path.
            /// </summary>
            /// <param name="path">The path.</param>
            /// <param name="shortPath">The short path.</param>
            /// <param name="shortPathLength">Short length of the path.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetShortPathName(
                [MarshalAs(UnmanagedType.LPTStr)] string path,
                [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath,
                int shortPathLength);
        }

#elif MANAGED_METHODS && !NATIVE_METHODS
        internal static class ManagedMethods
        {
            public static string GetLongPathName(
                string path
                ) { return new FileInfo( path ).FullName; }

            public static string GetShortPathName(
                string path
                ) { return Environment.ExpandEnvironmentVariables(path); }
        }
#endif

        /// <summary>
        /// Gets the long name of the path.
        /// </summary>
        /// <param name="shortName">The short name.</param>
        /// <returns>System.String.</returns>
        public static string GetLongPathName(string shortName)
        {
#if !MANAGED_METHODS || NATIVE_METHODS
            var longPath = new StringBuilder(MaxPath);
            NativeMethods.GetLongPathName(shortName, longPath, MaxPath);
            return longPath.ToString();
#elif MANAGED_METHODS && !NATIVE_METHODS
            return ManagedMethods.GetLongPathName(shortName);
#endif
        }

        /// <summary>
        /// Gets the short name of the path.
        /// </summary>
        /// <param name="longName">The long name.</param>
        /// <returns>System.String.</returns>
        public static string GetShortPathName(string longName)
        {
#if !MANAGED_METHODS || NATIVE_METHODS
            var shortPath = new StringBuilder(MaxPath);
            NativeMethods.GetShortPathName(longName, shortPath, MaxPath);
            return shortPath.ToString();
#elif MANAGED_METHODS && !NATIVE_METHODS
            return ManagedMethods.GetShortPathName(longName);
#endif
        }
    }
}