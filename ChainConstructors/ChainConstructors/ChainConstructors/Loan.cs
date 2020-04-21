using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainConstructors
{
    public class Loan
    {
        private ILoanStrategy strategy;
        private float notional;
        private float outstanding;
        private int rating;
        private DateTime expiry;
        private DateTime maturity;

        private void Initialize(ILoanStrategy strategy, float notional, float outstanding, int rating, DateTime expiry, DateTime maturity = default(DateTime))
        {
            this.strategy = strategy;
            this.notional = notional;
            this.outstanding = outstanding;
            this.rating = rating;
            this.expiry = expiry;
            this.maturity = maturity;
        }

        public Loan(float notional, float outstanding, int rating, DateTime expiry)
        {
            var temROC = new TermRoc();
            Initialize(temROC, notional, outstanding, rating, expiry);
        }

        public Loan(float notional, float outstanding, int rating, DateTime expiry, DateTime maturity)
        {
            var revolvingTermRoc = new RevolvingTermRoc();
            Initialize(revolvingTermRoc, notional, outstanding, rating, expiry, maturity);
        }

        public Loan(ILoanStrategy strategy, float notional, float outstanding, int rating, DateTime expiry, DateTime maturity)
        {
            var revolvingTermRoc = new RevolvingTermRoc();
            Initialize(revolvingTermRoc, notional, outstanding, rating, expiry, maturity);
        }
    }
}
