using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZPaycheckScripter
{
    public class Paycheck
    {
        public string NameLastFirst { get; set; }
        public DateTime PayDate { get; set; }
        public decimal RateRegular { get; set; }
        public decimal RateOT { get; set; }
        public decimal RateOther { get; set; }
        public double HoursRegular { get; set; }
        public double HoursOT { get; set; }
        public double HoursOther { get; set; }
        public decimal EarningsRegular { get; set; }
        public decimal EarningsOT { get; set; }
        public decimal EarningsOther { get; set; }  // equals sick + bonus
        public decimal EarningsSick { get; set; }   // computed as other hours times other rate
        public decimal EarningsBonus { get; set; }  // computed as other - sick
        public decimal TaxFedIncome { get; set; }
        public decimal TaxStateIncome { get; set; }
        public decimal TaxFICA { get; set; }
        public decimal TaxOther { get; set; }

        public DateTime PeriodEndDate
        {
            get
            {
                int startOffset = -4 + (PayDate.DayOfWeek - DayOfWeek.Friday);
                return PayDate.AddDays(startOffset);
            }
        }

        public DateTime PeriodStartDate
        {
            get
            {
                return PeriodEndDate.AddDays(-13);
            }
        }

        public decimal EarningsGross
        {
            get
            {
                return EarningsRegular + EarningsOT + EarningsOther;
            }
        }

        public decimal TaxSocialSecurity
        {
            get
            {
                return EarningsGross * 0.062M;
            }
        }

        public decimal TaxMedicare
        {
            get
            {
                return TaxFICA - TaxSocialSecurity;
            }
        }

        public decimal TaxFedUnemployment
        {
            get
            {
                decimal futaWages = EarningsGross;
                if (futaWages > 7000M)
                    futaWages = 7000M;
                return futaWages * 0.006M;
            }
        }

        public decimal TaxStateUnemployment
        {
            get
            {
                decimal sutaWages = EarningsGross;
                if (sutaWages > 36900M)
                    sutaWages = 36900M;
                return sutaWages * 0.02M;
            }
        }

        public void ComputeRatesFromRegular()
        {
            RateRegular = EarningsRegular / (decimal)HoursRegular;
            RateRegular = Math.Round(RateRegular, 2, MidpointRounding.ToEven);
            RateOT = RateRegular * 1.5M;
            RateOther = RateRegular;
        }

        public void ComputeSickAndBonus()
        {
            EarningsSick = (decimal)HoursOther * RateOther;
            EarningsBonus = EarningsOther - EarningsSick;
        }

        public void Add(Paycheck pay)
        {
            this.HoursRegular += pay.HoursRegular;
            this.HoursOT += pay.HoursOT;
            this.HoursOther += pay.HoursOther;
            this.EarningsRegular += pay.EarningsRegular;
            this.EarningsOT += pay.EarningsOT;
            this.EarningsOther += pay.EarningsOther;
            this.EarningsSick += pay.EarningsSick;
            this.EarningsBonus += pay.EarningsBonus;
            this.TaxFedIncome += pay.TaxFedIncome;
            this.TaxStateIncome += pay.TaxStateIncome;
            this.TaxFICA += pay.TaxFICA;
            this.TaxOther += pay.TaxOther;
        }

        public override string ToString()
        {
            return NameLastFirst +
                " RegHours=" + HoursRegular.ToString("F2") + 
                " OTHours=" + HoursOT.ToString("F2") + 
                " SickHours=" + HoursOther.ToString("F2");
        }
    }
}
