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

namespace Input.Modules.SF_ManageFoodUnit
{
    /// -----------------------------------------------------------------------------
    ///<summary>
    /// The Controller class for the SF_ManageFoodUnit
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SF_ManageFoodUnitController : IPortable
    {

        #region Constructors

        public SF_ManageFoodUnitController()
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
        /// <param name="objSF_ManageFoodUnit">The SF_ManageFoodUnitInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSF_ManageFoodUnit(SF_ManageFoodUnitInfo objSF_ManageFoodUnit)
        {
            if (objSF_ManageFoodUnit.Content.Trim() != "")
            {
                DataProvider.Instance().AddSF_ManageFoodUnit(objSF_ManageFoodUnit.ModuleId, objSF_ManageFoodUnit.Content, objSF_ManageFoodUnit.CreatedByUser);
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
        public void DeleteSF_ManageFoodUnit(int ModuleId, int ItemId)
        {
            DataProvider.Instance().DeleteSF_ManageFoodUnit(ModuleId, ItemId);
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
        public SF_ManageFoodUnitInfo GetSF_ManageFoodUnit(int ModuleId, int ItemId)
        {
            return CBO.FillObject<SF_ManageFoodUnitInfo>(DataProvider.Instance().GetSF_ManageFoodUnit(ModuleId, ItemId));
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
        public List<SF_ManageFoodUnitInfo> GetSF_ManageFoodUnits(int ModuleId)
        {
            return CBO.FillCollection<SF_ManageFoodUnitInfo>(DataProvider.Instance().GetSF_ManageFoodUnits(ModuleId));
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves an object to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="objSF_ManageFoodUnit">The SF_ManageFoodUnitInfo object</param>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void UpdateSF_ManageFoodUnit(SF_ManageFoodUnitInfo objSF_ManageFoodUnit)
        {
            if (objSF_ManageFoodUnit.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateSF_ManageFoodUnit(objSF_ManageFoodUnit.ModuleId, objSF_ManageFoodUnit.ItemId, objSF_ManageFoodUnit.Content, objSF_ManageFoodUnit.CreatedByUser);
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
            List<SF_ManageFoodUnitInfo> colSF_ManageFoodUnits = GetSF_ManageFoodUnits(ModuleID);

            if (colSF_ManageFoodUnits.Count != 0)
            {
                strXML += "<SF_ManageFoodUnits>";
                foreach (SF_ManageFoodUnitInfo objSF_ManageFoodUnit in colSF_ManageFoodUnits)
                {
                    strXML += "<SF_ManageFoodUnit>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objSF_ManageFoodUnit.Content) + "</content>";
                    strXML += "</SF_ManageFoodUnit>";
                }
                strXML += "</SF_ManageFoodUnits>";
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
            XmlNode xmlSF_ManageFoodUnits = Globals.GetContent(Content, "SF_ManageFoodUnits");

            foreach (XmlNode xmlSF_ManageFoodUnit in xmlSF_ManageFoodUnits.SelectNodes("SF_ManageFoodUnit"))
            {
                SF_ManageFoodUnitInfo objSF_ManageFoodUnit = new SF_ManageFoodUnitInfo();

                objSF_ManageFoodUnit.ModuleId = ModuleID;
                objSF_ManageFoodUnit.Content = xmlSF_ManageFoodUnit.SelectSingleNode("content").InnerText;
                objSF_ManageFoodUnit.CreatedByUser = UserId;
                AddSF_ManageFoodUnit(objSF_ManageFoodUnit);
            }

        }

        #endregion

    }
}

