namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{
    public class ExecutiveMembership : Membership, ISpecialOffer
    {
        public ExecutiveMembership(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType)
        : base(membershipId, email, anualCost, currentAmountPurchase, accountType)
        {
            AccountType = "EXECUTIVE";
            AnualCost = 500; // Set a default annual cost for executive membership
        }

        // purchase
        public float PurchaseExecutiveAmount(Guid userInput, float amount)
        {
            base.Purchase(userInput, amount);
            return base.CurrentAmountPurchase;
        }
        // return
        public float ReturnExecutiveAmount(Guid userInput, float amount)
        {
            base.ReturnedAmount(userInput, amount);
            return base.CurrentAmountPurchase;
        }

        public override void CashBackRewardSystem(Guid guid)
        {
            // Implementation for cash-back rewards system
            // the executive membership has percentages for two tiers (one below $1000 and one above) of cash-back rewards
            Console.WriteLine("Cash-back rewards applied for Regular Membership ID: " + MembershipId + " Amount: " + (CurrentAmountPurchase * 0.02f).ToString("C"));
            CurrentAmountPurchase = 0;
        }

        // Special offer.
        public decimal Offer()
        {
            var offerAmount = base.AnualCost * 0.5m;
            return offerAmount;
        }

        public override string ToString()
        {
            return "\nRegular Membership Id :{0}\nEmail: {1}\nAnual Cost: {2}\nCurrent Monthly Purchase: {3}\nAccount Type: {4}\nAccount Special Offer Amount: {5}"
                .Replace("{0}", MembershipId.ToString())
                .Replace("{1}", Email)
                .Replace("{2}", AnualCost.ToString("C"))
                .Replace("{3}", CurrentAmountPurchase.ToString("C"))
                .Replace("{4}", AccountType)
                .Replace("{5}", Offer().ToString("C"));
        }
    }
}