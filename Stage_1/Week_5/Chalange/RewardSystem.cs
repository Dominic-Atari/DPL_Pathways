// using System;
// namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
// {
//     /*

//         Create a reward system class to handle the cash-back reward requests from the different membership types.
//         For this application, you can simply print a console output that says "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." 

//     */
//     public class RewardSystem
//     {
//         // public RewardSystem(Guid membershipId, string email, decimal anualCost, float currentAmountPurchase, string accountType) : base(membershipId, email, anualCost, currentAmountPurchase, accountType)
//         // {
//         // }
//         // public override float Cash_back_reward_system(List<Membership> listMemberahipId, Guid userInput)
//         // {
//         //     var getMemberById = listMemberahipId.All(m => m.MembershipId == userInput);
//         //     if (IsValid(userInput))
//         //     {
//         //         RewardSystem rewardSystem = new RewardSystem();
//         //         rewardSystem.ProcessCashBackReward();
//         //         return base.CurrentAmountPurchase;
//         //     }
//         //     else
//         //     {
//         //         System.Console.WriteLine("Error: Id not found.");
//         //         return;
//         //     }
//         // }

//         Membership membership = new Membership();
//         public void ProcessCashBackReward()
//         {
//             System.Console.WriteLine($"Cash-back reward request for membership {membership.MembershipId} in the amount of {membership.CurrentAmountPurchase.ToString("C")} has been made.");
//             membership.CurrentAmountPurchase = 0;
//         }
//     }
// }