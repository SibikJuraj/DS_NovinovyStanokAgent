using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	//meta! id="13"
	public class PlanovacPrichodovZakaznikov : Scheduler
	{
		private OSPRNG.ExponentialRNG ArrivalsGen { get; }

		public PlanovacPrichodovZakaznikov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			ArrivalsGen = new OSPRNG.ExponentialRNG((double)1 / (4 * 60));
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			GenerateArrival();
		}

		//meta! sender="AgentOkolia", id="14", type="Start"
		public void ProcessStart(MessageForm message)
		{
			GenerateArrival();
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
				case Mc.PrichodZakaznika:
					var sprava = new Sprava(MySim);
					sprava.Addressee = MyAgent;
					sprava.Code = Mc.PrichodZakaznika;
					Notice(sprava);

					GenerateArrival();

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

		private void GenerateArrival()
        {
			var nextArrival = ArrivalsGen.Sample();
			var sprava = new Sprava(MySim);
			sprava.Addressee = MySim.FindAgent(MyAgent.Id);
			sprava.Code = Mc.PrichodZakaznika;
			Hold(nextArrival, sprava);
		}
	}
}
