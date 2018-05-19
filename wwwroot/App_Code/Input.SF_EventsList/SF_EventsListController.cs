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

namespace Input.Modules.SF_EventsList
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_EventsList
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_EventsListController : IPortable
    {

        #region Constructors

        public SF_EventsListController()
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
        /// <param name="objSF_EventsList">The SF_EventsListInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_EventsList(SF_EventsListInfo objSF_EventsList)
        {
            if (objSF_EventsList.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_EventsList(objSF_EventsList.ModuleId, objSF_EventsList.Content, objSF_EventsList.CreatedByUser);
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
        public void DeleteSF_EventsList(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_EventsList(ModuleId, ItemId);
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
        public SF_EventsListInfo GetSF_EventsList(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_EventsListInfo>(DataProvider.Instance().GetSF_EventsList(ModuleId, ItemId));
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
        public List<SF_EventsListInfo> GetSF_EventsLists(int ModuleId)
        {
            return CBO.FillCollection<SF_EventsListInfo>(DataProvider.Instance().GetSF_EventsLists(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_EventsList">The SF_EventsListInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_EventsList(SF_EventsListInfo objSF_EventsList)
        {
            if (objSF_EventsList.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_EventsList(objSF_EventsList.ModuleId, objSF_EventsList.ItemId, objSF_EventsList.Content, objSF_EventsList.CreatedByUser);
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
        //public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        //{
        //    SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
        //    List<SF_EventsListInfo> colSF_EventsLists = GetSF_EventsLists(ModInfo.ModuleID);

        //    foreach (SF_EventsListInfo objSF_EventsList in colSF_EventsLists)
        //    {
        //        if (objSF_EventsList != null)
        //        {
        //            SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSF_EventsList.Content, objSF_EventsList.CreatedByUser, objSF_EventsList.CreatedDate, ModInfo.ModuleID, objSF_EventsList.ItemId.ToString(), objSF_EventsList.Content, "ItemId=" + objSF_EventsList.ItemId.ToString());
        //            SearchItemCollection.Add(SearchItem);
        //        }
        //    }

        //    return SearchItemCollection;
        //}


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
            List<SF_EventsListInfo> colSF_EventsLists = GetSF_EventsLists(ModuleID);

            if (colSF_EventsLists.Count != 0)
            {
                strXML += "<SF_EventsLists>";
                foreach (SF_EventsListInfo objSF_EventsList in colSF_EventsLists)
                {
                    strXML += "<SF_EventsList>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_EventsList.Content) + "</content>";
                    strXML += "</SF_EventsList>";
                }
                strXML += "</SF_EventsLists>";
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
            XmlNode xmlSF_EventsLists = Globals.GetContent(Content, "SF_EventsLists");

            foreach (XmlNode xmlSF_EventsList in xmlSF_EventsLists.SelectNodes("SF_EventsList"))
            {
                SF_EventsListInfo objSF_EventsList = new SF_EventsListInfo();

                objSF_EventsList.ModuleId = ModuleID;
                objSF_EventsList.Content = xmlSF_EventsList.SelectSingleNode("content").InnerText;
                objSF_EventsList.CreatedByUser = UserId;
                AddSF_EventsList(objSF_EventsList);
            }

        }

        #endregion

    }
}

