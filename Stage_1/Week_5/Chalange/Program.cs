using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using System.Xml;
namespace DPL_PATHWAYS.Stage_1.Week_5.Chalange
{

    /*
    
        Create an application with an OOP design to help manage customer memberships (think Costco). 

        Four types of memberships need to be handled - a regular, an executive, a non-profit and a corporate. 
        // All four types of memberships have common information including a 
        //     membership id, 
        //     primary contact email address, 
        //     the type of membership, 
        //     /annual cost and
        //     /current amount of purchases for the month.

        In addition, the regular membership has a flat percent for cash-back rewards on all purchases, 
            the executive membership has percentages for two tiers (one below $1000 and one above) of cash-back rewards, 
            the non-profit membership has a cash-back percentage and also a field to indicate if it is a military or educational organization and if so doubles the cash-back percentage, and
            the corporate membership has a flat percent for cash-back rewards. 
        On the administrative side, the four CRUD operations need to be implemented for a membership:
        C - Create a new membership and add to the membership list.  Be sure you don't duplicate the membership ID.  It needs to be unique.

        R - Read all of the memberships in the membership list.
        U - Update an existing membership based on membership ID.
        D - Delete an existing membership based on membership ID.
        Three types of transactions need to be handled:

        Purchase- A purchase will include the membership id and the amount of the purchase (which must be > 0).   
            All four accounts handle a purchase in the same way.  
            If the membership ID exists, the current amount of purchases is increased by the purchase amount.
        Return - A return of an item will include the membership id and the amount of the purchase returned (which must be > 0).  
            All four accounts handle a return in the same way.  
            If the membership ID exists, the current amount of purchases is decreased by the purchase amount.
        Apply cash-back reward - For the apply cash-back reward, 
            the membership id will be provided.  
            Cash-back rewards are handled differently depending on the membership type as described above.  
            When a valid membership ID is given, the system will send a request to the rewards system for the amount of the reward.  
            For this application, you can simply print a console output that says "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." 
            Then zero out the balance. 

        // Technical specifications for your application include:
        // Create an abstract class for a membership.  Membership id, contact email, annual cost, current monthly purchases and type are to be properties.
        //     In addition to the constructors, include a purchase method, a return method, an abstract apply cash-back rewards method, and a useful toString.

        // Create four classes that inherit from the membership class - one four each membership type.  Create properties for the respective data attributes, 
        //     implement the apply cash-back method for each as appropriate, and override the toString as appropriate.

        // In addition, the regular and executive memberships will implement a special offer method from an interface.  
        //     The implementation for a regular membership will simply return 25% of the annual membership cost and the implementation for the executive membership will return 
        //     50% of the annual membership cost.

        // Create and test your classes and methods with hard-coded test data so that there is a list of memberships of different types, costs, and balances.
        // Provide the user the following administrative options:

        C - Create a new membership and add to the membership list. Be sure you don't duplicate the membership ID.  It needs to be unique.
        R - Read all of the memberships in the membership list.
        U - Update an existing membership based on membership ID.
        D - Delete an existing membership based on membership ID.
        Provide the user the following transaction options:
        L - List all of the memberships in the list including all of the information for each account type.
        P - Perform a purchase transaction by getting a membership number from the user and a purchase amount 
            and if the membership exists add the purchase amount to the monthly purchase total.
        T - Perform a return transaction by getting an membership number from the user and a return amount and if the membership exists, 
            perform the return by subtracting the return amount for the monthly purchase total.
        A - Apply cash-back rewards as described above by getting a membership number from the user.
        Q - Quit the transaction processing.
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            //use deictionary to store all members
            Dictionary<Guid, Membership> allMembers = new Dictionary<Guid, Membership>();



            // ADMINISTRATIVE MENUE
            bool exit = false;
            do
            {
                System.Console.WriteLine("\nEDIT MEMBERS");
                System.Console.WriteLine("C - Create a new membership and add to the membership list");
                System.Console.WriteLine("R - Read all of the memberships in the membership list.");
                System.Console.WriteLine("U - Update an existing membership based on membership ID.");
                System.Console.WriteLine("D - Delete an existing membership based on membership ID.");

                System.Console.WriteLine("\nOTHER OPTIIONS");
                System.Console.WriteLine("L - List all of the memberships in the list including all of the information for each account type.");
                System.Console.WriteLine("P - Perform a purchase transaction.");
                System.Console.WriteLine("T - Perform a return transaction.");
                System.Console.WriteLine("A - Apply cash-back rewards.");
                System.Console.WriteLine("Q - Quit the transaction processing.");
                System.Console.Write("Please select an option: ");
                string? userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    // Common inputs for all membership types
                    case "C":

                        Console.Write("Enter email: ");
                        var emailValidator = new EmailAddressAttribute();
                        string? email;
                        email = Console.ReadLine().Trim().ToLower();
                        while (!emailValidator.IsValid(email))
                        {
                            Console.Write("Invalid email format. Please enter a valid email: ");
                            email = Console.ReadLine().Trim().ToLower();
                        }

                        float currentAmount;
                        Console.Write("Enter current amount purchased: ");
                        string currentAmountInput = Console.ReadLine()?.Trim();
                        while (!float.TryParse(currentAmountInput, out currentAmount) || currentAmount < 1)
                        {
                            Console.Write("Invalid amount. Please enter a valid current amount purchased: ");
                            currentAmountInput = Console.ReadLine()?.Trim();
                        }

                        // individual membership creation based on type
                        // istead of creating object for each class and check the membership type, this was the easies way to check all types.
                        Console.Write("Enter membership type (REGULAR / EXECUTIVE / NONPROFIT / CORPORATE): ");
                        string? type = Console.ReadLine()?.Trim().ToUpper();
                        while (type != "REGULAR" && type != "EXECUTIVE" && type != "NONPROFIT" && type != "CORPORATE")
                        {
                            Console.Write("Invalid membership type. Please enter a valid type (REGULAR / EXECUTIVE / NONPROFIT / CORPORATE): ");
                            type = Console.ReadLine()?.Trim().ToUpper();
                        }
                        Membership executive = new ExecutiveMembership(Guid.NewGuid(), email, 0, currentAmount, type);
                        Membership regular = new RegularMembership(Guid.NewGuid(), email, 0, currentAmount, type);
                        Membership nonprofit = new NonProfitMembership(Guid.NewGuid(), email, 0, currentAmount, type, false);
                        Membership corporate = new CorporateMembership(Guid.NewGuid(), email, 0, currentAmount, type);
                        switch (type)
                        {
                            case "REGULAR":
                                allMembers.Add(regular.MembershipId, regular);
                                break;
                            case "EXECUTIVE":
                                allMembers.Add(executive.MembershipId, executive);
                                break;
                            case "NONPROFIT":
                                // asign if it is educational or military 
                                if (type == "NONPROFIT")
                                {
                                    System.Console.WriteLine("Is the organization MILITARY or EDUCATIONAL? (yes/no)");
                                    string? orgOption = Console.ReadLine()?.Trim().ToUpper();
                                    while (orgOption != "YES" && orgOption != "NO")
                                    {
                                        System.Console.WriteLine("Invalid option. Please enter YES or NO");
                                        orgOption = Console.ReadLine()?.Trim().ToUpper();
                                    }
                                    if (orgOption == "YES")
                                    {
                                        (nonprofit as NonProfitMembership).IsMilitaryOrEducationalOrganization = true;
                                    }
                                }
                                allMembers.Add(nonprofit.MembershipId, nonprofit);
                                break;
                            case "CORPORATE":
                                allMembers.Add(corporate.MembershipId, corporate);
                                break;
                            default:
                                Console.WriteLine("Invalid membership. Please try again.");
                                //regular = new RegularMembership(Guid.NewGuid(), email, 0, currentAmount, "REGULAR");
                                break;
                        }

                        //Console.WriteLine($"Membership created successfully! ID: {regular.MembershipId}");
                        break;
                    // Read all of the memberships in the membership list.
                    case "R":
                        System.Console.WriteLine("Enter membership type to read (REGULAR / EXECUTIVE / NONPROFIT / CORPORATE):");
                        string readType = Console.ReadLine().Trim().ToUpper();
                        while (readType != "REGULAR" && readType != "EXECUTIVE" && readType != "NONPROFIT" && readType != "CORPORATE")
                        {
                            System.Console.WriteLine("Invalid membership type. Please enter a valid type (REGULAR / EXECUTIVE / NONPROFIT / CORPORATE):");
                            readType = Console.ReadLine().Trim().ToUpper();
                        }
                        System.Console.WriteLine($"\nListing all {readType} memberships:");
                        foreach (var member in allMembers.Values)
                        {
                            if (member.AccountType == readType)
                            {
                                System.Console.WriteLine(member);
                            }
                        }

                        break;
                    // Update an existing membership email based on ID.
                    case "U":
                        System.Console.WriteLine("Verify the ID");
                        Guid guid;
                        Guid IdFound = Guid.Empty;
                        while (!Guid.TryParse(Console.ReadLine(), out guid) && !allMembers.ContainsKey(guid))
                        {
                            System.Console.WriteLine("Error: Id not verified. Try again...");
                        }
                        foreach (var member in allMembers)
                        {
                            if (member.Key.Equals(guid))

                                IdFound = guid;
                        }
                        if (IdFound != Guid.Empty)
                        {
                            System.Console.WriteLine("Enter neew email");
                            EmailAddressAttribute emailFormat = new EmailAddressAttribute();
                            string newEmail;

                            while (!emailFormat.IsValid(newEmail = Console.ReadLine()?.Trim()))
                            {
                                System.Console.WriteLine("Error: Invalid email format. Try again...");
                            }
                            allMembers[IdFound].Email = newEmail;
                            System.Console.WriteLine("Email updated successfully!");

                        }
                        break;

                    // Delete membership by ID.
                    case "D":
                        System.Console.WriteLine("Enter the Id of the member you would like to delete");
                        //Guid guid;
                        Guid idFound = Guid.Empty;
                        while (!Guid.TryParse(Console.ReadLine()?.Trim(), out guid) && !allMembers.ContainsKey(guid))
                        {
                            System.Console.WriteLine("Invalid Id: Please try again...");
                        }
                        foreach (var member in allMembers)
                        {
                            if (member.Key.Equals(guid))
                            {
                                idFound = guid;
                            }
                        }
                        if (idFound != Guid.Empty)
                        {
                            allMembers.Remove(idFound);
                            System.Console.WriteLine($"Member deleted successfully.");
                            //System.Console.WriteLine($"Member in {allMembers[idFound].type} deleted successfully.");
                        }


                        break;
                    case "L":
                        // List all of the memberships in the list including all of the information for each account type.
                        System.Console.WriteLine("Here is a list of all memberships:");
                        if (allMembers.Count == 0)
                        {
                            System.Console.WriteLine("\nNo members found.");
                        }
                        else
                        {
                            foreach (var members in allMembers.Values)
                            {
                                System.Console.WriteLine(members);
                            }
                        }
                        break;
                    // Perform a purchase transaction by getting a membership number from the user and a purchase amount 
                    // and if the membership exists add the purchase amount to the monthly purchase total.
                    case "P":
                        // Purchase transaction
                        System.Console.WriteLine("Enter the Id of the member to perfotm purchase");
                        //Guid guid;
                        Guid PurchaseIddFound = Guid.Empty;
                        while (!Guid.TryParse(Console.ReadLine(), out guid) && !allMembers.ContainsKey(guid))
                        {
                            System.Console.WriteLine("Error: Id not verified: try again...");
                        }
                        System.Console.WriteLine("Enter Purchased amount");
                        string? purchase = Console.ReadLine()?.Trim();
                        float validPurchase;

                        while (!float.TryParse(purchase, out validPurchase) || validPurchase <= 0)
                        {
                            System.Console.WriteLine("Error: Please try again.");
                            purchase = Console.ReadLine()?.Trim();
                        }
                        Membership ids = allMembers[guid];
                        RegularMembership regularMember = ids as RegularMembership; // Cast to RegularMembership
                        ExecutiveMembership executiveMember = ids as ExecutiveMembership;
                        NonProfitMembership nonprofitMember = ids as NonProfitMembership;
                        CorporateMembership corporateMember = ids as CorporateMembership;
                        if (ids is RegularMembership)
                        {
                            regularMember.PurchaseRegularAmount(regularMember.MembershipId, validPurchase);
                        }
                        else if (ids is ExecutiveMembership)
                        {
                            executiveMember.PurchaseExecutiveAmount(executiveMember.MembershipId, validPurchase);
                        }
                        else if (ids is NonProfitMembership)
                        {
                            nonprofitMember.PurchaseNonProfitAmount(nonprofitMember.MembershipId, validPurchase);
                        }
                        else if (ids is CorporateMembership)
                        {
                            corporateMember.PurchaseCorporateAmount(corporateMember.MembershipId, validPurchase);
                        }
                        else
                        {
                            System.Console.WriteLine("Membership ID not found.");
                        }

                        break;
                    case "T":
                        // Return transaction
                        System.Console.WriteLine("Enter the Id of the member to perform return");
                        //string? returnAmount;

                        while (!Guid.TryParse(Console.ReadLine()?.Trim(), out guid) && !allMembers.ContainsKey(guid))
                        {
                            System.Console.WriteLine("Id not verified: Please try again");
                        }
                        float validReturn;
                        System.Console.WriteLine("Enter the amount to return");
                        while (!float.TryParse(Console.ReadLine(), out validReturn) && validReturn < 1)
                        {
                            System.Console.WriteLine("Error: invalid option: please try again");
                        }
                        Membership returnIds = allMembers[guid];
                        RegularMembership regularReturn = returnIds as RegularMembership; // Casted
                        ExecutiveMembership executiveReturn = returnIds as ExecutiveMembership;
                        NonProfitMembership nonprofitReturn = returnIds as NonProfitMembership;
                        CorporateMembership corporateReturn = returnIds as CorporateMembership;
                        if (returnIds is RegularMembership)
                        {
                            regularReturn.ReturnRegularAmount(regularReturn.MembershipId, validReturn);
                        }
                        else if (returnIds is ExecutiveMembership)
                        {
                            executiveReturn.ReturnExecutiveAmount(executiveReturn.MembershipId, validReturn);
                        }
                        else if (returnIds is NonProfitMembership)
                        {
                            nonprofitReturn.ReturnNonProfitAmount(nonprofitReturn.MembershipId, validReturn);
                        }
                        else if (returnIds is CorporateMembership)
                        {
                            corporateReturn.ReturnCorporateAmount(corporateReturn.MembershipId, validReturn);
                        }
                        else
                        {
                            System.Console.WriteLine("Membership ID not found.");
                        }
                        break;
                    case "A":
                        // Apply cash-back rewards
                        System.Console.WriteLine("verified Id before applying cash back rewards");

                        while (!Guid.TryParse(Console.ReadLine()?.Trim(), out guid) && !allMembers.ContainsKey(guid))
                        {
                            System.Console.WriteLine("Id not verified: Please try again");
                        }
                        Membership cashBack = allMembers[guid];
                        RegularMembership cashBackRegular = cashBack as RegularMembership; // cas for cahs back manipulation
                        ExecutiveMembership cashBackExecutive = cashBack as ExecutiveMembership;
                        NonProfitMembership cashBackNonprofit = cashBack as NonProfitMembership;
                        CorporateMembership cashBackCorporate = cashBack as CorporateMembership;
                        if (cashBack is RegularMembership)
                        {
                            cashBackRegular.CashBackRewardSystem(guid);
                        }
                        else if (cashBack is ExecutiveMembership)
                        {
                            cashBackExecutive.CashBackRewardSystem(guid);
                        }
                        else if (cashBack is NonProfitMembership)
                        {
                            cashBackNonprofit.CashBackRewardSystem(guid);
                        }
                        else if (cashBack is CorporateMembership)
                        {
                            cashBackCorporate.CashBackRewardSystem(guid);
                        }
                        else
                        {
                            System.Console.WriteLine("Membership ID not found.");
                        }
                        break;
                    case "Q":
                        exit = true;
                        break;
                    default:
                        System.Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (!exit);
        }

    }
}
