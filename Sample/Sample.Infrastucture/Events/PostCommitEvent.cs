using System;

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
