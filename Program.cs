using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist");

            Dictionary<int, string> memberName = new Dictionary<int, string> ();
            Dictionary<int, int> skillLevel = new Dictionary<int, int> ();
            Dictionary<int, decimal> courageFactor = new Dictionary<int, decimal> ();

            // List<Dictionary<int, string>> members = new List<Dictionary<int, string>> ();
            // List<Dictionary<int, int>> skills = new List<Dictionary<int, int>> ();
            // List<Dictionary<int, decimal>> courages = new List<Dictionary<int, decimal>> ();

            //users name
            Console.WriteLine ("What is the Bank Difficulty?");
            int bankDifficulty = int.Parse (Console.ReadLine ());
            int successCount = 0;
            int failCount = 0;
            while (true) {

                Console.WriteLine ("Write Your Name");
                string name;
                name = Console.ReadLine ();
                if (name == "") {

                    Console.WriteLine ("How many attempts do you want");
                    int trialAttempts = int.Parse (Console.ReadLine ());

                    Console.WriteLine ("The Team Members");

                    foreach (KeyValuePair<int, string> person in memberName) {
                        int skillLevelInt = skillLevel[person.Key];
                        decimal courageFactorDecimal = courageFactor[person.Key];
                        Console.WriteLine ($"Name:  {person.Value} Skill Level:{skillLevelInt} Courage Factor:{courageFactorDecimal} ");
                    }
                    int totalSkills = 0;
                    for (int i = 0; i < skillLevel.Count; i++) {
                        totalSkills += skillLevel[i];
                    }

                    for (int i = 0; i < trialAttempts; i++) {

                        Random bankLuck = new Random ();

                        int secretNumber = bankLuck.Next (-10, 11);
                        bankDifficulty = bankDifficulty + secretNumber;
                        Console.WriteLine ($"Attempt {i}");
                        Console.WriteLine ($"There are {memberName.Count} team members");
                        Console.WriteLine ($"Your teams Skill Level is {totalSkills}");
                        Console.WriteLine ($"The bank Difficulty is {bankDifficulty}");
                        if (totalSkills < bankDifficulty) {
                            Console.WriteLine ("Your team will fail!");
                            successCount++;
                        } else {
                            Console.WriteLine ("Your team will Succeed!");
                            failCount++;
                        }
                    }
                    break;
                }
                memberName.Add (memberName.Count, name);
                // members.Add (memberName);
                //users skill level
                Console.WriteLine ("Write your Skill Level between 1 and 50");
                int skill;
                skill = int.Parse (Console.ReadLine ());

                skillLevel.Add (skillLevel.Count, skill);

                // courage factor
                Console.WriteLine ("How much courage you got? between 0.0 and 2.0");
                decimal courage;
                courage = decimal.Parse (Console.ReadLine ());
                courageFactor.Add (courageFactor.Count, courage);

                // courages.Add (courageFactor);
                // Console.WriteLine ("the user's info");

                // foreach (KeyValuePair<int, string> pair in memberName) {
                //     Console.WriteLine ($"Name: {pair.Value}");
                // }
                // foreach (KeyValuePair<int, int> pair in skillLevel) {
                //     Console.WriteLine ($"Skill Level: {pair.Value}");
                // }
                // foreach (KeyValuePair<int, decimal> pair in courageFactor) {
                //     Console.WriteLine ($"Courage Factor: {pair.Value}");
                // }
            }
            Console.WriteLine ($"You failed {failCount} times!");
            Console.WriteLine ($"You succeeded {successCount} times!");

        }
    }
}