namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{
    public class RegularMembership : Membership, ISpecialOffer
    {
        public RegularMembership(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType)
            : base(membershipId, email, anualCost, currentAmountPurchase, accountType)
        {
            AccountType = "REGULAR";
            AnualCost = 100; // Set a default annual cost for regular membership
        }

        // Perform a purchase and update current amount
        public float PurchaseRegularAmount(Guid memberId, float amount)
        {
            base.Purchase(memberId, amount);
            return base.CurrentAmountPurchase;
        }

        // Perform a return and update current amount
        public float ReturnRegularAmount(Guid memberId, float amount)
        {
            base.ReturnedAmount(memberId, amount);
            return base.CurrentAmountPurchase;
        }

        // cash-back rewards method
        // In addition, the regular membership has a flat percent for cash-back rewards on all purchases
        public override void CashBackRewardSystem(Guid guid)
        {
            // Implementation for cash-back rewards system
            Console.WriteLine("\nCash-back rewards applied for Regular Membership ID: " + MembershipId + " Amount: " + (CurrentAmountPurchase * 0.001f).ToString("C"));
            CurrentAmountPurchase = 0;
        }

        // Special offer based on annual cost
        public decimal Offer()
        {
            return AnualCost * 0.25m;
        }

        public override string ToString()
        {
            return "\nRegular Membership Id: {0}\nEmail: {1}\nAnnual Cost: {2}\nCurrent Monthly Purchase: {3}\nAccount Type: {4}\nSpecial Offer Amount: {5}"
                .Replace("{0}", MembershipId.ToString())
                .Replace("{1}", Email)
                .Replace("{2}", AnualCost.ToString("C"))
                .Replace("{3}", CurrentAmountPurchase.ToString("C"))
                .Replace("{4}", AccountType)
                .Replace("{5}", Offer().ToString("C"));
        }
    }
}
