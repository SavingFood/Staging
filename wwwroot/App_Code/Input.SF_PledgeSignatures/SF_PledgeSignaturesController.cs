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

namespace Input.Modules.SF_PledgeSignatures
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_PledgeSignatures
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_PledgeSignaturesController : ISearchable, IPortable
    {

        #region Constructors

        public SF_PledgeSignaturesController()
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
        /// <param name="objSF_PledgeSignatures">The SF_PledgeSignaturesInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_PledgeSignatures(SF_PledgeSignaturesInfo objSF_PledgeSignatures)
        {
            if (objSF_PledgeSignatures.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_PledgeSignatures(objSF_PledgeSignatures.ModuleId, objSF_PledgeSignatures.Content, objSF_PledgeSignatures.CreatedByUser);
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
        public void DeleteSF_PledgeSignatures(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_PledgeSignatures(ModuleId, ItemId);
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
        public SF_PledgeSignaturesInfo GetSF_PledgeSignatures(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_PledgeSignaturesInfo>(DataProvider.Instance().GetSF_PledgeSignatures(ModuleId, ItemId));
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
        public List<SF_PledgeSignaturesInfo> GetSF_PledgeSignaturess(int ModuleId)
        {
            return CBO.FillCollection<SF_PledgeSignaturesInfo>(DataProvider.Instance().GetSF_PledgeSignaturess(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_PledgeSignatures">The SF_PledgeSignaturesInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_PledgeSignatures(SF_PledgeSignaturesInfo objSF_PledgeSignatures)
        {
            if (objSF_PledgeSignatures.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_PledgeSignatures(objSF_PledgeSignatures.ModuleId, objSF_PledgeSignatures.ItemId, objSF_PledgeSignatures.Content, objSF_PledgeSignatures.CreatedByUser);
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
            List<SF_PledgeSignaturesInfo> colSF_PledgeSignaturess = GetSF_PledgeSignaturess(ModInfo.ModuleID);

            foreach (SF_PledgeSignaturesInfo objSF_PledgeSignatures in colSF_PledgeSignaturess)
            {
                if (objSF_PledgeSignatures != null)
                {
                    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSF_PledgeSignatures.Content, objSF_PledgeSignatures.CreatedByUser, objSF_PledgeSignatures.CreatedDate, ModInfo.ModuleID, objSF_PledgeSignatures.ItemId.ToString(), objSF_PledgeSignatures.Content, "ItemId=" + objSF_PledgeSignatures.ItemId.ToString());
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
            List<SF_PledgeSignaturesInfo> colSF_PledgeSignaturess = GetSF_PledgeSignaturess(ModuleID);

            if (colSF_PledgeSignaturess.Count != 0)
            {
                strXML += "<SF_PledgeSignaturess>";
                foreach (SF_PledgeSignaturesInfo objSF_PledgeSignatures in colSF_PledgeSignaturess)
                {
                    strXML += "<SF_PledgeSignatures>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_PledgeSignatures.Content) + "</content>";
                    strXML += "</SF_PledgeSignatures>";
                }
                strXML += "</SF_PledgeSignaturess>";
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
            XmlNode xmlSF_PledgeSignaturess = Globals.GetContent(Content, "SF_PledgeSignaturess");

            foreach (XmlNode xmlSF_PledgeSignatures in xmlSF_PledgeSignaturess.SelectNodes("SF_PledgeSignatures"))
            {
                SF_PledgeSignaturesInfo objSF_PledgeSignatures = new SF_PledgeSignaturesInfo();

                objSF_PledgeSignatures.ModuleId = ModuleID;
                objSF_PledgeSignatures.Content = xmlSF_PledgeSignatures.SelectSingleNode("content").InnerText;
                objSF_PledgeSignatures.CreatedByUser = UserId;
                AddSF_PledgeSignatures(objSF_PledgeSignatures);
            }

        }

        #endregion

    }
}

