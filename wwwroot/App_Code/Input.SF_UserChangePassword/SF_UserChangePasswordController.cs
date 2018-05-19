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

namespace Input.Modules.SF_UserChangePassword
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_UserChangePassword
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_UserChangePasswordController : IPortable
    {

        #region Constructors

        public SF_UserChangePasswordController()
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
        /// <param name="objSF_UserChangePassword">The SF_UserChangePasswordInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_UserChangePassword(SF_UserChangePasswordInfo objSF_UserChangePassword)
        {
            if (objSF_UserChangePassword.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_UserChangePassword(objSF_UserChangePassword.ModuleId, objSF_UserChangePassword.Content, objSF_UserChangePassword.CreatedByUser);
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
        public void DeleteSF_UserChangePassword(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_UserChangePassword(ModuleId, ItemId);
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
        public SF_UserChangePasswordInfo GetSF_UserChangePassword(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_UserChangePasswordInfo>(DataProvider.Instance().GetSF_UserChangePassword(ModuleId, ItemId));
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
        public List<SF_UserChangePasswordInfo> GetSF_UserChangePasswords(int ModuleId)
        {
            return CBO.FillCollection<SF_UserChangePasswordInfo>(DataProvider.Instance().GetSF_UserChangePasswords(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_UserChangePassword">The SF_UserChangePasswordInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_UserChangePassword(SF_UserChangePasswordInfo objSF_UserChangePassword)
        {
            if (objSF_UserChangePassword.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_UserChangePassword(objSF_UserChangePassword.ModuleId, objSF_UserChangePassword.ItemId, objSF_UserChangePassword.Content, objSF_UserChangePassword.CreatedByUser);
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
            List<SF_UserChangePasswordInfo> colSF_UserChangePasswords = GetSF_UserChangePasswords(ModuleID);

            if (colSF_UserChangePasswords.Count != 0)
            {
                strXML += "<SF_UserChangePasswords>";
                foreach (SF_UserChangePasswordInfo objSF_UserChangePassword in colSF_UserChangePasswords)
                {
                    strXML += "<SF_UserChangePassword>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_UserChangePassword.Content) + "</content>";
                    strXML += "</SF_UserChangePassword>";
                }
                strXML += "</SF_UserChangePasswords>";
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
            XmlNode xmlSF_UserChangePasswords = Globals.GetContent(Content, "SF_UserChangePasswords");

            foreach (XmlNode xmlSF_UserChangePassword in xmlSF_UserChangePasswords.SelectNodes("SF_UserChangePassword"))
            {
                SF_UserChangePasswordInfo objSF_UserChangePassword = new SF_UserChangePasswordInfo();

                objSF_UserChangePassword.ModuleId = ModuleID;
                objSF_UserChangePassword.Content = xmlSF_UserChangePassword.SelectSingleNode("content").InnerText;
                objSF_UserChangePassword.CreatedByUser = UserId;
                AddSF_UserChangePassword(objSF_UserChangePassword);
            }

        }

        #endregion

    }
}

