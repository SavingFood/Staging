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

namespace Input.Modules.SF_QuantificationReport
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_QuantificationReport
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_QuantificationReportController : IPortable
    {

        #region Constructors

        public SF_QuantificationReportController()
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
        /// <param name="objSF_QuantificationReport">The SF_QuantificationReportInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_QuantificationReport(SF_QuantificationReportInfo objSF_QuantificationReport)
        {
            if (objSF_QuantificationReport.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_QuantificationReport(objSF_QuantificationReport.ModuleId, objSF_QuantificationReport.Content, objSF_QuantificationReport.CreatedByUser);
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
        public void DeleteSF_QuantificationReport(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_QuantificationReport(ModuleId, ItemId);
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
        public SF_QuantificationReportInfo GetSF_QuantificationReport(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_QuantificationReportInfo>(DataProvider.Instance().GetSF_QuantificationReport(ModuleId, ItemId));
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
        public List<SF_QuantificationReportInfo> GetSF_QuantificationReports(int ModuleId)
        {
            return CBO.FillCollection<SF_QuantificationReportInfo>(DataProvider.Instance().GetSF_QuantificationReports(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_QuantificationReport">The SF_QuantificationReportInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_QuantificationReport(SF_QuantificationReportInfo objSF_QuantificationReport)
        {
            if (objSF_QuantificationReport.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_QuantificationReport(objSF_QuantificationReport.ModuleId, objSF_QuantificationReport.ItemId, objSF_QuantificationReport.Content, objSF_QuantificationReport.CreatedByUser);
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
            List<SF_QuantificationReportInfo> colSF_QuantificationReports = GetSF_QuantificationReports(ModuleID);

            if (colSF_QuantificationReports.Count != 0)
            {
                strXML += "<SF_QuantificationReports>";
                foreach (SF_QuantificationReportInfo objSF_QuantificationReport in colSF_QuantificationReports)
                {
                    strXML += "<SF_QuantificationReport>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_QuantificationReport.Content) + "</content>";
                    strXML += "</SF_QuantificationReport>";
                }
                strXML += "</SF_QuantificationReports>";
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
            XmlNode xmlSF_QuantificationReports = Globals.GetContent(Content, "SF_QuantificationReports");

            foreach (XmlNode xmlSF_QuantificationReport in xmlSF_QuantificationReports.SelectNodes("SF_QuantificationReport"))
            {
                SF_QuantificationReportInfo objSF_QuantificationReport = new SF_QuantificationReportInfo();

                objSF_QuantificationReport.ModuleId = ModuleID;
                objSF_QuantificationReport.Content = xmlSF_QuantificationReport.SelectSingleNode("content").InnerText;
                objSF_QuantificationReport.CreatedByUser = UserId;
                AddSF_QuantificationReport(objSF_QuantificationReport);
            }

        }

        #endregion

    }
}

