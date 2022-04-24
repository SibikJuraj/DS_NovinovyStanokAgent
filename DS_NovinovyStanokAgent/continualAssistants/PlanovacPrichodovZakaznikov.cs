using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	//meta! id="13"
	public class PlanovacPrichodovZakaznikov : Scheduler
	{
		private OSPRNG.ExponentialRNG _arrivalsGen;

		public PlanovacPrichodovZakaznikov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			_arrivalsGen = new OSPRNG.ExponentialRNG(240);
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="AgentOkolia", id="14", type="Start"
		public void ProcessStart(MessageForm message)
		{
			GenerateArrival(message);
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
				case Mc.PrichodZakaznika:
					Sprava sprava = message.CreateCopy() as Sprava;
					AssistantFinished(sprava);

					GenerateArrival(message);

					break;
			}
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Start:
				ProcessStart(message);
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

		private void GenerateArrival(MessageForm message)
        {
			var nextArrival = _arrivalsGen.Sample();
			message.Code = Mc.PrichodZakaznika;
			Hold(nextArrival, message);
		}
	}
}
