﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TweetMayhem.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TweetMayhem.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to ti7yIb4ZtiyScwfZmU4RQ.
        /// </summary>
        internal static string ConsumerKey {
            get {
                return ResourceManager.GetString("ConsumerKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XzE4NEcLaA8gMVcuZRT9AsR3YpXGm6JskZL567KUaE.
        /// </summary>
        internal static string ConsumerSecret {
            get {
                return ResourceManager.GetString("ConsumerSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are logged in to Twitter as .
        /// </summary>
        internal static string LoginConfirm {
            get {
                return ResourceManager.GetString("LoginConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please log in to Twitter. Clicking the button below will open a web browser to authorize Mayhem to tweet..
        /// </summary>
        internal static string LoginPrompt {
            get {
                return ResourceManager.GetString("LoginPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TweetMayhem.
        /// </summary>
        internal static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
    }
}