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

namespace Input.Modules.SF_EventFilters
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_EventFilters
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_EventFiltersController : IPortable
    {

        #region Constructors

        public SF_EventFiltersController()
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
        /// <param name="objSF_EventFilters">The SF_EventFiltersInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_EventFilters(SF_EventFiltersInfo objSF_EventFilters)
        {
            if (objSF_EventFilters.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_EventFilters(objSF_EventFilters.ModuleId, objSF_EventFilters.Content, objSF_EventFilters.CreatedByUser);
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
        public void DeleteSF_EventFilters(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_EventFilters(ModuleId, ItemId);
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
        public SF_EventFiltersInfo GetSF_EventFilters(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_EventFiltersInfo>(DataProvider.Instance().GetSF_EventFilters(ModuleId, ItemId));
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
        public List<SF_EventFiltersInfo> GetSF_EventFilterss(int ModuleId)
        {
            return CBO.FillCollection<SF_EventFiltersInfo>(DataProvider.Instance().GetSF_EventFilterss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_EventFilters">The SF_EventFiltersInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_EventFilters(SF_EventFiltersInfo objSF_EventFilters)
        {
            if (objSF_EventFilters.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_EventFilters(objSF_EventFilters.ModuleId, objSF_EventFilters.ItemId, objSF_EventFilters.Content, objSF_EventFilters.CreatedByUser);
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
            List<SF_EventFiltersInfo> colSF_EventFilterss = GetSF_EventFilterss(ModuleID);

            if (colSF_EventFilterss.Count != 0)
            {
                strXML += "<SF_EventFilterss>";
                foreach (SF_EventFiltersInfo objSF_EventFilters in colSF_EventFilterss)
                {
                    strXML += "<SF_EventFilters>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_EventFilters.Content) + "</content>";
                    strXML += "</SF_EventFilters>";
                }
                strXML += "</SF_EventFilterss>";
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
            XmlNode xmlSF_EventFilterss = Globals.GetContent(Content, "SF_EventFilterss");

            foreach (XmlNode xmlSF_EventFilters in xmlSF_EventFilterss.SelectNodes("SF_EventFilters"))
            {
                SF_EventFiltersInfo objSF_EventFilters = new SF_EventFiltersInfo();

                objSF_EventFilters.ModuleId = ModuleID;
                objSF_EventFilters.Content = xmlSF_EventFilters.SelectSingleNode("content").InnerText;
                objSF_EventFilters.CreatedByUser = UserId;
                AddSF_EventFilters(objSF_EventFilters);
            }

        }

        #endregion

    }
}

