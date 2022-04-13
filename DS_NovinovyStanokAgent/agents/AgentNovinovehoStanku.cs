using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="3"
	public class AgentNovinovehoStanku : Agent
	{
		public AgentNovinovehoStanku(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerNovinovehoStanku(SimId.ManagerNovinovehoStanku, MySim, this);
			new ProcesObsluhyZakaznika(SimId.ProcesObsluhyZakaznika, MySim, this);
			AddOwnMessage(Mc.ObsluhaZakaznika);
		}
		//meta! tag="end"
	}
}
