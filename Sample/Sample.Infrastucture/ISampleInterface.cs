using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture
{
	public interface ISampleInterface
	{
		string GetSample();
	}

	public class SampleInterface : ISampleInterface
	{
		public string GetSample()
		{
			return "valu";
		}
	}

}
