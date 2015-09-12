using System;
using System.Data;

using CMS.Base;
using CMS.DataEngine;
using CMS.Helpers;

namespace MAMR.RestHashTracker
{    
    /// <summary>
    /// Class providing HashInfo management.
    /// </summary>
    public class HashInfoProvider : AbstractInfoProvider<HashInfo, HashInfoProvider>
    {
        #region "Constructors"

        /// <summary>
        /// Constructor
        /// </summary>
        public HashInfoProvider()
            : base(HashInfo.TYPEINFO)
        {
        }

        #endregion


        #region "Public methods - Basic"

        /// <summary>
        /// Returns a query for all the HashInfo objects.
        /// </summary>
        public static ObjectQuery<HashInfo> GetHashs()
        {
            return ProviderObject.GetHashsInternal();
        }


        /// <summary>
        /// Returns HashInfo with specified ID.
        /// </summary>
        /// <param name="id">HashInfo ID</param>
        public static HashInfo GetHashInfo(int id)
        {
            return ProviderObject.GetHashInfoInternal(id);
        }


        /// <summary>
        /// Returns HashInfo with specified name.
        /// </summary>
        /// <param name="name">HashInfo name</param>
        public static HashInfo GetHashInfo(string name)
        {
            return ProviderObject.GetHashInfoInternal(name);
        }


        /// <summary>
        /// Returns HashInfo with specified GUID.
        /// </summary>
        /// <param name="guid">HashInfo GUID</param>                
        public static HashInfo GetHashInfo(Guid guid)
        {
            return ProviderObject.GetHashInfoInternal(guid);
        }


        /// <summary>
        /// Sets (updates or inserts) specified HashInfo.
        /// </summary>
        /// <param name="infoObj">HashInfo to be set</param>
        public static void SetHashInfo(HashInfo infoObj)
        {
            ProviderObject.SetHashInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes specified HashInfo.
        /// </summary>
        /// <param name="infoObj">HashInfo to be deleted</param>
        public static void DeleteHashInfo(HashInfo infoObj)
        {
            ProviderObject.DeleteHashInfoInternal(infoObj);
        }


        /// <summary>
        /// Deletes HashInfo with specified ID.
        /// </summary>
        /// <param name="id">HashInfo ID</param>
        public static void DeleteHashInfo(int id)
        {
            HashInfo infoObj = GetHashInfo(id);
            DeleteHashInfo(infoObj);
        }

        #endregion


        #region "Internal methods - Basic"
	
        /// <summary>
        /// Returns a query for all the HashInfo objects.
        /// </summary>
        protected virtual ObjectQuery<HashInfo> GetHashsInternal()
        {
            return GetObjectQuery();
        }    


        /// <summary>
        /// Returns HashInfo with specified ID.
        /// </summary>
        /// <param name="id">HashInfo ID</param>        
        protected virtual HashInfo GetHashInfoInternal(int id)
        {	
            return GetInfoById(id);
        }


        /// <summary>
        /// Returns HashInfo with specified name.
        /// </summary>
        /// <param name="name">HashInfo name</param>        
        protected virtual HashInfo GetHashInfoInternal(string name)
        {
            return GetInfoByCodeName(name);
        } 


        /// <summary>
        /// Returns HashInfo with specified GUID.
        /// </summary>
        /// <param name="guid">HashInfo GUID</param>
        protected virtual HashInfo GetHashInfoInternal(Guid guid)
        {
            return GetInfoByGuid(guid);
        }


        /// <summary>
        /// Sets (updates or inserts) specified HashInfo.
        /// </summary>
        /// <param name="infoObj">HashInfo to be set</param>        
        protected virtual void SetHashInfoInternal(HashInfo infoObj)
        {
            SetInfo(infoObj);
        }


        /// <summary>
        /// Deletes specified HashInfo.
        /// </summary>
        /// <param name="infoObj">HashInfo to be deleted</param>        
        protected virtual void DeleteHashInfoInternal(HashInfo infoObj)
        {
            DeleteInfo(infoObj);
        }	

        #endregion
    }
}