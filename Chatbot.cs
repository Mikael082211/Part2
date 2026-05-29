using System;
using System.Collections.Generic;

namespace Part2
{
    public class Chatbot
    {
        Random random = new Random();

        // MEMORY
        private string favouriteTopic = "";
        private string userName = "";

        // TRACK LAST TOPIC
        private string lastTopic = "";

        // RESPONSES
        Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols, numbers, and capital letters.",
                    "Never use your birthday as a password.",
                    "Use different passwords for different accounts.",
                    "Enable two-factor authentication for better security."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Phishing scams often pretend to be trusted companies.",
                    "Never click suspicious email links.",
                    "Check email addresses carefully before replying.",
                    "Avoid downloading attachments from unknown senders."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly.",
                    "Avoid sharing personal information publicly online.",
                    "Use secure websites that start with HTTPS.",
                    "Limit the amount of personal data you post online."
                }
            },

            {
                "malware",
                new List<string>()
                {
                    "Install antivirus software to protect your device.",
                    "Avoid downloading files from unknown websites.",
                    "Keep your software updated to prevent malware attacks.",
                    "Scan USB devices before opening files."
                }
            },

            {
                "safe browsing",
                new List<string>()
                {
                    "Avoid clicking pop-up ads on unknown websites.",
                    "Use trusted browsers with security protection.",
                    "Never save passwords on public computers.",
                    "Always log out from sensitive accounts."
                }
            }
        };

        // MAIN RESPONSE METHOD
        public string GetResponse(string input)
        {
            input = input.ToLower();

            // GREETINGS
            if (input.Contains("hello") ||
                input.Contains("hi") ||
                input.Contains("hey"))
            {
                string[] greetings =
                {
                    "Hello!  I'm feeling excited to help you stay safe online.",
                    "Hi there! I'm ready to teach you about cybersecurity.",
                    "Hey!  I'm doing great and ready to help protect you online.",
                    "Welcome!  I'm feeling positive and prepared to assist you."
                };

                return greetings[random.Next(greetings.Length)];
            }

            // ASKING HOW BOT FEELS
            if (input.Contains("how are you"))
            {
                string[] feelings =
                {
                    "I'm feeling helpful and ready to protect you from cyber threats! ",
                    "I'm doing great! I'm excited to teach cybersecurity today.",
                    "I'm feeling secure and ready to assist you.",
                    "I'm excellent! Staying cyber-safe always makes me happy."
                };

                return feelings[random.Next(feelings.Length)];
            }

            // USER NAME MEMORY
            if (input.Contains("my name is"))
            {
                string[] words = input.Split(' ');

                userName = words[words.Length - 1];

                return $"Nice to meet you, {userName}! I'll remember your name.";
            }

            // FAVORITE TOPIC MEMORY
            if (input.Contains("i like"))
            {
                if (input.Contains("phishing"))
                    favouriteTopic = "phishing";

                else if (input.Contains("privacy"))
                    favouriteTopic = "privacy";

                else if (input.Contains("password"))
                    favouriteTopic = "password";

                return $"Awesome! I'll remember that you're interested in {favouriteTopic}.";
            }

            // SENTIMENT DETECTION
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried. Cyber threats can be scary, but learning safe habits can protect you online. ";
            }

            if (input.Contains("confused"))
            {
                return "No problem!  I'll explain things more simply for you.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is great in cybersecurity! Asking questions helps you stay safe online.";
            }

            if (input.Contains("frustrated"))
            {
                return "I understand cybersecurity can sometimes feel overwhelming. Let's take it step by step.";
            }

            // FOLLOW-UP QUESTIONS
            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("give me another tip"))
            {
                if (lastTopic != "" && responses.ContainsKey(lastTopic))
                {
                    List<string> tips = responses[lastTopic];

                    return tips[random.Next(tips.Count)];
                }

                return "Please choose a cybersecurity topic first.";
            }

            // KEYWORD RECOGNITION
            foreach (var topic in responses)
            {
                if (input.Contains(topic.Key))
                {
                    lastTopic = topic.Key;

                    List<string> topicResponses = topic.Value;

                    return topicResponses[random.Next(topicResponses.Count)];
                }
            }

            // PURPOSE
            if (input.Contains("what is your purpose"))
            {
                return "My purpose is to help users learn cybersecurity awareness and stay safe online.";
            }

            // EXIT
            if (input.Contains("exit"))
            {
                return "Goodbye! Stay safe online. ";
            }

            // DEFAULT RESPONSE
            return "I'm not sure I understand. Could you rephrase that?";
        }
    }
}
