using System.ComponentModel.DataAnnotations;

namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{
    /*
    
        Create an abstract class for a membership.  Membership id, contact email, annual cost, current monthly purchases and type are to be properties.
            In addition to the constructors, include a purchase method, a return method, an abstract apply cash-back rewards method, and a useful toString.
    
    */
    public abstract class Membership
    {
        public Guid MembershipId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public decimal AnualCost { get; set; }
        public float CurrentAmountPurchase { get; set; }
        public string AccountType { get; set; }

        public Membership()
        {
            MembershipId = Guid.NewGuid();
            Email = string.Empty;
            AnualCost = 0;
            CurrentAmountPurchase = 0;
            AccountType = string.Empty;
        }
        public Membership(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType)
        {
            MembershipId = membershipId;
            Email = email;
            AnualCost = anualCost;
            CurrentAmountPurchase = currentAmountPurchase;
            AccountType = accountType;
        }
        // purchase method
        public float Purchase(Guid userInput, float amount)
        {
            //var getMemberById = listMembership.Find(m => m.MembershipId == userInput);

            CurrentAmountPurchase += amount;
            AnualCost += (decimal)amount; // keep track of anual cost based on purchases
            return CurrentAmountPurchase;


        }
        //return method
        public float ReturnedAmount(Guid userInput, float returned)
        {
            //var getMemberById = listMembershipId.All(m => m.MembershipId.Equals(userInput));

            CurrentAmountPurchase -= returned;
            AnualCost -= (decimal)returned; // keep track of anual cost based on returns
            return CurrentAmountPurchase;
        }
        //cash-back rewards method
        //When a valid membership ID is given, the system will send a request to the rewards system for the amount of the reward.
        public abstract void CashBackRewardSystem(Guid guid);
        public override string ToString()
        {
            return "Account Id :{0} Email: {1} Anual Cost: {2} Current Monthly Purchase: {3} Account Type: {4}"
                .Replace("{0}", MembershipId.ToString())
                .Replace("{1}", Email)
                .Replace("{2}", AnualCost.ToString("C"))
                .Replace("{3}", CurrentAmountPurchase.ToString("C"))
                .Replace("{4}", AccountType);
        }
    }
}