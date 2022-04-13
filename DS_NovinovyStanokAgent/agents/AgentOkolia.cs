using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="2"
	public class AgentOkolia : Agent
	{
		public PlanovacPrichodovZakaznikov ArrivalAsistent { get; private set; }

		public AgentOkolia(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
			ArrivalAsistent = new PlanovacPrichodovZakaznikov(Id, MySim, this);
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();

			MyManager.PrepareReplication();
			ArrivalAsistent.PrepareReplication();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerOkolia(SimId.ManagerOkolia, MySim, this);
			new PlanovacPrichodovZakaznikov(SimId.PlanovacPrichodovZakaznikov, MySim, this);
			AddOwnMessage(Mc.OdchodZakaznika);
		}
		//meta! tag="end"
	}
}
