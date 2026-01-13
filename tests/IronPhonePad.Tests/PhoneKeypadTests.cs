using NUnit.Framework;
using IronPhonePad.Core;

namespace IronPhonePad.Tests
{
    [TestFixture]
    public class PhoneKeypadTests
    {
        [Test]
        public void OldPhonePad_SimpleExample_ReturnsE()
        {
            // Source Ex 1: 33# -> E
            Assert.That(PhoneKeypad.OldPhonePad("33#"), Is.EqualTo("E"));
        }

        [Test]
        public void OldPhonePad_BackspaceDuringTyping_ReturnsB()
        {
            // Source Ex 2: 227*# -> B
            // Logic: 22 (B pending), 7 (Commit B, P pending), * (Cancel P), # (End) -> Result B
            Assert.That(PhoneKeypad.OldPhonePad("227*#"), Is.EqualTo("B"));
        }

        [Test]
        public void OldPhonePad_ComplexHello_ReturnsHELLO()
        {
            // Source Ex 3
            Assert.That(PhoneKeypad.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));

            
        }

        [Test]
        public void OldPhonePad_TuringMystery_ReturnsTURING()
        {
            // Source Ex 4
            Assert.That(PhoneKeypad.OldPhonePad("8 88777444666*664#"), Is.EqualTo("TURING"));
        }

        [Test]
        public void OldPhonePad_EmptyInput_ReturnsEmpty()
        {
            Assert.That(PhoneKeypad.OldPhonePad(""), Is.EqualTo(""));
            Assert.That(PhoneKeypad.OldPhonePad("#"), Is.EqualTo(""));
        }
        
        [Test]
        public void OldPhonePad_NullInput_ReturnsEmpty()
        {
            // Robustness check
            Assert.That(PhoneKeypad.OldPhonePad(null), Is.EqualTo(""));
        }
    }
}