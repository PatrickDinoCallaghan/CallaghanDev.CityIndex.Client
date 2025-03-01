using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response to a LogOn v2 call.
    /// </summary>
    public class ApiLogOnResponseDTO
    {
        /// <summary>
        /// Your session token (must be between 36 and 100 characters).
        /// Session tokens are valid for a set period from the time of their creation.
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Flag used to indicate whether a password change is needed.
        /// </summary>
        public bool PasswordChangeRequired { get; set; }

        /// <summary>
        /// Flag used to indicate whether the account operator associated with this user is allowed to access the application.
        /// </summary>
        public bool AllowedAccountOperator { get; set; }

        /// <summary>
        /// Contains the logon status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Returns a flag if Two Factor Authentication is enabled.
        /// </summary>
        public bool Is2FAEnabled { get; set; }

        /// <summary>
        /// Two Factor Authentication token (nullable).
        /// </summary>
        public string TwoFAToken { get; set; }

        /// <summary>
        /// Additional Two Factor Authentication methods.
        /// </summary>
        public Api2FALogonOnResponseDTO[] Additional2FAMethods { get; set; }
    }


    /// <summary>
    /// Information about Two Factor Authentication (2FA) methods.
    /// </summary>
    public class Api2FALogonOnResponseDTO
    {
        /// <summary>
        /// The contact identifier.
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// The contact category identifier.
        /// </summary>
        public int ContactCategoryId { get; set; }

        /// <summary>
        /// The value for the 2FA method (nullable).
        /// </summary>
        public string Value { get; set; }
    }
}
