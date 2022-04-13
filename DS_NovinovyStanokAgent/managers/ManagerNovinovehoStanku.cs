using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;

namespace managers
{
	//meta! id="3"
	public class ManagerNovinovehoStanku : Manager
	{
		private Queue<Sprava> queueCustomers_;
		private bool occupied_;

		public ManagerNovinovehoStanku(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
			queueCustomers_ = new Queue<Sprava>();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			occupied_ = false;
			queueCustomers_.Clear();

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="AgentModelu", id="10", type="Request"
		public void ProcessObsluhaZakaznika(MessageForm message)
		{

		}

		//meta! sender="ProcesObsluhyZakaznika", id="17", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.ObsluhaZakaznika:
				ProcessObsluhaZakaznika(message);
			break;

			case Mc.Finish:
				ProcessFinish(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentNovinovehoStanku MyAgent
		{
			get
			{
				return (AgentNovinovehoStanku)base.MyAgent;
			}
		}
	}
}
