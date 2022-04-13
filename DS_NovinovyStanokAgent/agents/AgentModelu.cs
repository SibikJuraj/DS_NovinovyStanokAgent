using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="1"
	public class AgentModelu : Agent
	{
		public AgentModelu(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();

		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerModelu(SimId.ManagerModelu, MySim, this);
			AddOwnMessage(Mc.PrichodZakaznika);
			AddOwnMessage(Mc.ObsluhaZakaznika);
		}
		//meta! tag="end"
	}
}
