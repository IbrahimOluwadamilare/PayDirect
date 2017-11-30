
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Specialized;
using Microsoft.MetadirectoryServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net;
using System.Data;
using System.Json;

namespace FimSync_Ezma
{
    public class EzmaExtension :
    IMAExtensible2CallExport,
    //IMAExtensible2CallImport,
    //IMAExtensible2FileImport,
    //IMAExtensible2FileExport,
    //IMAExtensible2GetHierarchy,
    IMAExtensible2GetSchema,
    IMAExtensible2GetCapabilities,
    IMAExtensible2GetParameters
    //IMAExtensible2GetPartitions
    {
        private int m_importDefaultPageSize = 1200;
        private int m_importMaxPageSize = 1500;
        private int m_exportDefaultPageSize = 10;
        private int m_exportMaxPageSize = 20;

        public string username;
        public string title;
        public string email;
        public string firstName;
        public string lastName;
        public string mobileNo;
        public string verifiedMobileNo;
        public string passportId;
        public string emailVerified;
        public string mobileNoVerified;
        public string userStore;
        public string password;
        public string confirmPassword;
        public string oldPassword;

        public string webServicePassword;
        public string webServiceUsername;
        public string imUrl;
        public string exUrl;
        public string enableLogging;
        public string loggingLevel;
        //
        // Constructor
        //
        public EzmaExtension()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public MACapabilities Capabilities
        {
            get
            {
                MACapabilities myCapabilities = new MACapabilities();

                myCapabilities.ConcurrentOperation = true;
                myCapabilities.ObjectRename = false;
                myCapabilities.DeleteAddAsReplace = true;
                myCapabilities.DeltaImport = true;
                myCapabilities.DistinguishedNameStyle = MADistinguishedNameStyle.None;
                myCapabilities.ExportType = MAExportType.AttributeUpdate;
                myCapabilities.NoReferenceValuesInFirstExport = false;
                myCapabilities.Normalizations = MANormalizations.None;

                return myCapabilities;
            }
        }

        public int ImportDefaultPageSize
        {
            get
            {
                return m_importDefaultPageSize;
            }
        }

        public int ImportMaxPageSize
        {
            get
            {
                return m_importMaxPageSize;
            }
        }

        public int ExportDefaultPageSize
        {
            get
            {
                return m_exportDefaultPageSize;
            }

            set
            {
                m_exportDefaultPageSize = value;
            }
        }

        public int ExportMaxPageSize
        {
            get
            {
                return m_exportMaxPageSize;
            }
            set
            {
                m_exportMaxPageSize = value;
            }
        }

        public IList<ConfigParameterDefinition> GetConfigParameters(KeyedCollection<string, ConfigParameter> configParameters, ConfigParameterPage page)
        {
            List<ConfigParameterDefinition> configParametersDefinitions = new List<ConfigParameterDefinition>();
            switch (page)
            {
                case ConfigParameterPage.Connectivity:
                    //configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("imUrl", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("exUrl", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("webServiceUsername", ""));
                    configParametersDefinitions.Add(ConfigParameterDefinition.CreateStringParameter("webServicePassword", ""));
                    break;
                    //case ConfigParameterPage.Global:
                    //    break;
                    //case ConfigParameterPage.Partition:
                    //    break;
                    //case ConfigParameterPage.RunStep:
                    //    break;
            }
            return configParametersDefinitions;
        }

        public CloseImportConnectionResults CloseImportConnection(CloseImportConnectionRunStep importRunStep)
        {
            return new CloseImportConnectionResults();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="importRunStep"></param>
        /// <returns></returns>

        public Schema GetSchema(KeyedCollection<string, ConfigParameter> configParameters)
        {
            Microsoft.MetadirectoryServices.SchemaType personType = Microsoft.MetadirectoryServices.SchemaType.Create("Person", false);

            //myname = configParameters["myname"].Value;

            string myattribute1 = "title";
            string myattribute2 = "username";
            string myattribute3 = "email";
            string myattribute4 = "firstName";
            string myattribute5 = "lastName";
            string myattribute6 = "mobileNo";
            string myattribute7 = "verifiedMobileNo";
            string myattribute8 = "passportId";
            string myattribute9 = "emailVerified";
            string myattribute10 = "mobileNoVerified";
            string myattribute11 = "userStore";
            string myattribute12 = "password";
            string myattribute13 = "confirmPassword";
            string myattribute14 = "oldPassword";

            if (myattribute1 == "title")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute1, AttributeType.String));
            }

