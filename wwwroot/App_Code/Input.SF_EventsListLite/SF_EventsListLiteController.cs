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

namespace Input.Modules.SF_EventsListLite
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_EventsListLite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_EventsListLiteController : IPortable
    {

        #region Constructors

        public SF_EventsListLiteController()
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
        /// <param name="objSF_EventsListLite">The SF_EventsListLiteInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_EventsListLite(SF_EventsListLiteInfo objSF_EventsListLite)
        {
            if (objSF_EventsListLite.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_EventsListLite(objSF_EventsListLite.ModuleId, objSF_EventsListLite.Content, objSF_EventsListLite.CreatedByUser);
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
        public void DeleteSF_EventsListLite(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_EventsListLite(ModuleId, ItemId);
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
        public SF_EventsListLiteInfo GetSF_EventsListLite(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_EventsListLiteInfo>(DataProvider.Instance().GetSF_EventsListLite(ModuleId, ItemId));
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
        public List<SF_EventsListLiteInfo> GetSF_EventsListLites(int ModuleId)
        {
            return CBO.FillCollection<SF_EventsListLiteInfo>(DataProvider.Instance().GetSF_EventsListLites(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_EventsListLite">The SF_EventsListLiteInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_EventsListLite(SF_EventsListLiteInfo objSF_EventsListLite)
        {
            if (objSF_EventsListLite.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_EventsListLite(objSF_EventsListLite.ModuleId, objSF_EventsListLite.ItemId, objSF_EventsListLite.Content, objSF_EventsListLite.CreatedByUser);
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
            List<SF_EventsListLiteInfo> colSF_EventsListLites = GetSF_EventsListLites(ModuleID);

            if (colSF_EventsListLites.Count != 0)
            {
                strXML += "<SF_EventsListLites>";
                foreach (SF_EventsListLiteInfo objSF_EventsListLite in colSF_EventsListLites)
                {
                    strXML += "<SF_EventsListLite>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_EventsListLite.Content) + "</content>";
                    strXML += "</SF_EventsListLite>";
                }
                strXML += "</SF_EventsListLites>";
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
            XmlNode xmlSF_EventsListLites = Globals.GetContent(Content, "SF_EventsListLites");

            foreach (XmlNode xmlSF_EventsListLite in xmlSF_EventsListLites.SelectNodes("SF_EventsListLite"))
            {
                SF_EventsListLiteInfo objSF_EventsListLite = new SF_EventsListLiteInfo();

                objSF_EventsListLite.ModuleId = ModuleID;
                objSF_EventsListLite.Content = xmlSF_EventsListLite.SelectSingleNode("content").InnerText;
                objSF_EventsListLite.CreatedByUser = UserId;
                AddSF_EventsListLite(objSF_EventsListLite);
            }

        }

        #endregion

    }
}

