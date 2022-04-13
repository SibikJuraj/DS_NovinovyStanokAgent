using OSPABA;
using agents;
namespace simulation
{
	public class SimNewsStand : Simulation
	{
		public SimNewsStand()
		{
			Init();
		}

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis
		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
			// Reset entities, queues, local statistics, etc...
			AgentModelu.PrepareReplication();
			AgentOkolia.PrepareReplication();
			AgentNovinovehoStanku.PrepareReplication();
		}

		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();
		}

		override protected void SimulationFinished()
		{
			// Dysplay simulation results
			base.SimulationFinished();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			AgentModelu = new AgentModelu(SimId.AgentModelu, this, null);
			AgentOkolia = new AgentOkolia(SimId.AgentOkolia, this, AgentModelu);
			AgentNovinovehoStanku = new AgentNovinovehoStanku(SimId.AgentNovinovehoStanku, this, AgentModelu);
		}
		public AgentModelu AgentModelu
		{ get; set; }
		public AgentOkolia AgentOkolia
		{ get; set; }
		public AgentNovinovehoStanku AgentNovinovehoStanku
		{ get; set; }
		//meta! tag="end"
	}
}
