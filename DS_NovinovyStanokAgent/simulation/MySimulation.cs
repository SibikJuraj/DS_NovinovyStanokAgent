using OSPABA;
using agents;
using System;

namespace simulation
{
	public class MySimulation : Simulation
	{
		private OSPStat.Stat _averageWaitingTimeOverall;
		private OSPStat.Stat _averageQueueLengthOverall;
		public OSPStat.Stat AverageWaitingTime { get; private set; }
		public OSPStat.WStat AverageQueueLength { get; private set; }
		public MySimulation()
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

			MyMessage message = new MyMessage(this);
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

			if ( CurrentReplication % 10 == 0)
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
			Agent1 = new Agent1(SimId.Agent1, this, AgentModelu);
			Agent2 = new Agent2(SimId.Agent2, this, Agent1);
		}
		public AgentModelu AgentModelu
		{ get; set; }
		public AgentOkolia AgentOkolia
		{ get; set; }
		public AgentNovinovehoStanku AgentNovinovehoStanku
		{ get; set; }
		public Agent1 Agent1
		{ get; set; }
		public Agent2 Agent2
		{ get; set; }
		//meta! tag="end"
	}
}