            if (myattribute2 == "username")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute2, AttributeType.String));
            }

            if (myattribute3 == "email")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute3, AttributeType.String));
            }

            if (myattribute4 == "firstName")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute4, AttributeType.String));
            }

            if (myattribute5 == "lastName")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute5, AttributeType.String));
            }

            if (myattribute6 == "mobileNo")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute6, AttributeType.String));
            }

            if (myattribute7 == "verifiedMobileNo")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute7, AttributeType.String));
            }

            if (myattribute8 == "passportId")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute8, AttributeType.String));
            }

            if (myattribute9 == "emailVerified")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute9, AttributeType.String));
            }

            if (myattribute10 == "mobileNoVerified")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute10, AttributeType.String));
            }

            if (myattribute11 == "userStore")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute11, AttributeType.String));
            }

            if (myattribute12 == "password")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute12, AttributeType.String));
            }

            if (myattribute13 == "confirmPassword")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute13, AttributeType.String));
            }

            if (myattribute14 == "oldPassword")
            {
                personType.Attributes.Add(SchemaAttribute.CreateAnchorAttribute(myattribute14, AttributeType.String));
            }

            Schema schema = Schema.Create();
            schema.Types.Add(personType);

            return schema;
        }

        public OpenImportConnectionResults OpenImportConnection(KeyedCollection<string, ConfigParameter> configParameters, Schema types, OpenImportConnectionRunStep importRunStep)
        {
            this.imUrl = configParameters["imUrl"].Value;
            this.webServiceUsername = configParameters["webServiceUsername"].Value;
            this.webServicePassword = configParameters["webServicePassword"].Value;
            this.enableLogging = configParameters["enableLogging"].Value;
            this.loggingLevel = configParameters["loggingLevel"].Value;
            return new OpenImportConnectionResults();
        }



        //Export Region
        public void OpenExportConnection(KeyedCollection<string, ConfigParameter> configParameters, Schema types, OpenExportConnectionRunStep exportRunStep)
        {
            this.exUrl = configParameters["exUrl"].Value;
            this.webServiceUsername = configParameters["webServiceUsername"].Value;
            this.webServicePassword = configParameters["webServicePassword"].Value;
        }


        public ParameterValidationResult ValidateConfigParameters(KeyedCollection<string, ConfigParameter> configParameters, ConfigParameterPage page)
        {
            ParameterValidationResult myResults = new ParameterValidationResult();
            return myResults;
        }

        public PutExportEntriesResults PutExportEntries(IList<CSEntryChange> csentries)
        {
            string exportwebservicepath;
            int i = 0;
            foreach (CSEntryChange csentryChange in csentries)
            {
                email = csentries[i].DN.ToString();
                if (csentryChange.ObjectType == "Person")
                {
                    #region Add
                    if (csentryChange.ObjectModificationType == ObjectModificationType.Add)
                    {
                        #region a
                        foreach (string attrib in csentryChange.ChangedAttributeNames)
                        {
                            switch (attrib)
                            {
                                case "title":
                                    title = csentryChange.AttributeChanges["title"].ValueChanges[0].Value.ToString();
                                    break;
                                case "username":
                                    username = csentryChange.AttributeChanges["username"].ValueChanges[0].Value.ToString();
                                    break;
                                case "email":
                                    email = csentryChange.AttributeChanges["email"].ValueChanges[0].Value.ToString();
                                    break;

                                case "firstName":
                                    firstName = csentryChange.AttributeChanges["firstName"].ValueChanges[0].Value.ToString();
                                    break;

                                case "lastName":
                                    lastName = csentryChange.AttributeChanges["lastName"].ValueChanges[0].Value.ToString();
                                    break;

                                case "mobileNo":
                                    mobileNo = csentryChange.AttributeChanges["mobileNo"].ValueChanges[0].Value.ToString();
                                    break;

                                case "verifiedMobileNo":
                                    verifiedMobileNo = csentryChange.AttributeChanges["verifiedMobileNo"].ValueChanges[0].Value.ToString();
                                    break;

                                case "passportId":
                                    passportId = csentryChange.AttributeChanges["passportId"].ValueChanges[0].Value.ToString();
                                    break;

                                case "emailVerified":
                                    emailVerified = csentryChange.AttributeChanges["emailVerified"].ValueChanges[0].Value.ToString();
                                    break;

                                case "mobileNoVerified":
                                    mobileNoVerified = csentryChange.AttributeChanges["mobileNoVerified"].ValueChanges[0].Value.ToString();
                                    break;

                                case "userStore":
                                    userStore = csentryChange.AttributeChanges["userStore"].ValueChanges[0].Value.ToString();
                                    break;

                                case "password":
                                    password = csentryChange.AttributeChanges["password"].ValueChanges[0].Value.ToString();
                                    break;

                                case "ConfirmPassword":
                                    password = csentryChange.AttributeChanges["confirmPassword"].ValueChanges[0].Value.ToString();
                                    break;

                                case "oldPassword":
                                    password = csentryChange.AttributeChanges["oldPassword"].ValueChanges[0].Value.ToString();
                                    break;
                            }
                        }
                        #endregion

                        //call the webservice to update
                        exportwebservicepath = this.exUrl;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(exportwebservicepath);
                        request.ContentType = "application/json";
                        request.Method = "POST";
                       // request.Headers["Authorization"] = "Bearer" +;

                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            string json = "{ \"email\":" + email + ", \"firstName\": " + firstName + ", \"lastName\": " + lastName + ", \"password\": " + password + "}";
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }

                    }

                    #endregion
                    #region Delete
                    //if (csentryChange.ObjectModificationType == ObjectModificationType.Delete)
                    //{

                    //    //call the webservice to update
                    //    exportwebservicepath = this.exUrl; //+ "?employeeid=" + myEmpID + "&email=" + attribValue + "&accountName=" + attribValue2;
                    //    HttpWebRequest request = WebRequest.Create(exportwebservicepath) as HttpWebRequest;
                    //    HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                    //}
                    #endregion
                    #region Update
                    if (csentryChange.ObjectModificationType == ObjectModificationType.Update)
                    {
                        foreach (string attribName in csentryChange.ChangedAttributeNames)
                        {
                            
                            if (csentryChange.AttributeChanges[attribName].ModificationType == AttributeModificationType.Update)
                            {
                                email = csentryChange.AnchorAttributes[0].Value.ToString();
                                exportwebservicepath = this.exUrl + "change-passsword";
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(exportwebservicepath);
                                request.ContentType = "application/json";
                                request.Method = "POST";

                                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                                {
                                    string json = "{ \"oldPassword\":" + oldPassword + ", \"password\": " + firstName + ", \"confirmPassword\": " + confirmPassword + "}";
                                    streamWriter.Write(json);
                                    streamWriter.Flush();
                                    streamWriter.Close();
                                }
                                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                                using (var streamReader = new StreamReader(response.GetResponseStream()))
                                {
                                    var result = streamReader.ReadToEnd();
                                }

                            }

                        }

                    }

                    #endregion
                }

                i++;

            }

            PutExportEntriesResults exportEntriesResults = new PutExportEntriesResults();

            return exportEntriesResults;
        }


        public void CloseExportConnection(CloseExportConnectionRunStep exportRunStep)
        {
            //conn.Close();
        }

    };
}
