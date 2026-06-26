Cybersecurity Awareness Bot (WPF Chatbot - POE Part 3)
Project Overview

This project is a WPF-based Cybersecurity Awareness Chatbot developed in C# as part of a POE (Part 3) assessment.

The chatbot is designed to educate users about cybersecurity concepts through:

Interactive chat responses
A cybersecurity quiz game
Task management system
Activity logging system

The application uses a graphical user interface (GUI) and simulates basic Natural Language Processing (NLP) using keyword detection.

Features
1. Chatbot System
Responds to user input using keyword recognition
Supports cybersecurity topics such as:
Password safety
Phishing awareness
Malware protection
Privacy protection
Uses a dictionary-based response system with random replies
2. Basic NLP Simulation
Uses string matching (Contains) to detect user intent
Recognises commands like:
“password”
“phishing”
“malware”
“privacy”
“quiz”
Interprets user input even if phrased differently (basic NLP simulation)
3. Cybersecurity Quiz System
Interactive quiz mode triggered by typing “quiz”
Contains cybersecurity awareness questions such as:
phishing
malware
VPN
password safety
Tracks:
Current question
Score
Provides immediate feedback:
Correct / Incorrect answers
Displays final score at the end
4. Task Assistant System
Allows users to add cybersecurity-related tasks
Tasks include:
Title
Description
Reminder date (default: +1 day)
Tasks are stored in a list (List<CyberTask>)
Logs task creation in activity log

Note: Database helper is included for future MySQL integration but not fully implemented in current logic.

5. Activity Log System
Tracks user and system actions using a static log class
Logs include:
User login
Task creation
Quiz start
Quiz completion
Each log entry includes a timestamp
Logs can be displayed in the chatbot interface
6. Graphical User Interface (WPF)
Built using XAML and C#
Features:
Chat message bubbles (user vs bot)
Input textbox and send button
Status display (user online / bot typing)
Action buttons:
Quiz
Task
Log
Dark theme design with modern UI styling
Project Structure
Part2/
│
├── MainWindow.xaml        # UI Layout (WPF)
├── MainWindow.xaml.cs     # Main application logic
├── Chatbot.cs             # Response engine (keyword-based)
├── CyberTask.cs           # Task model class
├── QuizQuestion.cs        # Quiz question model
├── ActivityLog.cs         # Logs user/system actions
├── DatabaseHelper.cs      # MySQL connection helper (not fully used)
Database (Prepared but not fully implemented)

The project includes a MySQL helper class:

server=localhost;database=CyberBot;uid=root;pwd=password;
Intended database features:
Store tasks permanently
Retrieve tasks on startup
Update task status
Delete tasks

Current version uses in-memory list for tasks.

How to Run the Project
1. Requirements
Visual Studio (2019 or later)
.NET WPF framework
MySQL Connector (optional for future DB expansion)
2. Steps
Open solution in Visual Studio
Build the project
Run (Start Debugging)
Enter your name to begin interaction
Example Usage
Chatbot Interaction
User: phishing
Bot: Phishing is a scam via email or messages.
Quiz Mode
User: quiz
Bot: What is malware?
User: malicious software
Bot: Correct!
Task System
User: (adds task)
Bot: Task added: Cyber Task
Activity Log
12:00:01 - User logged in
12:00:10 - Task Added: Cyber Task
12:01:05 - Quiz started
Key Concepts Used
Object-Oriented Programming (OOP)
WPF GUI development (XAML)
Event-driven programming
Dictionary-based chatbot responses
Basic NLP simulation using string matching
Activity tracking system
Modular class design
Future Improvements
Full MySQL integration for tasks and quiz results
Advanced NLP (sentence parsing or AI-based responses)
Improved task UI (view/edit/delete in interface)
User authentication system
Notification/reminder system
Enhanced quiz UI with multiple-choice buttons
Author : Mikael
