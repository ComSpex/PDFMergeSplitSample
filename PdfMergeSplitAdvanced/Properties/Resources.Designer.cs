﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PdfMergeSplit.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PdfMergeSplit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///
        ///In order to resolve this issue, copy the required DLL to a directory known to the project, e.g. to bin/Debug..
        /// </summary>
        internal static string MsgDLLNotFound {
            get {
                return ResourceManager.GetString("MsgDLLNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not save to file..
        /// </summary>
        internal static string msgSaveFileErr {
            get {
                return ResourceManager.GetString("msgSaveFileErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon pdf_tools {
            get {
                object obj = ResourceManager.GetObject("pdf_tools", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Close.
        /// </summary>
        internal static string strClose {
            get {
                return ResourceManager.GetString("strClose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete all Pages.
        /// </summary>
        internal static string strDeleteAllPages {
            get {
                return ResourceManager.GetString("strDeleteAllPages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete Page.
        /// </summary>
        internal static string strDeletePage {
            get {
                return ResourceManager.GetString("strDeletePage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input PDF .
        /// </summary>
        internal static string strInputPDF {
            get {
                return ResourceManager.GetString("strInputPDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stripe_gray {
            get {
                object obj = ResourceManager.GetObject("stripe_gray", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output PDF .
        /// </summary>
        internal static string strOuputPDF {
            get {
                return ResourceManager.GetString("strOuputPDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  pages.
        /// </summary>
        internal static string strPages {
            get {
                return ResourceManager.GetString("strPages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save.
        /// </summary>
        internal static string strSave {
            get {
                return ResourceManager.GetString("strSave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\temp\tmp_img_pdf-tools.bmp.
        /// </summary>
        internal static string strTempFile {
            get {
                return ResourceManager.GetString("strTempFile", resourceCulture);
            }
        }
    }
}