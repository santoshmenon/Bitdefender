//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NickBuhro.Bitdefender.Models;

namespace NickBuhro.Bitdefender.Controllers
{
	
    /// <summary>
    /// The Companies API includes several methods allowing the management of company
    /// accounts:
    /// * createCompany : adds a new company.
    /// * deleteCompany : deletes a company.
    /// * updateCompanyDetails : updates company information, such as name or
    /// type.
    /// * getCompanyDetails : retrieves the details of a company.
    /// * getCompanyDetailsByUser : retrieves the details of the company linked to
    /// the specified user account.
    /// * findCompaniesByName : retrieves all managed companies containing the
    /// specified string in their name.
    /// * suspendCompany : disables access to Control Center for all user accounts of
    /// a company.
    /// * activateCompany : activates a previously suspended company.
    /// API url: CONTROL_CENTER_APIs_ACCESS_URL/v1.0/jsonrpc/companies
    /// </summary>	
    public sealed partial class CompaniesController : Controller
    {		
        public CompaniesController(HttpClient http)
            : base(http, "/v1.0/jsonrpc/companies") { }


        /// <summary>	
        /// This method creates a customer or partner company account.
        /// The license type for the created company is TRIAL. &apos;Licensing&apos; api can be used to
        /// change the license for the new company.
        /// </summary>
        /// <param name="type"> The company type. Available values: * 0 for Partner companies, * 1 for Customer companies. </param>
        /// <param name="name"> The company name. Must be unique. </param>
        /// <param name="parentId"> The ID of the parent partner company. </param>
        /// <param name="address"> The company&apos;s physical address. </param>
        /// <param name="phone"> The company&apos;s phone number. </param>
        /// <param name="canBeManagedByAbove"> An option defining if the security of the new company can be managed by its Partner company. Available values: true or false. The default value is true. </param>
        /// <param name="accountEmail"> The email for the new user account to be linked to the new company. If the parameter canBeManagedByAbove is set to false, the accountEmail parameter must be passed. </param>
        /// <param name="accountFullName"> The full name of the new user account to be linked to the new company. This parameter is required when canBeManagedByAbove is set to false. </param>
        /// <param name="accountTimezone"> The timezone of the new user account to be linked to the new company. The default value is GMT (UTC). </param>
        /// <param name="accountLanguage"> The user interface language for the new user account to be linked to the new company. The default value is en_US. </param>
        /// <returns>
        /// The ID of the newly-created company.
        /// </returns>
        public Task<string> CreateCompany (
            CompanyType type,
            string name,
            string parentId = null,
            string address = null,
            string phone = null,
            bool? canBeManagedByAbove = null,
            string accountEmail = null,
            string accountFullName = null,
            string accountTimezone = null,
            string accountLanguage = null,
            CancellationToken ct = default(CancellationToken))
        {

            if (name == null)
                throw new ArgumentNullException("name");

            var p = new JObject();
            p["type"] = (int)type;
            p["name"] = name;
            if (parentId != null)
                p["parentId"] = parentId;
            if (address != null)
                p["address"] = address;
            if (phone != null)
                p["phone"] = phone;
            if (canBeManagedByAbove != null)
                p["canBeManagedByAbove"] = canBeManagedByAbove.Value;
            if (accountEmail != null)
                p["accountEmail"] = accountEmail;
            if (accountFullName != null)
                p["accountFullName"] = accountFullName;
            if (accountTimezone != null)
                p["accountTimezone"] = accountTimezone;
            if (accountLanguage != null)
                p["accountLanguage"] = accountLanguage;
                        
            return Send<JObject, string>("createCompany", p, ct);
        }

        /// <summary>	
        /// This method deletes a company.
        /// </summary>
        /// <param name="companyId"> The ID of the company to be deleted </param>
        public Task DeleteCompany (
            string companyId,
            CancellationToken ct = default(CancellationToken))
        {

            if (companyId == null)
                throw new ArgumentNullException("companyId");

            var p = new JObject();
            p["companyId"] = companyId;
                        
            return Send<JObject, object>("deleteCompany", p, ct);
        }

        /// <summary>	
        /// This method updates the details of a partner or customer company.
        /// </summary>
        /// <param name="id"> The ID of the company to be updated. </param>
        /// <param name="type"> The company type. Available values: * 0 for Partner companies, * 1 for Customer companies. If not set, the company type will not be changed. </param>
        /// <param name="name"> The company&apos;s name. It must be unique. If not set, the company&apos;s name will not be changed. </param>
        /// <param name="address"> The company&apos;s address. If not set, the company&apos;s address will not be changed. </param>
        /// <param name="phone"> The company&apos;s phone number. If not set, the company&apos;s phone number will not be changed. </param>
        public Task UpdateCompanyDetails (
            string id,
            CompanyType? type = null,
            string name = null,
            string address = null,
            string phone = null,
            CancellationToken ct = default(CancellationToken))
        {

            if (id == null)
                throw new ArgumentNullException("id");

            var p = new JObject();
            p["id"] = id;
            if (type != null)
                p["type"] = (int)type.Value;
            if (name != null)
                p["name"] = name;
            if (address != null)
                p["address"] = address;
            if (phone != null)
                p["phone"] = phone;
                        
            return Send<JObject, object>("updateCompanyDetails", p, ct);
        }

