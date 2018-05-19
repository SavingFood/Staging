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

namespace Input.Modules.SF_VolunteerCommitments
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_VolunteerCommitments
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_VolunteerCommitmentsController : IPortable
    {

        #region Constructors

        public SF_VolunteerCommitmentsController()
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
        /// <param name="objSF_VolunteerCommitments">The SF_VolunteerCommitmentsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_VolunteerCommitments(SF_VolunteerCommitmentsInfo objSF_VolunteerCommitments)
        {
            if (objSF_VolunteerCommitments.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_VolunteerCommitments(objSF_VolunteerCommitments.ModuleId, objSF_VolunteerCommitments.Content, objSF_VolunteerCommitments.CreatedByUser);
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
        public void DeleteSF_VolunteerCommitments(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_VolunteerCommitments(ModuleId, ItemId);
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
        public SF_VolunteerCommitmentsInfo GetSF_VolunteerCommitments(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_VolunteerCommitmentsInfo>(DataProvider.Instance().GetSF_VolunteerCommitments(ModuleId, ItemId));
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
        public List<SF_VolunteerCommitmentsInfo> GetSF_VolunteerCommitmentss(int ModuleId)
        {
            return CBO.FillCollection<SF_VolunteerCommitmentsInfo>(DataProvider.Instance().GetSF_VolunteerCommitmentss(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_VolunteerCommitments">The SF_VolunteerCommitmentsInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_VolunteerCommitments(SF_VolunteerCommitmentsInfo objSF_VolunteerCommitments)
        {
            if (objSF_VolunteerCommitments.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_VolunteerCommitments(objSF_VolunteerCommitments.ModuleId, objSF_VolunteerCommitments.ItemId, objSF_VolunteerCommitments.Content, objSF_VolunteerCommitments.CreatedByUser);
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
            List<SF_VolunteerCommitmentsInfo> colSF_VolunteerCommitmentss = GetSF_VolunteerCommitmentss(ModuleID);

            if (colSF_VolunteerCommitmentss.Count != 0)
            {
                strXML += "<SF_VolunteerCommitmentss>";
                foreach (SF_VolunteerCommitmentsInfo objSF_VolunteerCommitments in colSF_VolunteerCommitmentss)
                {
                    strXML += "<SF_VolunteerCommitments>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_VolunteerCommitments.Content) + "</content>";
                    strXML += "</SF_VolunteerCommitments>";
                }
                strXML += "</SF_VolunteerCommitmentss>";
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
            XmlNode xmlSF_VolunteerCommitmentss = Globals.GetContent(Content, "SF_VolunteerCommitmentss");

            foreach (XmlNode xmlSF_VolunteerCommitments in xmlSF_VolunteerCommitmentss.SelectNodes("SF_VolunteerCommitments"))
            {
                SF_VolunteerCommitmentsInfo objSF_VolunteerCommitments = new SF_VolunteerCommitmentsInfo();

                objSF_VolunteerCommitments.ModuleId = ModuleID;
                objSF_VolunteerCommitments.Content = xmlSF_VolunteerCommitments.SelectSingleNode("content").InnerText;
                objSF_VolunteerCommitments.CreatedByUser = UserId;
                AddSF_VolunteerCommitments(objSF_VolunteerCommitments);
            }

        }

        #endregion

    }
}

