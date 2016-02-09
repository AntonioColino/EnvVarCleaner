// ***********************************************************************
// Assembly         : HelpCleaner
// Author           : Antonio (Joe) Colino
// Created          : 02-08-2016
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-08-2016
// ***********************************************************************
// <copyright file="DirectoryWalker.cs" company="RegularJoeSoftware Corporation">
//     Copyright (c) RegularJoeSoftware Corporation. All rights reserved.
// </copyright>
// <summary>
// THIS CODE AND INFORMATION IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
// </summary>
// ***********************************************************************
namespace HelpCleaner
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    #endregion

    /// <summary>
    /// Class DirectoryWalker.
    /// </summary>
    public abstract class DirectoryWalker
    {
        #region Private Fields

        /// <summary>
        /// The assembly directory
        /// </summary>
        private static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// The default pattern
        /// </summary>
        private const string DefaultPattern = "*.*";

        /// <summary>
        /// The root
        /// </summary>
        private DirectoryInfo root;

        /// <summary>
        /// The root path
        /// </summary>
        private string rootPath;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryWalker"/> class.
        /// </summary>
        protected DirectoryWalker()
            : this(AssemblyDirectory)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryWalker"/> class.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        protected DirectoryWalker(string rootPath, string searchPattern = null)
        {
            this.rootPath = rootPath;
            this.SearchPatternsearchPattern = !string.IsNullOrEmpty(searchPattern) ? searchPattern : DefaultPattern;
            root = new DirectoryInfo(rootPath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryWalker"/> class.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="searchPattern">The search pattern.</param>
        protected DirectoryWalker(DirectoryInfo root, string searchPattern = null)
        {
            this.root = root;
            this.SearchPatternsearchPattern = !string.IsNullOrEmpty(searchPattern) ? searchPattern : DefaultPattern;
            rootPath = this.root.FullName;
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// Gets or sets the root directory to be used in the traversal.
        /// This changes when RootPath is changed. The default is the Assembly's Directory.
        /// </summary>
        /// <value>The root.</value>
        public DirectoryInfo Root
        {
            get
            {
                return root;
            }

            set
            {
                root = value;
                rootPath = root.FullName;
            }
        }

        /// <summary>
        /// Gets or sets the root path directory to be used in the traversal.
        /// This changes when Root is changed. The default is the Assembly's Directory.
        /// </summary>
        /// <value>The root path.</value>
        public string RootPath
        {
            get
            {
                return rootPath;
            }

            set
            {
                rootPath = value;
                root = new DirectoryInfo(rootPath);
            }
        }

        /// <summary>
        /// Gets or sets the search pattern used for file stepping. The default is *.* (all files).
        /// </summary>
        /// <value>The search patternsearch pattern.</value>
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string SearchPatternsearchPattern { get; set; }

        #endregion Public Properties



        #region Public Methods

        /// <summary>
        /// Handles the <see cref="E:FileStep" /> event.
        /// This function gets fired for each file handled
        /// </summary>
        /// <param name="e">The <see cref="FileStepEventArgs"/> instance containing the event data.</param>
        protected abstract void OnFileStep( FileStepEventArgs e );

        /// <summary>
        /// Handles the <see cref="E:DirectoryStep" /> event.
        /// This function gets fired for each directory handled
        /// </summary>
        /// <param name="e">The <see cref="DirectoryStepEventArgs"/> instance containing the event data.</param>
        protected abstract void OnDirectoryStep( DirectoryStepEventArgs e );

        /// <summary>
        /// Called when [handle error].
        /// This function gets fired for each error handled
        /// </summary>
        /// <param name="e">The e.</param>
        protected abstract void OnHandleError(StepErrorEventArgs e );

        /// <summary>
        /// Walks this instance.
        /// </summary>
        public void Walk( ) { WalkDirectoryTree(root, OnFileStep, OnDirectoryStep, OnHandleError, SearchPatternsearchPattern); }

        /// <summary>
        /// Walks the directory tree.
        /// </summary>
        /// <param name="oneTimeRootPath">The one time root path.</param>
        /// <param name="fileAction">The file action.</param>
        /// <param name="directoryAction">The directory action.</param>
        /// <param name="errorAction">The error action.</param>
        /// <param name="searchPattern">The search pattern.</param>
        public static void WalkDirectoryTree(string oneTimeRootPath, FileStepping fileAction, DirectoryStepping directoryAction, HandleSteppingError errorAction, string searchPattern = null)
        {
            WalkDirectoryTree(new DirectoryInfo(oneTimeRootPath), fileAction, directoryAction, errorAction, searchPattern);
        }

        /// <summary>
        /// Walks the directory tree.
        /// </summary>
        /// <param name="oneTimeRoot">The one time root.</param>
        /// <param name="fileAction">The file action.</param>
        /// <param name="directoryAction">The directory action.</param>
        /// <param name="errorAction">The error action.</param>
        /// <param name="searchPattern">The search pattern.</param>
        public static void WalkDirectoryTree(DirectoryInfo oneTimeRoot, FileStepping fileAction, DirectoryStepping directoryAction, HandleSteppingError errorAction, string searchPattern = null)
        {
            FileInfo[] files = null;

            // First, process all the files directly under this folder
            try{
                files = oneTimeRoot.GetFiles( string.IsNullOrEmpty( searchPattern ) ? DefaultPattern : searchPattern );
            }
            catch ( Exception e )
            {
                errorAction(new StepErrorEventArgs(e));// fire the error handler function
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    try
                    {
                        fileAction(new FileStepEventArgs(fi));
                    }
                    catch (Exception e)
                    {
                        errorAction( new StepErrorEventArgs( e ) );// fire the error handler function
                    }
                }

                // Now find all the subdirectories under this directory.
                IEnumerable< DirectoryInfo > subDirs = oneTimeRoot.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs){
                    // fire the directory action function
                    directoryAction( new DirectoryStepEventArgs( dirInfo ) );

                    // Resursive call for each subdirectory.
                    WalkDirectoryTree( dirInfo, fileAction, directoryAction, errorAction, searchPattern );
                }
            }
        }

        #endregion Public Methods
        
    }

    /// <summary>
    /// Delegate FileStepping
    /// </summary>
    /// <param name="e">The <see cref="FileStepEventArgs"/> instance containing the event data.</param>
    public delegate void FileStepping(FileStepEventArgs e);

    /// <summary>
    /// Delegate DirectoryStepping
    /// </summary>
    /// <param name="e">The <see cref="DirectoryStepEventArgs"/> instance containing the event data.</param>
    public delegate void DirectoryStepping(DirectoryStepEventArgs e);

    /// <summary>
    /// Delegate HandleSteppingError
    /// </summary>
    /// <param name="error">The error.</param>
    public delegate void HandleSteppingError(StepErrorEventArgs error );

    /// <summary>
    /// Class FileStepEventArgs.
    /// </summary>
    public class FileStepEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileStepEventArgs"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        public FileStepEventArgs(FileInfo info) { Info = info; }

        /// <summary>
        /// Gets or sets the file information.
        /// </summary>
        /// <value>The information.</value>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public FileInfo Info { get; set; }
    }

    /// <summary>
    /// Class DirectoryStepEventArgs.
    /// </summary>
    public class DirectoryStepEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryStepEventArgs"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        public DirectoryStepEventArgs(DirectoryInfo info) { Info = info; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The directory information.</value>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DirectoryInfo Info { get; set; }
    }

    /// <summary>
    /// Class StepErrorEventArgs.
    /// </summary>
    public class StepErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StepErrorEventArgs"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        public StepErrorEventArgs(Exception info) { Info = info; }

        /// <summary>
        /// Gets or sets the exception information.
        /// </summary>
        /// <value>The information.</value>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Exception Info { get; set; }
    }
}