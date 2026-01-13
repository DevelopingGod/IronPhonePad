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

## Getting Started

### Prerequisites
* .NET 8.0 SDK

### How to Run (Manual Test)
To run the console application and see the decoder in action:

```bash
dotnet run --project src/IronPhonePad.Console