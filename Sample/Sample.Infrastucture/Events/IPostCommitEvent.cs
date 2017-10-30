using System;

namespace Sample.Infrastucture.Events
{
	public interface IPostCommitEvent
	{
		event Action PostCommit;
	}
}
