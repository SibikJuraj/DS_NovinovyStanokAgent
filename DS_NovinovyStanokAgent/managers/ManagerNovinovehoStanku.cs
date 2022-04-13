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
		private bool _occupied;
		private Queue<Sprava> _queueCustomers;

		public ManagerNovinovehoStanku(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
			_queueCustomers = new Queue<Sprava>();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			_occupied = false;
			_queueCustomers.Clear();

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="AgentModelu", id="10", type="Request"
		public void ProcessObsluhaZakaznika(MessageForm message)
		{
			if (!_occupied)
            {
				_occupied = true;
				message.Addressee = MyAgent.ServiceAsistent;
				StartContinualAssistant(message);
			}
			else
            {
				((Sprava)message).StartWaitingTime = MySim.CurrentTime;
				_queueCustomers.Enqueue((Sprava)message);

				((SimNewsStand)MySim).AverageQueueLength.AddSample(_queueCustomers.Count);
			}
		}

		//meta! sender="ProcesObsluhyZakaznika", id="17", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
			message.Code = Mc.ObsluhaZakaznika;
			Response(message);

			if (_queueCustomers.Count > 0)
            {
				message = _queueCustomers.Dequeue();
				((SimNewsStand)MySim).AverageWaitingTime.AddSample(MySim.CurrentTime - ((Sprava)message).StartWaitingTime);
				message.Addressee = MyAgent.ServiceAsistent;
				StartContinualAssistant(message);

				((SimNewsStand)MySim).AverageQueueLength.AddSample(_queueCustomers.Count);
			}
			else
            {
				_occupied = false;
			}
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