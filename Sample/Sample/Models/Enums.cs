using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
	public enum GrantType
	{
		Implicit,
		Hybrid,
		AuthCode,
		ClientCredentials,
		Password
	}

	public enum AccessTokenType
	{
		/// <summary>
		/// Self-contained Json Web Token
		/// </summary>
		Jwt = 0,

		/// <summary>
		/// Reference token
		/// </summary>
		Reference = 1
	}

	public enum TokenUsage
	{
		/// <summary>
		/// Re-use the refresh token handle
		/// </summary>
		ReUse = 0,

		/// <summary>
		/// Issue a new refresh token handle every time
		/// </summary>
		OneTimeOnly = 1
	}

	/// <summary>
	/// Token expiration types.
	/// </summary>
	public enum TokenExpiration
	{
		/// <summary>
		/// Sliding token expiration
		/// </summary>
		Sliding = 0,

		/// <summary>
		/// Absolute token expiration
		/// </summary>
		Absolute = 1
	}
}