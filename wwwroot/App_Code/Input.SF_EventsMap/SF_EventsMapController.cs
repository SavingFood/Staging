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

namespace Input.Modules.SF_EventsMap
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_EventsMap
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_EventsMapController : ISearchable, IPortable
    {

        #region Constructors

        public SF_EventsMapController()
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
        /// <param name="objSF_EventsMap">The SF_EventsMapInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_EventsMap(SF_EventsMapInfo objSF_EventsMap)
        {
            if (objSF_EventsMap.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_EventsMap(objSF_EventsMap.ModuleId, objSF_EventsMap.Content, objSF_EventsMap.CreatedByUser);
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
        public void DeleteSF_EventsMap(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_EventsMap(ModuleId, ItemId);
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
        public SF_EventsMapInfo GetSF_EventsMap(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_EventsMapInfo>(DataProvider.Instance().GetSF_EventsMap(ModuleId, ItemId));
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
        public List<SF_EventsMapInfo> GetSF_EventsMaps(int ModuleId)
        {
            return CBO.FillCollection<SF_EventsMapInfo>(DataProvider.Instance().GetSF_EventsMaps(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_EventsMap">The SF_EventsMapInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_EventsMap(SF_EventsMapInfo objSF_EventsMap)
        {
            if (objSF_EventsMap.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_EventsMap(objSF_EventsMap.ModuleId, objSF_EventsMap.ItemId, objSF_EventsMap.Content, objSF_EventsMap.CreatedByUser);
            }
        }

        #endregion

        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
            List<SF_EventsMapInfo> colSF_EventsMaps = GetSF_EventsMaps(ModInfo.ModuleID);

            foreach (SF_EventsMapInfo objSF_EventsMap in colSF_EventsMaps)
            {
                if (objSF_EventsMap != null)
                {
                    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSF_EventsMap.Content, objSF_EventsMap.CreatedByUser, objSF_EventsMap.CreatedDate, ModInfo.ModuleID, objSF_EventsMap.ItemId.ToString(), objSF_EventsMap.Content, "ItemId=" + objSF_EventsMap.ItemId.ToString());
                    SearchItemCollection.Add(SearchItem);
                }
            }

            return SearchItemCollection;
        }


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
            List<SF_EventsMapInfo> colSF_EventsMaps = GetSF_EventsMaps(ModuleID);

            if (colSF_EventsMaps.Count != 0)
            {
                strXML += "<SF_EventsMaps>";
                foreach (SF_EventsMapInfo objSF_EventsMap in colSF_EventsMaps)
                {
                    strXML += "<SF_EventsMap>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_EventsMap.Content) + "</content>";
                    strXML += "</SF_EventsMap>";
                }
                strXML += "</SF_EventsMaps>";
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
            XmlNode xmlSF_EventsMaps = Globals.GetContent(Content, "SF_EventsMaps");

            foreach (XmlNode xmlSF_EventsMap in xmlSF_EventsMaps.SelectNodes("SF_EventsMap"))
            {
                SF_EventsMapInfo objSF_EventsMap = new SF_EventsMapInfo();

                objSF_EventsMap.ModuleId = ModuleID;
                objSF_EventsMap.Content = xmlSF_EventsMap.SelectSingleNode("content").InnerText;
                objSF_EventsMap.CreatedByUser = UserId;
                AddSF_EventsMap(objSF_EventsMap);
            }

        }

        #endregion

    }
}

