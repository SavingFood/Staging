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

namespace Input.Modules.SF_ManageEvents
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageEvents
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageEventsController : IPortable
    {

        #region Constructors

        public SF_ManageEventsController()
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
        /// <param name="objSF_ManageEvents">The SF_ManageEventsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageEvents(SF_ManageEventsInfo objSF_ManageEvents)
        {
            if (objSF_ManageEvents.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageEvents(objSF_ManageEvents.ModuleId, objSF_ManageEvents.Content, objSF_ManageEvents.CreatedByUser);
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
        public void DeleteSF_ManageEvents(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageEvents(ModuleId, ItemId);
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
        public SF_ManageEventsInfo GetSF_ManageEvents(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageEventsInfo>(DataProvider.Instance().GetSF_ManageEvents(ModuleId, ItemId));
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
        public List<SF_ManageEventsInfo> GetSF_ManageEventss(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageEventsInfo>(DataProvider.Instance().GetSF_ManageEventss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageEvents">The SF_ManageEventsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageEvents(SF_ManageEventsInfo objSF_ManageEvents)
        {
            if (objSF_ManageEvents.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageEvents(objSF_ManageEvents.ModuleId, objSF_ManageEvents.ItemId, objSF_ManageEvents.Content, objSF_ManageEvents.CreatedByUser);
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
            List<SF_ManageEventsInfo> colSF_ManageEventss = GetSF_ManageEventss(ModuleID);

            if (colSF_ManageEventss.Count != 0)
            {
                strXML += "<SF_ManageEventss>";
                foreach (SF_ManageEventsInfo objSF_ManageEvents in colSF_ManageEventss)
                {
                    strXML += "<SF_ManageEvents>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageEvents.Content) + "</content>";
                    strXML += "</SF_ManageEvents>";
                }
                strXML += "</SF_ManageEventss>";
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
            XmlNode xmlSF_ManageEventss = Globals.GetContent(Content, "SF_ManageEventss");

            foreach (XmlNode xmlSF_ManageEvents in xmlSF_ManageEventss.SelectNodes("SF_ManageEvents"))
            {
                SF_ManageEventsInfo objSF_ManageEvents = new SF_ManageEventsInfo();

                objSF_ManageEvents.ModuleId = ModuleID;
                objSF_ManageEvents.Content = xmlSF_ManageEvents.SelectSingleNode("content").InnerText;
                objSF_ManageEvents.CreatedByUser = UserId;
                AddSF_ManageEvents(objSF_ManageEvents);
            }

        }

        #endregion

    }
}

