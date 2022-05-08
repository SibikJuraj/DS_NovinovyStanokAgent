using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="23"
	public class Agent2 : Agent
	{
		public Agent2(int id, Simulation mySim, Agent parent) :
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
			new Manager2(SimId.Manager2, MySim, this);
			AddOwnMessage(Mc.Notice);
		}
		//meta! tag="end"
	}
}