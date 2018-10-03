using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simcorp.IMS.Phone.Speaker;

namespace IPlayTest {

    [TestClass]
    public class IPlayTest {
        FakeOutput output;
        IPlay device;
        string expectedMessage;

        [TestMethod]
        public void MonauralSpeakerTest() {
            output = new FakeOutput();
            device = new MonauralSpeakerSystem(new RealSpeaker(2), 20, output);
            expectedMessage = $"{nameof(MonauralSpeakerSystem)} sound";

            //-- Act
            device.Play(new Track());

            //-- Assert
            Assert.AreEqual(output.Result, expectedMessage);
        }

        [TestMethod]
        public void StereoSpeakerTest() {
            output = new FakeOutput();
            device = new StereoSpeakerSystem(new RealSpeaker(2), new RealSpeaker(2), 20, output);
            expectedMessage = $"{nameof(StereoSpeakerSystem)} sound";

            //-- Act
            device.Play(new Track());

            //-- Assert
            Assert.AreEqual(output.Result, expectedMessage);
        }

        [TestMethod]
        public void UnofficialHeadsetTest() {
            output = new FakeOutput();
            device = new UnofficialHeadset(new RealSpeaker(2), new RealSpeaker(2), 20, output);
            expectedMessage = $"{nameof(UnofficialHeadset)} sound";

            //-- Act
            device.Play(new Track());

            //-- Assert
            Assert.AreEqual(output.Result, expectedMessage);
        }

        [TestMethod]
        public void SamsungHeadsetTest() {
            output = new FakeOutput();
            device = new SamsungHeadset(new RealSpeaker(2), new RealSpeaker(2), 20, output);
            expectedMessage = $"{nameof(SamsungHeadset)} sound";

            //-- Act
            device.Play(new Track());

            //-- Assert
            Assert.AreEqual(output.Result, expectedMessage);
        }

        [TestMethod]
        public void ExternalSpeakerTest() {
            output = new FakeOutput();
            device = new ExternalSpeaker(new RealSpeaker(2), 20, output);
            expectedMessage = $"{nameof(ExternalSpeaker)} sound";

            //-- Act
            device.Play(new Track());

            //-- Assert
            Assert.AreEqual(output.Result, expectedMessage);
        }

    }
}
