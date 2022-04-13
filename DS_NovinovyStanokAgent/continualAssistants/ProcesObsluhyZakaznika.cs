using OSPABA;
using simulation;
using agents;
using managers;

namespace continualAssistants
{
	//meta! id="16"
	public class ProcesObsluhyZakaznika : Process
	{
		private OSPRNG.UniformContinuousRNG _serviceLengthGen;

		public ProcesObsluhyZakaznika(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			_serviceLengthGen = new OSPRNG.UniformContinuousRNG(120, 240);
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="AgentNovinovehoStanku", id="17", type="Start"
		public void ProcessStart(MessageForm message)
		{
			message.Code = Mc.Finish;
			Hold(_serviceLengthGen.Sample(), message);
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
				case Mc.Finish:
					AssistantFinished(message);

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
		public new AgentNovinovehoStanku MyAgent
		{
			get
			{
				return (AgentNovinovehoStanku)base.MyAgent;
			}
		}
	}
}
