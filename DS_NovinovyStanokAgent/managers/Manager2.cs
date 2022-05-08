using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="23"
	public class Manager2 : Manager
	{
		public Manager2(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="Agent1", id="26", type="Notice"
		public void ProcessNotice(MessageForm message)
		{
		}

		//meta! sender="Scheduler1", id="35", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Finish:
				ProcessFinish(message);
			break;

			case Mc.Notice:
				ProcessNotice(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new Agent2 MyAgent
		{
			get
			{
				return (Agent2)base.MyAgent;
			}
		}
	}
}