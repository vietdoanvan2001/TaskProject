﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskProject.Common {
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
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TaskProject.Common.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Đang hoạt động.
        /// </summary>
        public static string Active {
            get {
                return ResourceManager.GetString("Active", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch an exception.
        /// </summary>
        public static string DevMsg_Exception {
            get {
                return ResourceManager.GetString("DevMsg_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more validation errors occurred.
        /// </summary>
        public static string DevMsg_ValidateFailed {
            get {
                return ResourceManager.GetString("DevMsg_ValidateFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to đã tồn tại.
        /// </summary>
        public static string Duplicate {
            get {
                return ResourceManager.GetString("Duplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không được để trống.
        /// </summary>
        public static string Error_InvalidData {
            get {
                return ResourceManager.GetString("Error_InvalidData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ngừng hoạt động.
        /// </summary>
        public static string InActive {
            get {
                return ResourceManager.GetString("InActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute SQL Command catch Exception.
        /// </summary>
        public static string ServiceResult_Exception {
            get {
                return ResourceManager.GetString("ServiceResult_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute SQL Command return null.
        /// </summary>
        public static string ServiceResult_Fail {
            get {
                return ResourceManager.GetString("ServiceResult_Fail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute SQL Command Success.
        /// </summary>
        public static string ServiceResult_Success {
            get {
                return ResourceManager.GetString("ServiceResult_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra, vui lòng liên hệ trung tâm tư vấn!.
        /// </summary>
        public static string UserMsg_Exception {
            get {
                return ResourceManager.GetString("UserMsg_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chờ duyệt.
        /// </summary>
        public static string Waitting {
            get {
                return ResourceManager.GetString("Waitting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tài khoản hoặc mật khẩu không chính xác.
        /// </summary>
        public static string Wrong_Account {
            get {
                return ResourceManager.GetString("Wrong_Account", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to sai định dạng.
        /// </summary>
        public static string WrongFormat {
            get {
                return ResourceManager.GetString("WrongFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to chỉ được phép chứa số.
        /// </summary>
        public static string WrongOnlyNumberFormat {
            get {
                return ResourceManager.GetString("WrongOnlyNumberFormat", resourceCulture);
            }
        }
    }
}
