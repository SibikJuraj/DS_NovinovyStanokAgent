using simulation;
using System;

namespace DS_NovinovyStanokAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new SimNewsStand().Simulate(10, 10_000_000);
        }
    }
}
