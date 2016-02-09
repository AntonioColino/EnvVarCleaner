using System;
using System.Collections.Generic;

namespace HelpCleaner
{
    using System.IO;

    public class HelpDirectoryWalker : DirectoryWalker
    {

        private const string Filter = "Help File generated with GhostDoc";
        private const string Replacement = "";

        private int counter = 0;
        public HelpDirectoryWalker(string overiddePath = null)
        {
            if( !string.IsNullOrEmpty( overiddePath ) ){
                this.RootPath = overiddePath;
                return;
            }

#if DEBUG

            // extra folders in debug version of project need to be removed 
            // as the Help folder is at the root of the solution directory 
            // and not the debug output folder.
            string debugDirectory = "\\HelpCleaner\\bin\\Debug";
            var path = this.RootPath.Replace( debugDirectory, string.Empty );
#endif
            this.RootPath = Path.Combine(this.RootPath, "Help\\html" );
        }

        /// <summary> Handles the <see cref="E:FileStep" /> event.
        /// This function gets fired for each file handled
        /// </summary>
        /// <param name="e">The <see cref="FileStepEventArgs"/> instance containing the event data.</param>
        protected override void OnFileStep(FileStepEventArgs e)
        {
            var path = e.Info.FullName;
            if( string.IsNullOrEmpty( path ) ) { return; }

            // var newLines = File.ReadAllLines(path).Where(oldLine => !oldLine.Contains( Filter ));
            var newLines = new List< string >( );
            foreach( var readAllLine in File.ReadAllLines( path ) ){
                if( readAllLine.Contains( Filter ) ){
                    var replace = readAllLine.Replace( Filter, Replacement );
                    newLines.Add( replace );
                }
                else{ newLines.Add( readAllLine ); }
            }

            File.WriteAllLines( path, newLines );
        }

        /// <summary>
        /// Handles the <see cref="E:DirectoryStep" /> event.
        /// This function gets fired for each directory handled
        /// </summary>
        /// <param name="e">The <see cref="DirectoryStepEventArgs"/> instance containing the event data.</param>
        protected override void OnDirectoryStep(DirectoryStepEventArgs e)
        {
            counter++;
            Console.WriteLine("directory #{0} searched", counter);
        }

        /// <summary>
        /// Called when [handle error].
        /// This function gets fired for each error handled
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnHandleError(StepErrorEventArgs e)
        {
            if (e.Info is UnauthorizedAccessException)
            { Console.WriteLine("Unauthorized access message: {0}\n", e.Info.Message); }
            else if (e.Info is DirectoryNotFoundException)
            { Console.WriteLine("Directory not found message: {0}\n", e.Info.Message); }
            else if (e.Info is FileNotFoundException)
            { Console.WriteLine("File not found message: {0}\n", e.Info.Message); }
            else { Console.WriteLine("General error message: {0}\n", e.Info.Message); }
        }
    }
}
