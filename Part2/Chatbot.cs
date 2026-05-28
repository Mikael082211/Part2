using System;
using System.Collections.Generic;

namespace Part2
{
    public class Chatbot
    {
        Random random = new Random();

        // MEMORY
        private string currentTopic = "";
        private string userName = "";

        // =========================
        // PHISHING RESPONSES ARRAY
        // =========================
        private List<string> phishingResponses = new List<string>()
        {
            "Phishing is a scam where attackers trick users into giving personal information.",
            "Phishing emails often pretend to be from trusted companies.",
            "Never click suspicious links in emails or messages.",
            "Always verify website URLs before entering passwords."
        };

        // =========================
        // PASSWORD RESPONSES ARRAY
        // =========================
        private List<string> passwordResponses = new List<string>()
        {
            "Use strong passwords with numbers, symbols, and uppercase letters.",
            "Avoid using your name or birthdate in passwords.",
            "Use a different password for every account.",
            "Enable two-factor authentication for extra security."
        };

        // =========================
        // PRIVACY RESPONSES ARRAY
        // =========================
        private List<string> privacyResponses = new List<string>()
        {
            "Review your privacy settings regularly.",
            "Avoid sharing personal information publicly online.",
            "Use secure passwords to protect private accounts.",
            "Be careful about what you post on social media."
        };

        // =========================
        // MALWARE RESPONSES ARRAY
        // =========================
        private List<string> malwareResponses = new List<string>()
        {
            "Malware is harmful software designed to damage systems.",
            "Avoid downloading files from unknown websites.",
            "Install antivirus software to protect your device.",
            "Keep your software updated to prevent malware attacks."
        };

        // =========================
        // SCAM RESPONSES ARRAY
        // =========================
        private List<string> scamResponses = new List<string>()
        {
            "Online scams often try to steal money or information.",
            "Never trust messages asking for urgent payments.",
            "Scammers often pretend to be banks or companies.",
            "Always verify suspicious messages before responding."
        };

        // =========================
        // MAIN RESPONSE METHOD
        // =========================
        public string GetResponse(string input)
        {
            input = input.ToLower();

            // =========================
            // SENTIMENT DETECTION
            // =========================

            if (input.Contains("worried"))
            {
                if (currentTopic == "phishing")
                {
                    return "It's understandable to feel worried about phishing. Cybercriminals can be convincing, but learning the warning signs helps keep you safe.";
                }

                return "It's okay to feel worried. Cybersecurity can be confusing at first, but I'm here to help.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is great when learning cybersecurity. Asking questions helps you stay safe online.";
            }

            if (input.Contains("frustrated"))
            {
                return "Cybersecurity can feel overwhelming sometimes, but you're doing a great job learning.";
            }

            if (input.Contains("confused"))
            {
                return "No worries! I'll try explain it more simply.";
            }

            // =========================
            // PHISHING KEYWORD
            // =========================

            if (input.Contains("phishing"))
            {
                currentTopic = "phishing";

                return phishingResponses[random.Next(phishingResponses.Count)];
            }

            // =========================
            // PASSWORD KEYWORD
            // =========================

            if (input.Contains("password"))
            {
                currentTopic = "password";

                return passwordResponses[random.Next(passwordResponses.Count)];
            }

            // =========================
            // PRIVACY KEYWORD
            // =========================

            if (input.Contains("privacy"))
            {
                currentTopic = "privacy";

                return privacyResponses[random.Next(privacyResponses.Count)];
            }

            // =========================
            // MALWARE KEYWORD
            // =========================

            if (input.Contains("malware"))
            {
                currentTopic = "malware";

                return malwareResponses[random.Next(malwareResponses.Count)];
            }

            // =========================
            // SCAM KEYWORD
            // =========================

            if (input.Contains("scam"))
            {
                currentTopic = "scam";

                return scamResponses[random.Next(scamResponses.Count)];
            }

            // =========================
            // FOLLOW-UP QUESTIONS
            // =========================

            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("explain more"))
            {
                switch (currentTopic)
                {
                    case "phishing":
                        return "Another phishing tip: Never open attachments from unknown senders.";

                    case "password":
                        return "Another password tip: Use a password manager to store strong passwords securely.";

                    case "privacy":
                        return "Privacy tip: Always check app permissions before installing applications.";

                    case "malware":
                        return "Malware tip: Avoid downloading cracked software from unofficial websites.";

                    case "scam":
                        return "Scam tip: Be cautious of offers that sound too good to be true.";

                    default:
                        return "Can you tell me which cybersecurity topic you'd like to know more about?";
                }
            }

            // =========================
            // GREETINGS
            // =========================

            if (input.Contains("hello") ||
                input.Contains("hi"))
            {
                return "Hello! How can I help you with cybersecurity today?";
            }

            // =========================
            // PURPOSE
            // =========================

            if (input.Contains("purpose"))
            {
                return "My purpose is to help users learn about cybersecurity and stay safe online.";
            }

            // =========================
            // DEFAULT RESPONSE
            // =========================

            return "I'm not sure I understand. Could you rephrase your question?";
        }
    }
}