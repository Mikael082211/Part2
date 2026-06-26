using System;
using System.Collections.Generic;

namespace Part2
{
    public class Chatbot
    {
        private Dictionary<string, List<string>> responses = new()
        {
            ["password"] = new List<string>
            {
                "Use strong passwords.",
                "Never reuse passwords.",
                "Use a password manager."
            },

            ["phishing"] = new List<string>
            {
                "Phishing is a scam via email or messages.",
                "Never click unknown links."
            },

            ["malware"] = new List<string>
            {
                "Malware harms your device.",
                "Use antivirus software."
            },

            ["privacy"] = new List<string>
            {
                "Protect your personal data online.",
                "Use privacy settings."
            }
        };

        private Random rand = new();

        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var key in responses.Keys)
            {
                if (input.Contains(key))
                    return responses[key][rand.Next(responses[key].Count)];
            }

            return "I can help with passwords, phishing, malware, and privacy.";
        }
    }
}
