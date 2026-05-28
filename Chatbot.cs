using System;
using System.Collections.Generic;

namespace Part2
{
    public class Chatbot
    {
        private Dictionary<string, List<string>> responses;

        private string userInterest = "";
        private string lastTopic = "";

        Random random = new Random();

        public Chatbot()
        {
            responses = new Dictionary<string, List<string>>();

            responses["password"] = new List<string>()
            {
                "Use strong passwords with symbols and numbers.",
                "Avoid using personal information in passwords.",
                "Use different passwords for each account."
            };

            responses["phishing"] = new List<string>()
            {
                "Do not click suspicious links.",
                "Always verify email senders.",
                "Avoid downloading suspicious attachments."
            };

            responses["privacy"] = new List<string>()
            {
                "Review your privacy settings regularly.",
                "Avoid oversharing personal information online.",
                "Use two-factor authentication."
            };

            responses["scam"] = new List<string>()
            {
                "Be careful of online scams and fake websites.",
                "Never share banking details with strangers.",
                "Verify websites before making payments."
            };
        }
        public string GetResponse(string input)
        {
            input = input.ToLower();

            // SENTIMENT DETECTION
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried. Cybersecurity threats can be dangerous, but learning helps you stay safe.";
            }

            if (input.Contains("frustrated"))
            {
                return "Cybersecurity can be confusing sometimes, but you're doing well by learning.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is great! Staying informed is one of the best ways to stay safe online.";
            }

            // MEMORY
            if (input.Contains("i like privacy"))
            {
                userInterest = "privacy";

                return "Great! I'll remember that you're interested in privacy.";
            }

            // FOLLOW-UP CONVERSATION
            if (input.Contains("tell me more") || input.Contains("another tip"))
            {
                if (lastTopic != "")
                {
                    return GetRandomResponse(lastTopic);
                }

                return "Please ask about a cybersecurity topic first.";
            }

            // GENERAL QUESTIONS
            if (input.Contains("how are you"))
            {
                return "I'm functioning perfectly and ready to help!";
            }

            if (input.Contains("purpose"))
            {
                return "My purpose is to educate users about cybersecurity awareness.";
            }

            if (input.Contains("what can i ask"))
            {
                return "You can ask about passwords, scams, phishing, privacy, and safe browsing.";
            }

            // KEYWORD RECOGNITION
            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;

                    return GetRandomResponse(keyword);
                }
            }

            // MEMORY RECALL
            if (userInterest == "privacy")
            {
                return "Since you're interested in privacy, remember to review your account security settings often.";
            }

            // DEFAULT RESPONSE
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        private string GetRandomResponse(string keyword)
        {
            List<string> topicResponses = responses[keyword];

            int index = random.Next(topicResponses.Count);

            return topicResponses[index];
        }
    }
}