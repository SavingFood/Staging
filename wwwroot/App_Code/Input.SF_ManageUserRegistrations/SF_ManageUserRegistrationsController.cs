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

namespace Input.Modules.SF_ManageUserRegistrations
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageUserRegistrations
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageUserRegistrationsController : IPortable
    {

        #region Constructors

        public SF_ManageUserRegistrationsController()
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
        /// <param name="objSF_ManageUserRegistrations">The SF_ManageUserRegistrationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageUserRegistrations(SF_ManageUserRegistrationsInfo objSF_ManageUserRegistrations)
        {
            if (objSF_ManageUserRegistrations.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageUserRegistrations(objSF_ManageUserRegistrations.ModuleId, objSF_ManageUserRegistrations.Content, objSF_ManageUserRegistrations.CreatedByUser);
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
        public void DeleteSF_ManageUserRegistrations(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageUserRegistrations(ModuleId, ItemId);
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
        public SF_ManageUserRegistrationsInfo GetSF_ManageUserRegistrations(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageUserRegistrationsInfo>(DataProvider.Instance().GetSF_ManageUserRegistrations(ModuleId, ItemId));
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
        public List<SF_ManageUserRegistrationsInfo> GetSF_ManageUserRegistrationss(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageUserRegistrationsInfo>(DataProvider.Instance().GetSF_ManageUserRegistrationss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageUserRegistrations">The SF_ManageUserRegistrationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageUserRegistrations(SF_ManageUserRegistrationsInfo objSF_ManageUserRegistrations)
        {
            if (objSF_ManageUserRegistrations.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageUserRegistrations(objSF_ManageUserRegistrations.ModuleId, objSF_ManageUserRegistrations.ItemId, objSF_ManageUserRegistrations.Content, objSF_ManageUserRegistrations.CreatedByUser);
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
            List<SF_ManageUserRegistrationsInfo> colSF_ManageUserRegistrationss = GetSF_ManageUserRegistrationss(ModuleID);

            if (colSF_ManageUserRegistrationss.Count != 0)
            {
                strXML += "<SF_ManageUserRegistrationss>";
                foreach (SF_ManageUserRegistrationsInfo objSF_ManageUserRegistrations in colSF_ManageUserRegistrationss)
                {
                    strXML += "<SF_ManageUserRegistrations>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageUserRegistrations.Content) + "</content>";
                    strXML += "</SF_ManageUserRegistrations>";
                }
                strXML += "</SF_ManageUserRegistrationss>";
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
            XmlNode xmlSF_ManageUserRegistrationss = Globals.GetContent(Content, "SF_ManageUserRegistrationss");

            foreach (XmlNode xmlSF_ManageUserRegistrations in xmlSF_ManageUserRegistrationss.SelectNodes("SF_ManageUserRegistrations"))
            {
                SF_ManageUserRegistrationsInfo objSF_ManageUserRegistrations = new SF_ManageUserRegistrationsInfo();

                objSF_ManageUserRegistrations.ModuleId = ModuleID;
                objSF_ManageUserRegistrations.Content = xmlSF_ManageUserRegistrations.SelectSingleNode("content").InnerText;
                objSF_ManageUserRegistrations.CreatedByUser = UserId;
                AddSF_ManageUserRegistrations(objSF_ManageUserRegistrations);
            }

        }

        #endregion

    }
}

