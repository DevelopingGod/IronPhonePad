using System;
using System.Collections.Generic;
using System.Text;
namespace IronPhonePad.Core // Make sure this matches your 'using'
{
    public class PhoneKeypad // Must be 'public'
    {
        // Mapping of keypad digits to their respective characters
        private static readonly Dictionary<char, string> KeypadMap = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
            // 0 and 1 generally have no letters on standard keypads, treated as distinct pauses if necessary.
        };

        /// <summary>
        /// Converts numeric old-phone keypad input into alphabetical text.
        /// </summary>
        /// <param name="input">The sequence of button presses ending with #.</param>
        /// <returns>The decoded string.</returns>
        public static string OldPhonePad(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            char? currentButton = null;
            int pressCount = 0;

            foreach (char c in input)
            {
                // Stop processing immediately upon reaching the send button
                if (c == '#')
                {
                    break;
                }

                // Handle Backspace (*)
                if (c == '*')
                {
                    if (currentButton.HasValue)
                    {
                        // If we are currently typing a character, cancel it
                        currentButton = null;
                        pressCount = 0;
                    }
                    else if (result.Length > 0)
                    {
                        // If nothing is pending, delete the last committed character
                        result.Length--;
                    }
                    continue;
                }

                // Handle Spaces (Pause)
                if (c == ' ')
                {
                    CommitPendingChar(result, ref currentButton, ref pressCount);
                    continue;
                }

                // Handle Digits
                if (char.IsDigit(c) && KeypadMap.ContainsKey(c))
                {
                    if (currentButton == c)
                    {
                        // Same button pressed again: cycle through letters
                        pressCount++;
                    }
                    else
                    {
                        // Different button pressed: commit previous and start new
                        CommitPendingChar(result, ref currentButton, ref pressCount);
                        currentButton = c;
                        pressCount = 1;
                    }
                }
                else
                {
                    // If a digit is not in the map (e.g., 1 or 0), just commit pending and ignore
                    CommitPendingChar(result, ref currentButton, ref pressCount);
                }
            }

            // Commit any lingering character pending when '#' was hit
            CommitPendingChar(result, ref currentButton, ref pressCount);

            return result.ToString();
        }

        private static void CommitPendingChar(StringBuilder result, ref char? currentButton, ref int pressCount)
        {
            if (currentButton.HasValue && KeypadMap.TryGetValue(currentButton.Value, out string? letters))
            {
                // Calculate which letter to pick based on press count (cyclic)
                // (pressCount - 1) converts 1st press to index 0
                int index = (pressCount - 1) % letters.Length;
                result.Append(letters[index]);
                
                // Reset state
                currentButton = null;
                pressCount = 0;
            }
        }
    }
}