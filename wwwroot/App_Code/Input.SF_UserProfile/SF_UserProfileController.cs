// 
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2011
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Input.Modules.SF_UserProfile
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_UserProfile
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_UserProfileController : IPortable
    {

        #region Constructors

        public SF_UserProfileController()
        {
        }

        #endregion

        #region Public Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// adds an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_UserProfile">The SF_UserProfileInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_UserProfile(SF_UserProfileInfo objSF_UserProfile)
        {
            if (objSF_UserProfile.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_UserProfile(objSF_UserProfile.ModuleId, objSF_UserProfile.Content, objSF_UserProfile.CreatedByUser);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// deletes an object from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ModuleId">The Id of the module</param>
        /// <param name="ItemId">The Id of the item</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void DeleteSF_UserProfile(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_UserProfile(ModuleId, ItemId);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// gets an object from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="moduleId">The Id of the module</param>
        /// <param name="ItemId">The Id of the item</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public SF_UserProfileInfo GetSF_UserProfile(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_UserProfileInfo>(DataProvider.Instance().GetSF_UserProfile(ModuleId, ItemId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// gets an object from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="moduleId">The Id of the module</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public List<SF_UserProfileInfo> GetSF_UserProfiles(int ModuleId)
        {
            return CBO.FillCollection<SF_UserProfileInfo>(DataProvider.Instance().GetSF_UserProfiles(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_UserProfile">The SF_UserProfileInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_UserProfile(SF_UserProfileInfo objSF_UserProfile)
        {
            if (objSF_UserProfile.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_UserProfile(objSF_UserProfile.ModuleId, objSF_UserProfile.ItemId, objSF_UserProfile.Content, objSF_UserProfile.CreatedByUser);
            }
        }

        #endregion

        #region Optional Interfaces

       

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            string strXML = "";
            List<SF_UserProfileInfo> colSF_UserProfiles = GetSF_UserProfiles(ModuleID);

            if (colSF_UserProfiles.Count != 0)
            {
                strXML += "<SF_UserProfiles>";
                foreach (SF_UserProfileInfo objSF_UserProfile in colSF_UserProfiles)
                {
                    strXML += "<SF_UserProfile>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_UserProfile.Content) + "</content>";
                    strXML += "</SF_UserProfile>";
                }
                strXML += "</SF_UserProfiles>";
            }

            return strXML;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlSF_UserProfiles = Globals.GetContent(Content, "SF_UserProfiles");

            foreach (XmlNode xmlSF_UserProfile in xmlSF_UserProfiles.SelectNodes("SF_UserProfile"))
            {
                SF_UserProfileInfo objSF_UserProfile = new SF_UserProfileInfo();

                objSF_UserProfile.ModuleId = ModuleID;
                objSF_UserProfile.Content = xmlSF_UserProfile.SelectSingleNode("content").InnerText;
                objSF_UserProfile.CreatedByUser = UserId;
                AddSF_UserProfile(objSF_UserProfile);
            }

        }

        #endregion

    }
}

