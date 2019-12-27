using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFPractice.Unsorted
{   
    public class MultiwayMatch
    {
        public MultiwayMatch()
        {
            var ADPList = new List<ADPData> { new ADPData("1", 2), new ADPData("1", 3), new ADPData("1", 4), new ADPData("2", 3), new ADPData("2", 4), new ADPData("3", 5), new ADPData("3", 6) };

            var DTCList = new List<ADPData> { new ADPData("1", 5), new ADPData("1", 4), new ADPData("2", 3), new ADPData("2", 3), new ADPData("2", 1), new ADPData("3", 11) };
            
            var GrpADPList = ADPList.GroupBy(x => x.Ctpy);
            var GrpDTCList = DTCList.GroupBy(x => x.Ctpy);

            foreach (var GrpADP in GrpADPList)
            {
                foreach (var GrpDTC in GrpDTCList)
                {
                    if (GrpADP.Key == GrpDTC.Key)
                    {
                        if (GrpADP.Sum(x => x.Amt) == GrpDTC.Sum(x => x.Amt))
                        {
                            foreach (var ADP in GrpADP)
                            {
                                ADP.MatchAmt = GrpADP.Sum(x => x.Amt);
                            }

                            foreach (var DTC in GrpDTC)
                            {
                                DTC.MatchAmt = GrpDTC.Sum(x => x.Amt);
                            }

                        }

                        //Console.WriteLine(GrpADP.Key);
                        //Console.WriteLine("--" + GrpADP.Sum(x => x.Amt));
                        //Console.WriteLine("--" + GrpDTC.Sum(x => x.Amt)); 
                    }
                }
            }

            foreach (var G in ADPList)
            {
                Console.WriteLine(G.Ctpy + " " + G.Amt + " " + G.MatchAmt);
            }

            /*
            foreach (var A in GrpADPList)
            {
                Console.WriteLine(A.Key);
                Console.WriteLine(A.Sum(x => x.Amt));                
            }
            */
        }
    }

    public class ADPData
    {
        public string Ctpy { get; set; }
        public int Amt { get; set; }
        public int MatchAmt { get; set; }

        public ADPData(string C, int A) { this.Ctpy = C; this.Amt = A; }
    }
}