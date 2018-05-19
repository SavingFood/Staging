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

namespace Input.Modules.SF_CreateDonation
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_CreateDonation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_CreateDonationController : IPortable
    {

        #region Constructors

        public SF_CreateDonationController()
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
        /// <param name="objSF_CreateDonation">The SF_CreateDonationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_CreateDonation(SF_CreateDonationInfo objSF_CreateDonation)
        {
            if (objSF_CreateDonation.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_CreateDonation(objSF_CreateDonation.ModuleId, objSF_CreateDonation.Content, objSF_CreateDonation.CreatedByUser);
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
        public void DeleteSF_CreateDonation(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_CreateDonation(ModuleId, ItemId);
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
        public SF_CreateDonationInfo GetSF_CreateDonation(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_CreateDonationInfo>(DataProvider.Instance().GetSF_CreateDonation(ModuleId, ItemId));
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
        public List<SF_CreateDonationInfo> GetSF_CreateDonations(int ModuleId)
        {
            return CBO.FillCollection<SF_CreateDonationInfo>(DataProvider.Instance().GetSF_CreateDonations(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_CreateDonation">The SF_CreateDonationInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_CreateDonation(SF_CreateDonationInfo objSF_CreateDonation)
        {
            if (objSF_CreateDonation.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_CreateDonation(objSF_CreateDonation.ModuleId, objSF_CreateDonation.ItemId, objSF_CreateDonation.Content, objSF_CreateDonation.CreatedByUser);
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
            List<SF_CreateDonationInfo> colSF_CreateDonations = GetSF_CreateDonations(ModuleID);

            if (colSF_CreateDonations.Count != 0)
            {
                strXML += "<SF_CreateDonations>";
                foreach (SF_CreateDonationInfo objSF_CreateDonation in colSF_CreateDonations)
                {
                    strXML += "<SF_CreateDonation>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_CreateDonation.Content) + "</content>";
                    strXML += "</SF_CreateDonation>";
                }
                strXML += "</SF_CreateDonations>";
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
            XmlNode xmlSF_CreateDonations = Globals.GetContent(Content, "SF_CreateDonations");

            foreach (XmlNode xmlSF_CreateDonation in xmlSF_CreateDonations.SelectNodes("SF_CreateDonation"))
            {
                SF_CreateDonationInfo objSF_CreateDonation = new SF_CreateDonationInfo();

                objSF_CreateDonation.ModuleId = ModuleID;
                objSF_CreateDonation.Content = xmlSF_CreateDonation.SelectSingleNode("content").InnerText;
                objSF_CreateDonation.CreatedByUser = UserId;
                AddSF_CreateDonation(objSF_CreateDonation);
            }

        }

        #endregion

    }
}

