namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{
    public class NonProfitMembership : Membership
    {
        public bool IsMilitaryOrEducationalOrganization { get; set; }
        public NonProfitMembership(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType, bool isMilitaryOrEducationalOrganization) : base(membershipId, email, anualCost, currentAmountPurchase, accountType)
        {
            AccountType = "NONPROFIT";
            AnualCost = 50; // Set a default annual cost for non-profit membership
            IsMilitaryOrEducationalOrganization = isMilitaryOrEducationalOrganization;
        }

        // purchase
        public float PurchaseNonProfitAmount(Guid userInput, float amount)
        {
            base.Purchase(userInput, amount);
            return base.CurrentAmountPurchase;
        }
        // return
        public float ReturnNonProfitAmount(Guid userInput, float amount)
        {
            base.ReturnedAmount(userInput, amount);
            return base.CurrentAmountPurchase;
        }
        public override void CashBackRewardSystem(Guid guid)
        {
            // Implementation for cash-back rewards system
            // the non-profit membership has a cash-back percentage and also a field to indicate if it is a 
            // military or educational organization and if so doubles the cash-back percentage
            if (IsMilitaryOrEducationalOrganization)
            {
                Console.WriteLine("Cash-back rewards applied for Non-Profit Membership ID: " + MembershipId + " Amount: "
                + (CurrentAmountPurchase * 0.10f).ToString("C"));
                CurrentAmountPurchase = 0;
                return;
            }
            Console.WriteLine("Cash-back rewards applied for Regular Membership ID: " + MembershipId + " Amount: "
            + (CurrentAmountPurchase * 0.05f).ToString("C"));
            CurrentAmountPurchase = 0;
        }
        public override string ToString()
        {
            return "\nNon-Profit Membership Id :{0}\nEmail: {1}\nAnual Cost: {2}\nCurrent Monthly Purchase: {3}\nAccount Type: {4}\nIs Military or Educational Organization: {5}"
                .Replace("{0}", MembershipId.ToString())
                .Replace("{1}", Email)
                .Replace("{2}", AnualCost.ToString("C"))
                .Replace("{3}", CurrentAmountPurchase.ToString("C"))
                .Replace("{4}", AccountType)
                .Replace("{5}", IsMilitaryOrEducationalOrganization.ToString());
        }
    }
}