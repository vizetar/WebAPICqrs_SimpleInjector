using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Events
{
	public class PostCommitEvent : IPostCommitEvent
	{
		public event Action PostCommit = () => { };

		public void Raise()
		{
			PostCommit();
		}

		public void Reset()
		{
			PostCommit = () => { };
		}
	}
}
