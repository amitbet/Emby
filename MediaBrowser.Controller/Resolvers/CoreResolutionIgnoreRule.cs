﻿using MediaBrowser.Controller.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MediaBrowser.Controller.Resolvers
{
    /// <summary>
    /// Provides the core resolver ignore rules
    /// </summary>
    [Export(typeof(IResolutionIgnoreRule))]
    public class CoreResolutionIgnoreRule : IResolutionIgnoreRule
    {
        /// <summary>
        /// Any folder named in this list will be ignored - can be added to at runtime for extensibility
        /// </summary>
        private static readonly List<string> IgnoreFolders = new List<string>
        {
            "trailers",
            "metadata",
            "certificate",
            "backup",
            "ps3_update",
            "ps3_vprm",
            "adv_obj",
            "extrafanart"
        };

        public bool ShouldIgnore(ItemResolveArgs args)
        {
            // Ignore hidden files and folders
            if (args.IsHidden)
            {
                return true;
            }

            if (args.IsDirectory)
            {
                var filename = args.FileInfo.cFileName;

                // Ignore any folders in our list
                if (IgnoreFolders.Contains(filename, StringComparer.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
