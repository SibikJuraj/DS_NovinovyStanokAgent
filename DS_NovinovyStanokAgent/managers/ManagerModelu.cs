using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="1"
	public class ManagerModelu : Manager
	{
		public ManagerModelu(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentOkolia", id="9", type="Notice"
		public void ProcessPrichodZakaznika(MessageForm message)
		{
			message.Addressee = MySim.FindAgent(SimId.AgentNovinovehoStanku);
			message.Code = Mc.ObsluhaZakaznika;
			(message as MyMessage).StartWaitingTime = MySim.CurrentTime;
			Request(message);
		}

		//meta! sender="AgentNovinovehoStanku", id="10", type="Response"
		public void ProcessObsluhaZakaznika(MessageForm message)
		{
			var sprava = new MyMessage(MySim);
			sprava.Addressee = MySim.FindAgent(SimId.AgentOkolia);
			sprava.Code = Mc.OdchodZakaznika;
			Notice(sprava);
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

			case Mc.PrichodZakaznika:
				ProcessPrichodZakaznika(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentModelu MyAgent
		{
			get
			{
				return (AgentModelu)base.MyAgent;
			}
		}
	}
}