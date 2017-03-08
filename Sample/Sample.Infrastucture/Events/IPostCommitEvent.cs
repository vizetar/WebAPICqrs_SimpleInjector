using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Events
{
	public interface IPostCommitEvent
	{
		event Action PostCommit;
	}
}
