﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogApp.Shared.Localizations.Culture.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorTitles {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorTitles() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BlogApp.Shared.Localizations.Culture.Resources.ErrorTitles", typeof(ErrorTitles).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value can not be null..
        /// </summary>
        public static string ArgumentNullException {
            get {
                return ResourceManager.GetString("ArgumentNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid request was made..
        /// </summary>
        public static string BadRequestException {
            get {
                return ResourceManager.GetString("BadRequestException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The request could not be processed because of conflict in the request..
        /// </summary>
        public static string ConflictException {
            get {
                return ResourceManager.GetString("ConflictException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An internal server error has occured..
        /// </summary>
        public static string Exception {
            get {
                return ResourceManager.GetString("Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error occured while processing the request..
        /// </summary>
        public static string HttpRequestException {
            get {
                return ResourceManager.GetString("HttpRequestException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value or data format..
        /// </summary>
        public static string InvalidDataException {
            get {
                return ResourceManager.GetString("InvalidDataException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data can not be found..
        /// </summary>
        public static string NotFoundException {
            get {
                return ResourceManager.GetString("NotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The server encountered an unexpected condition that prevented it from fulfilling the request..
        /// </summary>
        public static string NullReferenceException {
            get {
                return ResourceManager.GetString("NullReferenceException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation was canceled..
        /// </summary>
        public static string OperationCanceledException {
            get {
                return ResourceManager.GetString("OperationCanceledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unauthorized access has been attempted..
        /// </summary>
        public static string UnauthorizedAccessException {
            get {
                return ResourceManager.GetString("UnauthorizedAccessException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request validation failed..
        /// </summary>
        public static string ValidationException {
            get {
                return ResourceManager.GetString("ValidationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error occured while processing the request..
        /// </summary>
        public static string WebException {
            get {
                return ResourceManager.GetString("WebException", resourceCulture);
            }
        }
    }
}
