using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
	public class GrantTypes
	{
		public static IEnumerable<string> Implicit =>
			new[] { GrantType.Implicit.ToString() };

		public static IEnumerable<string> ImplicitAndClientCredentials =>
			new[] { GrantType.Implicit.ToString(), GrantType.ClientCredentials.ToString() };

		public static IEnumerable<string> Code =>
			new[] { GrantType.AuthCode.ToString() };

		public static IEnumerable<string> CodeAndClientCredentials =>
			new[] { GrantType.AuthCode.ToString(), GrantType.ClientCredentials.ToString() };

		public static IEnumerable<string> Hybrid =>
			new[] { GrantType.Hybrid.ToString() };

		public static IEnumerable<string> HybridAndClientCredentials =>
			new[] { GrantType.Hybrid.ToString(), GrantType.ClientCredentials.ToString() };

		public static IEnumerable<string> ClientCredentials =>
			new[] { GrantType.ClientCredentials.ToString() };

		public static IEnumerable<string> ResourceOwnerPassword =>
			new[] { GrantType.Password.ToString() };

		public static IEnumerable<string> ResourceOwnerPasswordAndClientCredentials =>
			new[] { GrantType.Password.ToString(), GrantType.ClientCredentials.ToString() };

		public static IEnumerable<string> List(params string[] values) => values;
	}
}