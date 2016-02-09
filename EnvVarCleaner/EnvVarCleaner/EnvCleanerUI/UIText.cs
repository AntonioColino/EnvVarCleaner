// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="UIText.cs" company="RegularJoeSoftware">
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
    /// <summary>
    /// Class UIText.
    /// </summary>
    public static class UIText
    {
        #region Internal Fields

        /// <summary>
        /// The are you sure
        /// </summary>
        internal const string AreYouSure = @"Are you sure you would like to ";

        /// <summary>
        /// The are you sure g
        /// </summary>
        internal const string AreYouSureG = @" group?";

        /// <summary>
        /// The are you sure it
        /// </summary>
        internal const string AreYouSureIt = @" in the ";

        /// <summary>
        /// The are you sure ow
        /// </summary>
        internal const string AreYouSureOw = @"Are you sure you want to overwrite variable ";

        /// <summary>
        /// The are you sure wv
        /// </summary>
        internal const string AreYouSureWv = @" with value ";

        /// <summary>
        /// The comma
        /// </summary>
        internal const string Comma = @",";

        /// <summary>
        /// The commit changes
        /// </summary>
        internal const string CommitChanges = "Would you like to commit these changes?";

        /// <summary>
        /// The commit paths
        /// </summary>
        internal const string CommitPaths =
            "Would you like to use short or long paths?\n Long paths are human readable while short paths save enviornment variable space and allow the machiene to parse faster.\n";

        /// <summary>
        /// The confirm changes
        /// </summary>
        internal const string ConfirmChanges = "Changes were commited on ";

        /// <summary>
        /// The copy
        /// </summary>
        internal const string Copy = @"_COPY";

        /// <summary>
        /// The delimitter
        /// </summary>
        internal const char Delimitter = ';';

        /// <summary>
        /// The discard changes
        /// </summary>
        internal const string DiscardChanges = "Changes were discarded.";

        /// <summary>
        /// The discard path
        /// </summary>
        internal const string DiscardPath = @" is not a valid path. Would you like to discard it?";

        /// <summary>
        /// The divider
        /// </summary>
        internal const string Divider = "----------------------------------";

        /// <summary>
        /// The empty string
        /// </summary>
        internal const string EmptyString = @"";

        /// <summary>
        /// The end cap
        /// </summary>
        internal const string EndCap = " ]\n";

        /// <summary>
        /// The env variable entry
        /// </summary>
        internal const string EnvVarEntry = @"The enviornment variable entry value: ";

        /// <summary>
        /// The environment variable exists
        /// </summary>
        internal const string EnvVarExists = @"The enviornment variable you are trying to add already exists.";

        /// <summary>
        /// The environment variable not exists
        /// </summary>
        internal const string EnvVarNotExists = "{0} does not exist.";

        /// <summary>
        /// The environment variable not found
        /// </summary>
        internal const string EnvVarNotFound = "Environment variable could not be found.";

        /// <summary>
        /// The environment variable null
        /// </summary>
        internal const string EnvVarNull = "Environment variable was null or empty.";

        /// <summary>
        /// The environment variable original
        /// </summary>
        internal const string EnvVarOriginal = "Environment variable found: \n";

        /// <summary>
        /// The environment variable parse error
        /// </summary>
        internal const string EnvVarParseError = @"The enviornment variable text file could not sucessfully be parsed.";

        /// <summary>
        /// The env variable x name
        /// </summary>
        internal const string EnvVarXName = @" enviornment variable [ Name: ";

        /// <summary>
        /// The has been cleaned
        /// </summary>
        internal const string HasBeenCleaned = @"has been cleaned";

        /// <summary>
        /// The has been deleted
        /// </summary>
        internal const string HasBeenDeleted = @"has been deleted";

        /// <summary>
        /// The has been set
        /// </summary>
        internal const string HasBeenSet = @"has been set";

        /// <summary>
        /// The help file error
        /// </summary>
        internal const string HelpFileError = "Make sure the help files are in the proper install location and have not been moved or deleted. If all else fails, reinstall the application.";

        /// <summary>
        /// The l
        /// </summary>
        internal const string L = "l";

        /// <summary>
        /// The long
        /// </summary>
        internal const string Long = @"long";

        /// <summary>
        /// The maximum path
        /// </summary>
        internal const int MaxPath = 255;

        /// <summary>
        /// The mbox range error
        /// </summary>
        internal const string MboxRangeError = @"The message box unexpectedly quit.";

        /// <summary>
        /// The n
        /// </summary>
        internal const string N = "n";

        /// <summary>
        /// The no
        /// </summary>
        internal const string No = "no";

        /// <summary>
        /// The no changes
        /// </summary>
        internal const string NoChanges = "No changes were made";

        /// <summary>
        /// The no env selected
        /// </summary>
        internal const string NoEnvSelected = "No enviornment variable was selected to modify.";

        /// <summary>
        /// The open file ext
        /// </summary>
        internal const string OpenFileExt = @"txt";

        /// <summary>
        /// The open file filter
        /// </summary>
        internal const string OpenFileFilter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";

        /// <summary>
        /// The open file title
        /// </summary>
        internal const string OpenFileTitle = @"Import an Enviornment Variable from a File";

        /// <summary>
        /// The parse error
        /// </summary>
        internal const string ParseError = @"No Enviornment Variable Setting could be parsed from the file provided.";

        /// <summary>
        /// The perment delete
        /// </summary>
        internal const string PermentDelete = "permently delete";

        /// <summary>
        /// The question changes
        /// </summary>
        internal const string QuestionChanges = "Enter y for yes and n for no.";

        /// <summary>
        /// The question paths
        /// </summary>
        internal const string QuestionPaths = "Enter s for short paths and l for long paths.";

        /// <summary>
        /// The s
        /// </summary>
        internal const string S = "s";

        /// <summary>
        /// The save file ext
        /// </summary>
        internal const string SaveFileExt = @"txt";

        /// <summary>
        /// The save file filter
        /// </summary>
        internal const string SaveFileFilter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";

        /// <summary>
        /// The save file title
        /// </summary>
        internal const string SaveFileTitle = @"Save an Enviornment Variable to File";

        /// <summary>
        /// The short
        /// </summary>
        internal const string Short = "short";

        /// <summary>
        /// The unknown environment variable target
        /// </summary>
        internal const string UnknownEnvVarTarget = @"Unknown enviornment variable target.";

        /// <summary>
        /// The x name
        /// </summary>
        internal const string XName = @"Name: ";

        /// <summary>
        /// The x target
        /// </summary>
        internal const string XTarget = @"Target: ";

        /// <summary>
        /// The x value
        /// </summary>
        internal const string XValue = @"Value: ";

        /// <summary>
        /// The y
        /// </summary>
        internal const string Y = "y";

        /// <summary>
        /// The yes
        /// </summary>
        internal const string Yes = "yes";

        #endregion Internal Fields
    }
}