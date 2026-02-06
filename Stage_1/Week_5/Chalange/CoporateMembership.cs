using System;

namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{
    public class CorporateMembership : Membership
    {
        public CorporateMembership(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType) : base(membershipId, email, anualCost, currentAmountPurchase, accountType)
        {
            AccountType = "CORPORATE";
            AnualCost = 1000; // Set a default annual cost for corporate membership
        }

        // purchase
        public float PurchaseCorporateAmount(Guid userInput, float amount)
        {
            base.Purchase(userInput, amount);
            return base.CurrentAmountPurchase;
        }
        // return
        public float ReturnCorporateAmount(Guid userInput, float amount)
        {
            base.ReturnedAmount(userInput, amount);
            return base.CurrentAmountPurchase;
        }
        public override void CashBackRewardSystem(Guid guid)
        {
            // Implementation for cash-back rewards system
            // the corporate membership has a flat percent for cash-back rewards.
            Console.WriteLine("Cash-back rewards applied for Regular Membership ID: " + MembershipId + " Amount: " + (CurrentAmountPurchase * 0.005f).ToString("C"));
            CurrentAmountPurchase = 0;
        }
        public override string ToString()
        {
            return "\nRegular Membership Id :{0}\nEmail: {1}\nAnual Cost: {2}\nCurrent Monthly Purchase: {3}\nAccount Type: {4}"
                .Replace("{0}", MembershipId.ToString())
                .Replace("{1}", Email)
                .Replace("{2}", AnualCost.ToString("C"))
                .Replace("{3}", CurrentAmountPurchase.ToString("C"))
                .Replace("{4}", AccountType);
        }
    }
}