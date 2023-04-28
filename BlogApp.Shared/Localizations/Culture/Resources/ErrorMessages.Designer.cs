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
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BlogApp.Shared.Localizations.Culture.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        ///   Looks up a localized string similar to Value cannot be null. An invalid argument was passed to a method..
        /// </summary>
        public static string ArgumentNullException {
            get {
                return ResourceManager.GetString("ArgumentNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Blog was not found..
        /// </summary>
        public static string BlogNotFoundException {
            get {
                return ResourceManager.GetString("BlogNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blogs were not found..
        /// </summary>
        public static string BlogsNotFoundException {
            get {
                return ResourceManager.GetString("BlogsNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with this Email already exists..
        /// </summary>
        public static string EmailAlreadyExistsException {
            get {
                return ResourceManager.GetString("EmailAlreadyExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with this Email: &quot;{0}&quot; was not found..
        /// </summary>
        public static string EmailNotFoundException {
            get {
                return ResourceManager.GetString("EmailNotFoundException", resourceCulture);
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
        ///   Looks up a localized string similar to Failed to create a Blog..
        /// </summary>
        public static string FailedToCreateBlogException {
            get {
                return ResourceManager.GetString("FailedToCreateBlogException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to generate access token during authentication..
        /// </summary>
        public static string FailedToGenerateAccessTokenException {
            get {
                return ResourceManager.GetString("FailedToGenerateAccessTokenException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to register an User..
        /// </summary>
        public static string FailedToRegisterUserExecption {
            get {
                return ResourceManager.GetString("FailedToRegisterUserExecption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not in a correct format..
        /// </summary>
        public static string FormatException {
            get {
                return ResourceManager.GetString("FormatException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error has occured while processing the request..
        /// </summary>
        public static string HttpRequestException {
            get {
                return ResourceManager.GetString("HttpRequestException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Email or Password..
        /// </summary>
        public static string InvalidCredentialsException {
            get {
                return ResourceManager.GetString("InvalidCredentialsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value or data format was passed to a method..
        /// </summary>
        public static string InvalidDataException {
            get {
                return ResourceManager.GetString("InvalidDataException", resourceCulture);
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
        ///   Looks up a localized string similar to An User with this value was not found..
        /// </summary>
        public static string UserNotFoundException {
            get {
                return ResourceManager.GetString("UserNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request validation failed. One or more validation errors occurred..
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
