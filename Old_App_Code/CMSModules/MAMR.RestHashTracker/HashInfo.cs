using System;
using System.Data;
using System.Runtime.Serialization;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using MAMR.RestHashTracker;

[assembly: RegisterObjectType(typeof(HashInfo), HashInfo.OBJECT_TYPE)]
    
namespace MAMR.RestHashTracker
{
    /// <summary>
    /// HashInfo data container class.
    /// </summary>
	[Serializable]
    public class HashInfo : AbstractInfo<HashInfo>
    {
        #region "Type information"

        /// <summary>
        /// Object type
        /// </summary>
        public const string OBJECT_TYPE = "mamr.hash";


        /// <summary>
        /// Type information.
        /// </summary>
#warning "You will need to configure the type info."
        public static ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(HashInfoProvider), OBJECT_TYPE, "MAMR.Hash", "HashID", "HashLastModified", "HashGUID", "HashCodeName", "HashDisplayName", null, null, null, null)
        {
			ModuleName = "MAMR.RestHashTracker",
			TouchCacheDependencies = true,
        };

        #endregion


        #region "Properties"

        /// <summary>
        /// Hash ID
        /// </summary>
        [DatabaseField]
        public virtual int HashID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("HashID"), 0);
            }
            set
            {
                SetValue("HashID", value);
            }
        }


        /// <summary>
        /// Hash GUID
        /// </summary>
        [DatabaseField]
        public virtual Guid HashGUID
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("HashGUID"), Guid.Empty);
            }
            set
            {
                SetValue("HashGUID", value);
            }
        }


        /// <summary>
        /// Hash last modified
        /// </summary>
        [DatabaseField]
        public virtual DateTime HashLastModified
        {
            get
            {
                return ValidationHelper.GetDateTime(GetValue("HashLastModified"), DateTimeHelper.ZERO_TIME);
            }
            set
            {
                SetValue("HashLastModified", value, DateTimeHelper.ZERO_TIME);
            }
        }


        /// <summary>
        /// Hash display name
        /// </summary>
        [DatabaseField]
        public virtual string HashDisplayName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("HashDisplayName"), String.Empty);
            }
            set
            {
                SetValue("HashDisplayName", value);
            }
        }


        /// <summary>
        /// Hash code name
        /// </summary>
        [DatabaseField]
        public virtual string HashCodeName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("HashCodeName"), String.Empty);
            }
            set
            {
                SetValue("HashCodeName", value);
            }
        }


        /// <summary>
        /// Hash url
        /// </summary>
        [DatabaseField]
        public virtual string HashUrl
        {
            get
            {
                return ValidationHelper.GetString(GetValue("HashUrl"), String.Empty);
            }
            set
            {
                SetValue("HashUrl", value);
            }
        }


        /// <summary>
        /// Hash secure url
        /// </summary>
        [DatabaseField]
        public virtual string HashSecureUrl
        {
            get
            {
                return ValidationHelper.GetString(GetValue("HashSecureUrl"), String.Empty);
            }
            set
            {
                SetValue("HashSecureUrl", value, String.Empty);
            }
        }

        #endregion


        #region "Type based properties and methods"

        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            HashInfoProvider.DeleteHashInfo(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            HashInfoProvider.SetHashInfo(this);
        }

        #endregion


        #region "Constructors"

		/// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public HashInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates an empty HashInfo object.
        /// </summary>
        public HashInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Constructor - Creates a new HashInfo object from the given DataRow.
        /// </summary>
        /// <param name="dr">DataRow with the object data</param>
        public HashInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }

        #endregion
    }
}