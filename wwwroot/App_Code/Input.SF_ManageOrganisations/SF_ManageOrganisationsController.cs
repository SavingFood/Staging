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

namespace Input.Modules.SF_ManageOrganisations
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageOrganisations
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageOrganisationsController : IPortable
    {

        #region Constructors

        public SF_ManageOrganisationsController()
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
        /// <param name="objSF_ManageOrganisations">The SF_ManageOrganisationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageOrganisations(SF_ManageOrganisationsInfo objSF_ManageOrganisations)
        {
            if (objSF_ManageOrganisations.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageOrganisations(objSF_ManageOrganisations.ModuleId, objSF_ManageOrganisations.Content, objSF_ManageOrganisations.CreatedByUser);
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
        public void DeleteSF_ManageOrganisations(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageOrganisations(ModuleId, ItemId);
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
        public SF_ManageOrganisationsInfo GetSF_ManageOrganisations(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageOrganisationsInfo>(DataProvider.Instance().GetSF_ManageOrganisations(ModuleId, ItemId));
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
        public List<SF_ManageOrganisationsInfo> GetSF_ManageOrganisationss(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageOrganisationsInfo>(DataProvider.Instance().GetSF_ManageOrganisationss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageOrganisations">The SF_ManageOrganisationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageOrganisations(SF_ManageOrganisationsInfo objSF_ManageOrganisations)
        {
            if (objSF_ManageOrganisations.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageOrganisations(objSF_ManageOrganisations.ModuleId, objSF_ManageOrganisations.ItemId, objSF_ManageOrganisations.Content, objSF_ManageOrganisations.CreatedByUser);
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
            List<SF_ManageOrganisationsInfo> colSF_ManageOrganisationss = GetSF_ManageOrganisationss(ModuleID);

            if (colSF_ManageOrganisationss.Count != 0)
            {
                strXML += "<SF_ManageOrganisationss>";
                foreach (SF_ManageOrganisationsInfo objSF_ManageOrganisations in colSF_ManageOrganisationss)
                {
                    strXML += "<SF_ManageOrganisations>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageOrganisations.Content) + "</content>";
                    strXML += "</SF_ManageOrganisations>";
                }
                strXML += "</SF_ManageOrganisationss>";
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
            XmlNode xmlSF_ManageOrganisationss = Globals.GetContent(Content, "SF_ManageOrganisationss");

            foreach (XmlNode xmlSF_ManageOrganisations in xmlSF_ManageOrganisationss.SelectNodes("SF_ManageOrganisations"))
            {
                SF_ManageOrganisationsInfo objSF_ManageOrganisations = new SF_ManageOrganisationsInfo();

                objSF_ManageOrganisations.ModuleId = ModuleID;
                objSF_ManageOrganisations.Content = xmlSF_ManageOrganisations.SelectSingleNode("content").InnerText;
                objSF_ManageOrganisations.CreatedByUser = UserId;
                AddSF_ManageOrganisations(objSF_ManageOrganisations);
            }

        }

        #endregion

    }
}

