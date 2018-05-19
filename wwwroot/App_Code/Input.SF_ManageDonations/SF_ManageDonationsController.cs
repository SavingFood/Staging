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

namespace Input.Modules.SF_ManageDonations
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageDonations
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageDonationsController : IPortable
    {

        #region Constructors

        public SF_ManageDonationsController()
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
        /// <param name="objSF_ManageDonations">The SF_ManageDonationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageDonations(SF_ManageDonationsInfo objSF_ManageDonations)
        {
            if (objSF_ManageDonations.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageDonations(objSF_ManageDonations.ModuleId, objSF_ManageDonations.Content, objSF_ManageDonations.CreatedByUser);
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
        public void DeleteSF_ManageDonations(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageDonations(ModuleId, ItemId);
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
        public SF_ManageDonationsInfo GetSF_ManageDonations(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageDonationsInfo>(DataProvider.Instance().GetSF_ManageDonations(ModuleId, ItemId));
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
        public List<SF_ManageDonationsInfo> GetSF_ManageDonationss(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageDonationsInfo>(DataProvider.Instance().GetSF_ManageDonationss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageDonations">The SF_ManageDonationsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageDonations(SF_ManageDonationsInfo objSF_ManageDonations)
        {
            if (objSF_ManageDonations.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageDonations(objSF_ManageDonations.ModuleId, objSF_ManageDonations.ItemId, objSF_ManageDonations.Content, objSF_ManageDonations.CreatedByUser);
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
            List<SF_ManageDonationsInfo> colSF_ManageDonationss = GetSF_ManageDonationss(ModuleID);

            if (colSF_ManageDonationss.Count != 0)
            {
                strXML += "<SF_ManageDonationss>";
                foreach (SF_ManageDonationsInfo objSF_ManageDonations in colSF_ManageDonationss)
                {
                    strXML += "<SF_ManageDonations>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageDonations.Content) + "</content>";
                    strXML += "</SF_ManageDonations>";
                }
                strXML += "</SF_ManageDonationss>";
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
            XmlNode xmlSF_ManageDonationss = Globals.GetContent(Content, "SF_ManageDonationss");

            foreach (XmlNode xmlSF_ManageDonations in xmlSF_ManageDonationss.SelectNodes("SF_ManageDonations"))
            {
                SF_ManageDonationsInfo objSF_ManageDonations = new SF_ManageDonationsInfo();

                objSF_ManageDonations.ModuleId = ModuleID;
                objSF_ManageDonations.Content = xmlSF_ManageDonations.SelectSingleNode("content").InnerText;
                objSF_ManageDonations.CreatedByUser = UserId;
                AddSF_ManageDonations(objSF_ManageDonations);
            }

        }

        #endregion

    }
}

