using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="20"
	public class Agent1 : Agent
	{
		public Agent1(int id, Simulation mySim, Agent parent) :
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
			new Manager1(SimId.Manager1, MySim, this);
			new Process1(SimId.Process1, MySim, this);
		}
		//meta! tag="end"
	}
}