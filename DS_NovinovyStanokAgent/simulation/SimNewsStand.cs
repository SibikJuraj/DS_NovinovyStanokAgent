using OSPABA;
using agents;
using System;

namespace simulation
{
	public class SimNewsStand : Simulation
	{
		private OSPStat.Stat _averageWaitingTimeOverall;
		private OSPStat.Stat _averageQueueLengthOverall;
		public OSPStat.Stat AverageWaitingTime { get; private set; }
		public OSPStat.WStat AverageQueueLength { get; private set; }
		public SimNewsStand()
		{
			Init();
			_averageWaitingTimeOverall = new OSPStat.Stat();
			_averageQueueLengthOverall = new OSPStat.Stat();
		}

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis
			Console.Clear();
			Console.WriteLine("Simulating...");
		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
			// Reset entities, queues, local statistics, etc...
			AverageWaitingTime = new OSPStat.Stat();
			AverageQueueLength = new OSPStat.WStat(this);

			Sprava message = new Sprava(this);
			message.Addressee = AgentOkolia;
			message.Code = Mc.Start;

			AgentOkolia.MyManager.ProcessMessage(message);
		}

		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();

			_averageWaitingTimeOverall.AddSample(AverageWaitingTime.Mean());
			_averageQueueLengthOverall.AddSample(AverageQueueLength.Mean());

			if (CurrentReplication / ReplicationCount % 0.01 == 0)
            {
				Console.WriteLine($"Current replication: {CurrentReplication}");
				Console.WriteLine($"	Avg Waiting time: {_averageWaitingTimeOverall.Mean()}");
				Console.WriteLine($"	Avg Queue length: {_averageQueueLengthOverall.Mean()}");
			}
		}

		override protected void SimulationFinished()
		{
			// Dysplay simulation results
			base.SimulationFinished();

			Console.WriteLine($"{_averageWaitingTimeOverall.Mean()}");
			Console.WriteLine($"{_averageQueueLengthOverall.Mean()}");
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
