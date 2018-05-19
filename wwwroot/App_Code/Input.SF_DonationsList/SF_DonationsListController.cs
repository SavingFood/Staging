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

namespace Input.Modules.SF_DonationsList
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_DonationsList
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_DonationsListController : IPortable
    {

        #region Constructors

        public SF_DonationsListController()
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
        /// <param name="objSF_DonationsList">The SF_DonationsListInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_DonationsList(SF_DonationsListInfo objSF_DonationsList)
        {
            if (objSF_DonationsList.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_DonationsList(objSF_DonationsList.ModuleId, objSF_DonationsList.Content, objSF_DonationsList.CreatedByUser);
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
        public void DeleteSF_DonationsList(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_DonationsList(ModuleId, ItemId);
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
        public SF_DonationsListInfo GetSF_DonationsList(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_DonationsListInfo>(DataProvider.Instance().GetSF_DonationsList(ModuleId, ItemId));
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
        public List<SF_DonationsListInfo> GetSF_DonationsLists(int ModuleId)
        {
            return CBO.FillCollection<SF_DonationsListInfo>(DataProvider.Instance().GetSF_DonationsLists(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_DonationsList">The SF_DonationsListInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_DonationsList(SF_DonationsListInfo objSF_DonationsList)
        {
            if (objSF_DonationsList.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_DonationsList(objSF_DonationsList.ModuleId, objSF_DonationsList.ItemId, objSF_DonationsList.Content, objSF_DonationsList.CreatedByUser);
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
            List<SF_DonationsListInfo> colSF_DonationsLists = GetSF_DonationsLists(ModuleID);

            if (colSF_DonationsLists.Count != 0)
            {
                strXML += "<SF_DonationsLists>";
                foreach (SF_DonationsListInfo objSF_DonationsList in colSF_DonationsLists)
                {
                    strXML += "<SF_DonationsList>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_DonationsList.Content) + "</content>";
                    strXML += "</SF_DonationsList>";
                }
                strXML += "</SF_DonationsLists>";
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
            XmlNode xmlSF_DonationsLists = Globals.GetContent(Content, "SF_DonationsLists");

            foreach (XmlNode xmlSF_DonationsList in xmlSF_DonationsLists.SelectNodes("SF_DonationsList"))
            {
                SF_DonationsListInfo objSF_DonationsList = new SF_DonationsListInfo();

                objSF_DonationsList.ModuleId = ModuleID;
                objSF_DonationsList.Content = xmlSF_DonationsList.SelectSingleNode("content").InnerText;
                objSF_DonationsList.CreatedByUser = UserId;
                AddSF_DonationsList(objSF_DonationsList);
            }

        }

        #endregion

    }
}

