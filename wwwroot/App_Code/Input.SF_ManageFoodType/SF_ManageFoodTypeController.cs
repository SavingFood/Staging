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

namespace Input.Modules.SF_ManageFoodType
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageFoodType
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageFoodTypeController : IPortable
    {

        #region Constructors

        public SF_ManageFoodTypeController()
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
        /// <param name="objSF_ManageFoodType">The SF_ManageFoodTypeInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageFoodType(SF_ManageFoodTypeInfo objSF_ManageFoodType)
        {
            if (objSF_ManageFoodType.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageFoodType(objSF_ManageFoodType.ModuleId, objSF_ManageFoodType.Content, objSF_ManageFoodType.CreatedByUser);
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
        public void DeleteSF_ManageFoodType(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageFoodType(ModuleId, ItemId);
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
        public SF_ManageFoodTypeInfo GetSF_ManageFoodType(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageFoodTypeInfo>(DataProvider.Instance().GetSF_ManageFoodType(ModuleId, ItemId));
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
        public List<SF_ManageFoodTypeInfo> GetSF_ManageFoodTypes(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageFoodTypeInfo>(DataProvider.Instance().GetSF_ManageFoodTypes(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageFoodType">The SF_ManageFoodTypeInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageFoodType(SF_ManageFoodTypeInfo objSF_ManageFoodType)
        {
            if (objSF_ManageFoodType.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageFoodType(objSF_ManageFoodType.ModuleId, objSF_ManageFoodType.ItemId, objSF_ManageFoodType.Content, objSF_ManageFoodType.CreatedByUser);
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
            List<SF_ManageFoodTypeInfo> colSF_ManageFoodTypes = GetSF_ManageFoodTypes(ModuleID);

            if (colSF_ManageFoodTypes.Count != 0)
            {
                strXML += "<SF_ManageFoodTypes>";
                foreach (SF_ManageFoodTypeInfo objSF_ManageFoodType in colSF_ManageFoodTypes)
                {
                    strXML += "<SF_ManageFoodType>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageFoodType.Content) + "</content>";
                    strXML += "</SF_ManageFoodType>";
                }
                strXML += "</SF_ManageFoodTypes>";
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
            XmlNode xmlSF_ManageFoodTypes = Globals.GetContent(Content, "SF_ManageFoodTypes");

            foreach (XmlNode xmlSF_ManageFoodType in xmlSF_ManageFoodTypes.SelectNodes("SF_ManageFoodType"))
            {
                SF_ManageFoodTypeInfo objSF_ManageFoodType = new SF_ManageFoodTypeInfo();

                objSF_ManageFoodType.ModuleId = ModuleID;
                objSF_ManageFoodType.Content = xmlSF_ManageFoodType.SelectSingleNode("content").InnerText;
                objSF_ManageFoodType.CreatedByUser = UserId;
                AddSF_ManageFoodType(objSF_ManageFoodType);
            }

        }

        #endregion

    }
}

