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

namespace Input.Modules.SF_DonationDetails
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_DonationDetails
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_DonationDetailsController : IPortable
    {

        #region Constructors

        public SF_DonationDetailsController()
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
        /// <param name="objSF_DonationDetails">The SF_DonationDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_DonationDetails(SF_DonationDetailsInfo objSF_DonationDetails)
        {
            if (objSF_DonationDetails.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_DonationDetails(objSF_DonationDetails.ModuleId, objSF_DonationDetails.Content, objSF_DonationDetails.CreatedByUser);
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
        public void DeleteSF_DonationDetails(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_DonationDetails(ModuleId, ItemId);
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
        public SF_DonationDetailsInfo GetSF_DonationDetails(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_DonationDetailsInfo>(DataProvider.Instance().GetSF_DonationDetails(ModuleId, ItemId));
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
        public List<SF_DonationDetailsInfo> GetSF_DonationDetailss(int ModuleId)
        {
            return CBO.FillCollection<SF_DonationDetailsInfo>(DataProvider.Instance().GetSF_DonationDetailss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_DonationDetails">The SF_DonationDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_DonationDetails(SF_DonationDetailsInfo objSF_DonationDetails)
        {
            if (objSF_DonationDetails.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_DonationDetails(objSF_DonationDetails.ModuleId, objSF_DonationDetails.ItemId, objSF_DonationDetails.Content, objSF_DonationDetails.CreatedByUser);
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
            List<SF_DonationDetailsInfo> colSF_DonationDetailss = GetSF_DonationDetailss(ModuleID);

            if (colSF_DonationDetailss.Count != 0)
            {
                strXML += "<SF_DonationDetailss>";
                foreach (SF_DonationDetailsInfo objSF_DonationDetails in colSF_DonationDetailss)
                {
                    strXML += "<SF_DonationDetails>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_DonationDetails.Content) + "</content>";
                    strXML += "</SF_DonationDetails>";
                }
                strXML += "</SF_DonationDetailss>";
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
            XmlNode xmlSF_DonationDetailss = Globals.GetContent(Content, "SF_DonationDetailss");

            foreach (XmlNode xmlSF_DonationDetails in xmlSF_DonationDetailss.SelectNodes("SF_DonationDetails"))
            {
                SF_DonationDetailsInfo objSF_DonationDetails = new SF_DonationDetailsInfo();

                objSF_DonationDetails.ModuleId = ModuleID;
                objSF_DonationDetails.Content = xmlSF_DonationDetails.SelectSingleNode("content").InnerText;
                objSF_DonationDetails.CreatedByUser = UserId;
                AddSF_DonationDetails(objSF_DonationDetails);
            }

        }

        #endregion

    }
}

