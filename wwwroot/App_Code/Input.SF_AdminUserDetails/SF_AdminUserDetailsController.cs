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

namespace Input.Modules.SF_AdminUserDetails
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_AdminUserDetails
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_AdminUserDetailsController :  IPortable
    {

        #region Constructors

        public SF_AdminUserDetailsController()
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
        /// <param name="objSF_AdminUserDetails">The SF_AdminUserDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_AdminUserDetails(SF_AdminUserDetailsInfo objSF_AdminUserDetails)
        {
            if (objSF_AdminUserDetails.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_AdminUserDetails(objSF_AdminUserDetails.ModuleId, objSF_AdminUserDetails.Content, objSF_AdminUserDetails.CreatedByUser);
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
        public void DeleteSF_AdminUserDetails(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_AdminUserDetails(ModuleId, ItemId);
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
        public SF_AdminUserDetailsInfo GetSF_AdminUserDetails(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_AdminUserDetailsInfo>(DataProvider.Instance().GetSF_AdminUserDetails(ModuleId, ItemId));
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
        public List<SF_AdminUserDetailsInfo> GetSF_AdminUserDetailss(int ModuleId)
        {
            return CBO.FillCollection<SF_AdminUserDetailsInfo>(DataProvider.Instance().GetSF_AdminUserDetailss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_AdminUserDetails">The SF_AdminUserDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_AdminUserDetails(SF_AdminUserDetailsInfo objSF_AdminUserDetails)
        {
            if (objSF_AdminUserDetails.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_AdminUserDetails(objSF_AdminUserDetails.ModuleId, objSF_AdminUserDetails.ItemId, objSF_AdminUserDetails.Content, objSF_AdminUserDetails.CreatedByUser);
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
            List<SF_AdminUserDetailsInfo> colSF_AdminUserDetailss = GetSF_AdminUserDetailss(ModuleID);

            if (colSF_AdminUserDetailss.Count != 0)
            {
                strXML += "<SF_AdminUserDetailss>";
                foreach (SF_AdminUserDetailsInfo objSF_AdminUserDetails in colSF_AdminUserDetailss)
                {
                    strXML += "<SF_AdminUserDetails>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_AdminUserDetails.Content) + "</content>";
                    strXML += "</SF_AdminUserDetails>";
                }
                strXML += "</SF_AdminUserDetailss>";
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
            XmlNode xmlSF_AdminUserDetailss = Globals.GetContent(Content, "SF_AdminUserDetailss");

            foreach (XmlNode xmlSF_AdminUserDetails in xmlSF_AdminUserDetailss.SelectNodes("SF_AdminUserDetails"))
            {
                SF_AdminUserDetailsInfo objSF_AdminUserDetails = new SF_AdminUserDetailsInfo();

                objSF_AdminUserDetails.ModuleId = ModuleID;
                objSF_AdminUserDetails.Content = xmlSF_AdminUserDetails.SelectSingleNode("content").InnerText;
                objSF_AdminUserDetails.CreatedByUser = UserId;
                AddSF_AdminUserDetails(objSF_AdminUserDetails);
            }

        }

        #endregion

    }
}

