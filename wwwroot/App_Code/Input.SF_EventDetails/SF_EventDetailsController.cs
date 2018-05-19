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

namespace Input.Modules.SF_EventDetails
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_EventDetails
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_EventDetailsController :  IPortable
    {

        #region Constructors

        public SF_EventDetailsController()
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
        /// <param name="objSF_EventDetails">The SF_EventDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_EventDetails(SF_EventDetailsInfo objSF_EventDetails)
        {
            if (objSF_EventDetails.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_EventDetails(objSF_EventDetails.ModuleId, objSF_EventDetails.Content, objSF_EventDetails.CreatedByUser);
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
        public void DeleteSF_EventDetails(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_EventDetails(ModuleId, ItemId);
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
        public SF_EventDetailsInfo GetSF_EventDetails(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_EventDetailsInfo>(DataProvider.Instance().GetSF_EventDetails(ModuleId, ItemId));
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
        public List<SF_EventDetailsInfo> GetSF_EventDetailss(int ModuleId)
        {
            return CBO.FillCollection<SF_EventDetailsInfo>(DataProvider.Instance().GetSF_EventDetailss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_EventDetails">The SF_EventDetailsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_EventDetails(SF_EventDetailsInfo objSF_EventDetails)
        {
            if (objSF_EventDetails.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_EventDetails(objSF_EventDetails.ModuleId, objSF_EventDetails.ItemId, objSF_EventDetails.Content, objSF_EventDetails.CreatedByUser);
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
        //    List<SF_EventDetailsInfo> colSF_EventDetailss = GetSF_EventDetailss(ModInfo.ModuleID);

        //    foreach (SF_EventDetailsInfo objSF_EventDetails in colSF_EventDetailss)
        //    {
        //        if (objSF_EventDetails != null)
        //        {
        //            SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSF_EventDetails.Content, objSF_EventDetails.CreatedByUser, objSF_EventDetails.CreatedDate, ModInfo.ModuleID, objSF_EventDetails.ItemId.ToString(), objSF_EventDetails.Content, "ItemId=" + objSF_EventDetails.ItemId.ToString());
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
            List<SF_EventDetailsInfo> colSF_EventDetailss = GetSF_EventDetailss(ModuleID);

            if (colSF_EventDetailss.Count != 0)
            {
                strXML += "<SF_EventDetailss>";
                foreach (SF_EventDetailsInfo objSF_EventDetails in colSF_EventDetailss)
                {
                    strXML += "<SF_EventDetails>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_EventDetails.Content) + "</content>";
                    strXML += "</SF_EventDetails>";
                }
                strXML += "</SF_EventDetailss>";
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
            XmlNode xmlSF_EventDetailss = Globals.GetContent(Content, "SF_EventDetailss");

            foreach (XmlNode xmlSF_EventDetails in xmlSF_EventDetailss.SelectNodes("SF_EventDetails"))
            {
                SF_EventDetailsInfo objSF_EventDetails = new SF_EventDetailsInfo();

                objSF_EventDetails.ModuleId = ModuleID;
                objSF_EventDetails.Content = xmlSF_EventDetails.SelectSingleNode("content").InnerText;
                objSF_EventDetails.CreatedByUser = UserId;
                AddSF_EventDetails(objSF_EventDetails);
            }

        }

        #endregion

    }
}

