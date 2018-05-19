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

namespace Input.Modules.SF_UserRegistration
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_UserRegistration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_UserRegistrationController : IPortable
    {

        #region Constructors

        public SF_UserRegistrationController()
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
        /// <param name="objSF_UserRegistration">The SF_UserRegistrationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_UserRegistration(SF_UserRegistrationInfo objSF_UserRegistration)
        {
            if (objSF_UserRegistration.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_UserRegistration(objSF_UserRegistration.ModuleId, objSF_UserRegistration.Content, objSF_UserRegistration.CreatedByUser);
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
        public void DeleteSF_UserRegistration(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_UserRegistration(ModuleId, ItemId);
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
        public SF_UserRegistrationInfo GetSF_UserRegistration(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_UserRegistrationInfo>(DataProvider.Instance().GetSF_UserRegistration(ModuleId, ItemId));
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
        public List<SF_UserRegistrationInfo> GetSF_UserRegistrations(int ModuleId)
        {
            return CBO.FillCollection<SF_UserRegistrationInfo>(DataProvider.Instance().GetSF_UserRegistrations(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_UserRegistration">The SF_UserRegistrationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_UserRegistration(SF_UserRegistrationInfo objSF_UserRegistration)
        {
            if (objSF_UserRegistration.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_UserRegistration(objSF_UserRegistration.ModuleId, objSF_UserRegistration.ItemId, objSF_UserRegistration.Content, objSF_UserRegistration.CreatedByUser);
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
            List<SF_UserRegistrationInfo> colSF_UserRegistrations = GetSF_UserRegistrations(ModuleID);

            if (colSF_UserRegistrations.Count != 0)
            {
                strXML += "<SF_UserRegistrations>";
                foreach (SF_UserRegistrationInfo objSF_UserRegistration in colSF_UserRegistrations)
                {
                    strXML += "<SF_UserRegistration>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_UserRegistration.Content) + "</content>";
                    strXML += "</SF_UserRegistration>";
                }
                strXML += "</SF_UserRegistrations>";
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
            XmlNode xmlSF_UserRegistrations = Globals.GetContent(Content, "SF_UserRegistrations");

            foreach (XmlNode xmlSF_UserRegistration in xmlSF_UserRegistrations.SelectNodes("SF_UserRegistration"))
            {
                SF_UserRegistrationInfo objSF_UserRegistration = new SF_UserRegistrationInfo();

                objSF_UserRegistration.ModuleId = ModuleID;
                objSF_UserRegistration.Content = xmlSF_UserRegistration.SelectSingleNode("content").InnerText;
                objSF_UserRegistration.CreatedByUser = UserId;
                AddSF_UserRegistration(objSF_UserRegistration);
            }

        }

        #endregion

    }
}

