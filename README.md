# IronPhonePad

A C# solution for the "Old Phone Pad" coding challenge. This library implements a decoder for old-style T9 mobile phone keypad inputs, converting numeric sequences into uppercase alphabetic text.

## Features

* **State Machine Logic:** Handles button presses, pauses, and cycles correctly without complex nested loops.
* **Backspace Support:** The `*` key correctly cancels pending characters or deletes committed ones.
* **Production Ready:** Includes XML documentation, unit tests, and a modular project structure.

## Structure

The solution is organized into three projects:

* **src/IronPhonePad.Core**: The main logic library (Class Library).
* **src/IronPhonePad.Console**: A simple console runner for manual testing.
* **tests/IronPhonePad.Tests**: Automated NUnit tests covering edge cases.

```
IronPhonePad/                  # Root Solution Folder
├── .github/                   # CI/CD workflows
│   └── workflows/
│       └── dotnet.yml         # GitHub Actions configuration
├── src/                       # Source code
│   ├── IronPhonePad.Core/     # Class Library (The Logic)
│   │   ├── PhoneKeypad.cs     # The OldPhonePad method
│   │   └── IronPhonePad.Core.csproj
│   └── IronPhonePad.Console/  # Console App (For manual testing)
│       ├── Program.cs         # Calls OldPhonePad for demo
│       └── IronPhonePad.Console.csproj
├── tests/                     # Automated Tests
│   └── IronPhonePad.Tests/
│       ├── PhoneKeypadTests.cs
│       └── IronPhonePad.Tests.csproj
├── .editorconfig              # Code style enforcement
├── .gitignore                 # Standard Visual Studio gitignore
├── IronPhonePad.sln           # Solution file linking projects
└── README.md                  # Documentation
```
## Getting Started

### Prerequisites
* .NET 10.0 SDK

### How to Run (Manual Test)
To run the console application and see the decoder in action:

```bash
dotnet run --project src/IronPhonePad.Console
```

## AI Usage Declaration

As requested in the submission instructions, AI tools were used to assist in **project scaffolding, CI/CD configuration, and documentation structure**. The core problem-solving logic was implemented manually.

* **AI Tool:** OpenAI Gemini
* **Prompt:** Requested a production-ready .NET 8 solution structure, CLI setup commands, and GitHub Actions workflow configuration.
* **Full Prompt Link:** [Link to Prompt](AI_PROMPT.md)

## Developer
* Sankalp S. Indish
* LinkedIn: https://www.linkedin.com/in/sankalp-indish/
