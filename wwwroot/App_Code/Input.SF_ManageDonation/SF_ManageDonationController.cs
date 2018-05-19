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

namespace Input.Modules.SF_ManageDonation
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageDonation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageDonationController : IPortable
    {

        #region Constructors

        public SF_ManageDonationController()
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
        /// <param name="objSF_ManageDonation">The SF_ManageDonationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageDonation(SF_ManageDonationInfo objSF_ManageDonation)
        {
            if (objSF_ManageDonation.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageDonation(objSF_ManageDonation.ModuleId, objSF_ManageDonation.Content, objSF_ManageDonation.CreatedByUser);
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
        public void DeleteSF_ManageDonation(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageDonation(ModuleId, ItemId);
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
        public SF_ManageDonationInfo GetSF_ManageDonation(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageDonationInfo>(DataProvider.Instance().GetSF_ManageDonation(ModuleId, ItemId));
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
        public List<SF_ManageDonationInfo> GetSF_ManageDonations(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageDonationInfo>(DataProvider.Instance().GetSF_ManageDonations(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageDonation">The SF_ManageDonationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageDonation(SF_ManageDonationInfo objSF_ManageDonation)
        {
            if (objSF_ManageDonation.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageDonation(objSF_ManageDonation.ModuleId, objSF_ManageDonation.ItemId, objSF_ManageDonation.Content, objSF_ManageDonation.CreatedByUser);
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
            List<SF_ManageDonationInfo> colSF_ManageDonations = GetSF_ManageDonations(ModuleID);

            if (colSF_ManageDonations.Count != 0)
            {
                strXML += "<SF_ManageDonations>";
                foreach (SF_ManageDonationInfo objSF_ManageDonation in colSF_ManageDonations)
                {
                    strXML += "<SF_ManageDonation>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageDonation.Content) + "</content>";
                    strXML += "</SF_ManageDonation>";
                }
                strXML += "</SF_ManageDonations>";
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
            XmlNode xmlSF_ManageDonations = Globals.GetContent(Content, "SF_ManageDonations");

            foreach (XmlNode xmlSF_ManageDonation in xmlSF_ManageDonations.SelectNodes("SF_ManageDonation"))
            {
                SF_ManageDonationInfo objSF_ManageDonation = new SF_ManageDonationInfo();

                objSF_ManageDonation.ModuleId = ModuleID;
                objSF_ManageDonation.Content = xmlSF_ManageDonation.SelectSingleNode("content").InnerText;
                objSF_ManageDonation.CreatedByUser = UserId;
                AddSF_ManageDonation(objSF_ManageDonation);
            }

        }

        #endregion

    }
}

