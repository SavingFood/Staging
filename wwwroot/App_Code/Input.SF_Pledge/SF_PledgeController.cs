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

namespace Input.Modules.SF_Pledge
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_Pledge
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_PledgeController : ISearchable, IPortable
    {

        #region Constructors

        public SF_PledgeController()
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
        /// <param name="objSF_Pledge">The SF_PledgeInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_Pledge(SF_PledgeInfo objSF_Pledge)
        {
            if (objSF_Pledge.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_Pledge(objSF_Pledge.ModuleId, objSF_Pledge.Content, objSF_Pledge.CreatedByUser);
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
        public void DeleteSF_Pledge(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_Pledge(ModuleId, ItemId);
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
        public SF_PledgeInfo GetSF_Pledge(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_PledgeInfo>(DataProvider.Instance().GetSF_Pledge(ModuleId, ItemId));
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
        public List<SF_PledgeInfo> GetSF_Pledges(int ModuleId)
        {
            return CBO.FillCollection<SF_PledgeInfo>(DataProvider.Instance().GetSF_Pledges(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_Pledge">The SF_PledgeInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_Pledge(SF_PledgeInfo objSF_Pledge)
        {
            if (objSF_Pledge.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_Pledge(objSF_Pledge.ModuleId, objSF_Pledge.ItemId, objSF_Pledge.Content, objSF_Pledge.CreatedByUser);
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
            List<SF_PledgeInfo> colSF_Pledges = GetSF_Pledges(ModInfo.ModuleID);

            foreach (SF_PledgeInfo objSF_Pledge in colSF_Pledges)
            {
                if (objSF_Pledge != null)
                {
                    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSF_Pledge.Content, objSF_Pledge.CreatedByUser, objSF_Pledge.CreatedDate, ModInfo.ModuleID, objSF_Pledge.ItemId.ToString(), objSF_Pledge.Content, "ItemId=" + objSF_Pledge.ItemId.ToString());
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
            List<SF_PledgeInfo> colSF_Pledges = GetSF_Pledges(ModuleID);

            if (colSF_Pledges.Count != 0)
            {
                strXML += "<SF_Pledges>";
                foreach (SF_PledgeInfo objSF_Pledge in colSF_Pledges)
                {
                    strXML += "<SF_Pledge>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_Pledge.Content) + "</content>";
                    strXML += "</SF_Pledge>";
                }
                strXML += "</SF_Pledges>";
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
            XmlNode xmlSF_Pledges = Globals.GetContent(Content, "SF_Pledges");

            foreach (XmlNode xmlSF_Pledge in xmlSF_Pledges.SelectNodes("SF_Pledge"))
            {
                SF_PledgeInfo objSF_Pledge = new SF_PledgeInfo();

                objSF_Pledge.ModuleId = ModuleID;
                objSF_Pledge.Content = xmlSF_Pledge.SelectSingleNode("content").InnerText;
                objSF_Pledge.CreatedByUser = UserId;
                AddSF_Pledge(objSF_Pledge);
            }

        }

        #endregion

    }
}

