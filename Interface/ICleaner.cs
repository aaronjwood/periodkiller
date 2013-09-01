using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeriodKiller.Interface
{
    interface ICleaner
    {

        /// <summary>
        /// Get/set whether or not recursive processing should be applied
        /// </summary>
        bool recursiveProcessingEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Get/set the number of periods processed
        /// </summary>
        int numPeriods
        {
            get;
            set;
        }

        /// <summary>
        /// Get/set the number of renames processed
        /// </summary>
        int numRenames
        {
            get;
            set;
        }

        /// <summary>
        /// Get the duplicates structure
        /// </summary>
        List<string[]> Duplicates
        {
            get;
        }

        /// <summary>
        /// Handles removing periods
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        void removePeriods(FolderBrowserDialog selectedFolder);

        /// <summary>
        /// Handles removing text
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        /// <param name="text">The text to be removed</param>
        void removeText(FolderBrowserDialog selectedFolder, string text);
    }
}
