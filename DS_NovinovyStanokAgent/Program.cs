using simulation;
using System;

namespace DS_NovinovyStanokAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MySimulation().Simulate(100, 10_000_000);
        }
    }
}
