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

namespace Input.Modules.SF_ManageEvent
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageEvent
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageEventController : IPortable
    {

        #region Constructors

        public SF_ManageEventController()
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
        /// <param name="objSF_ManageEvent">The SF_ManageEventInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageEvent(SF_ManageEventInfo objSF_ManageEvent)
        {
            if (objSF_ManageEvent.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageEvent(objSF_ManageEvent.ModuleId, objSF_ManageEvent.Content, objSF_ManageEvent.CreatedByUser);
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
        public void DeleteSF_ManageEvent(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageEvent(ModuleId, ItemId);
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
        public SF_ManageEventInfo GetSF_ManageEvent(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageEventInfo>(DataProvider.Instance().GetSF_ManageEvent(ModuleId, ItemId));
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
        public List<SF_ManageEventInfo> GetSF_ManageEvents(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageEventInfo>(DataProvider.Instance().GetSF_ManageEvents(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageEvent">The SF_ManageEventInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageEvent(SF_ManageEventInfo objSF_ManageEvent)
        {
            if (objSF_ManageEvent.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageEvent(objSF_ManageEvent.ModuleId, objSF_ManageEvent.ItemId, objSF_ManageEvent.Content, objSF_ManageEvent.CreatedByUser);
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
            List<SF_ManageEventInfo> colSF_ManageEvents = GetSF_ManageEvents(ModuleID);

            if (colSF_ManageEvents.Count != 0)
            {
                strXML += "<SF_ManageEvents>";
                foreach (SF_ManageEventInfo objSF_ManageEvent in colSF_ManageEvents)
                {
                    strXML += "<SF_ManageEvent>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageEvent.Content) + "</content>";
                    strXML += "</SF_ManageEvent>";
                }
                strXML += "</SF_ManageEvents>";
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
            XmlNode xmlSF_ManageEvents = Globals.GetContent(Content, "SF_ManageEvents");

            foreach (XmlNode xmlSF_ManageEvent in xmlSF_ManageEvents.SelectNodes("SF_ManageEvent"))
            {
                SF_ManageEventInfo objSF_ManageEvent = new SF_ManageEventInfo();

                objSF_ManageEvent.ModuleId = ModuleID;
                objSF_ManageEvent.Content = xmlSF_ManageEvent.SelectSingleNode("content").InnerText;
                objSF_ManageEvent.CreatedByUser = UserId;
                AddSF_ManageEvent(objSF_ManageEvent);
            }

        }

        #endregion

    }
}

