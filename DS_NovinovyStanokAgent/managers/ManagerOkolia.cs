using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="2"
	public class ManagerOkolia : Manager
	{

		public ManagerOkolia(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentModelu", id="8", type="Notice"
		public void ProcessOdchodZakaznika(MessageForm message)
		{
		}

		//meta! sender="PlanovacPrichodovZakaznikov", id="14", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
			message.Addressee = MyAgent.Parent;
			message.Code = Mc.PrichodZakaznika;
			Notice(message);
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
				case Mc.Start:
					message.Addressee = MyAgent.ArrivalAsistent;
					StartContinualAssistant(message);
					break;

				case Mc.PrichodZakaznika:
					message.Addressee = MyAgent.Parent;
					message.Code = Mc.PrichodZakaznika;
					Notice(message);
					break;
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
			case Mc.OdchodZakaznika:
				ProcessOdchodZakaznika(message);
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
		public new AgentOkolia MyAgent
		{
			get
			{
				return (AgentOkolia)base.MyAgent;
			}
		}
	}
}