        /// <summary>	
        /// This method retrieves the details of a company.
        /// </summary>
        /// <param name="companyId"> The company&apos;s ID. The default value is the ID of the company linked to the user who generated the API key. </param>
        /// <returns>
        /// This method returns an Object containing the details of the selected company:
        /// * type - the company type: 0 for Partner, 1 for Customer
        /// * name - the name of the company
        /// * id - the ID of the company
        /// * address - the address of the company
        /// * phone - the phone of the company
        /// * canBeManagedByAbove - the security management status for the company:
        /// true, if the security can be managed by parent companies
        /// * isSuspended - company account status: true, if the company is suspended
        /// </returns>
        public Task<CompanyDetails> GetCompanyDetails (
            string companyId = null,
            CancellationToken ct = default(CancellationToken))
        {

            var p = new JObject();
            if (companyId != null)
                p["companyId"] = companyId;
                        
            return Send<JObject, CompanyDetails>("getCompanyDetails", p, ct);
        }

        /// <summary>	
        /// This method retrieves the details of a company linked to an account identified
        /// through the given username and password.
        /// </summary>
        /// <param name="username"> The username linked to the referred company. </param>
        /// <param name="password"> The password linked to the referred company. </param>
        /// <returns>
        /// This method returns an Object containing the details of the searched company:
        /// * type - the company type: 0 for Partner, 1 for Customer
        /// * name - the name of the company
        /// * id - the ID of the company
        /// * address - the address of the company
        /// * phone - the phone of the company
        /// * canBeManagedByAbove - the security management status for the company:
        /// true, if the security can be managed by parent companies
        /// * isSuspended - company account status: true, if the company is suspended
        /// </returns>
        public Task<CompanyDetails> GetCompanyDetailsByUser (
            string username,
            string password,
            CancellationToken ct = default(CancellationToken))
        {

            if (username == null)
                throw new ArgumentNullException("username");

            if (password == null)
                throw new ArgumentNullException("password");

            var p = new JObject();
            p["username"] = username;
            p["password"] = password;
                        
            return Send<JObject, CompanyDetails>("getCompanyDetailsByUser", p, ct);
        }

        /// <summary>	
        /// This method searches for all managed companies containing the specified string
        /// in their name.
        /// </summary>
        /// <param name="nameFilter"> The string to be searched in the company name. Use the asterisk symbol (*) in front of the keyword to search its appearance anywhere in the name. If omitted, only results where the name starts with the keyword will be returned. </param>
        /// <returns>
        /// This method returns an Array containing company objects whose names contain
        /// the given search criteria. The size of the returned array is limited to 25 entries. Each
        /// entry in the array has the following structure:
        /// * type - the company type: 0 for Partner, 1 for Customer
        /// * name - the name of the company
        /// * id - the ID of the company
        /// * address - the address of the company
        /// * phone - the phone of the company
        /// * canBeManagedByAbove - the security management status for the company:
        /// true, if the security can be managed by parent companies
        /// * isSuspended - company account status: true, if the company is suspended
        /// </returns>
        public Task<CompanyDetails> FindCompaniesByName (
            string nameFilter,
            CancellationToken ct = default(CancellationToken))
        {

            if (nameFilter == null)
                throw new ArgumentNullException("nameFilter");

            var p = new JObject();
            p["nameFilter"] = nameFilter;
                        
            return Send<JObject, CompanyDetails>("findCompaniesByName", p, ct);
        }

        /// <summary>	
        /// This method suspends an active company account, with the following implications:
        /// * The company’s users will no longer be able to log in to GravityZone Control
        /// Center.
        /// * The agents on endpoints directly managed by the suspended company will
        /// expire.
        /// </summary>
        /// <param name="companyId"> The ID of the company to be suspended. </param>
        public Task SuspendCompany (
            string companyId,
            CancellationToken ct = default(CancellationToken))
        {

            if (companyId == null)
                throw new ArgumentNullException("companyId");

            var p = new JObject();
            p["companyId"] = companyId;
                        
            return Send<JObject, object>("suspendCompany", p, ct);
        }

        /// <summary>	
        /// This method activates a suspended company.
        /// </summary>
        /// <param name="companyId"> The ID of the company to be activated. </param>
        public Task ActivateCompany (
            string companyId,
            CancellationToken ct = default(CancellationToken))
        {

            if (companyId == null)
                throw new ArgumentNullException("companyId");

            var p = new JObject();
            p["companyId"] = companyId;
                        
            return Send<JObject, object>("activateCompany", p, ct);
        }
    }
}

