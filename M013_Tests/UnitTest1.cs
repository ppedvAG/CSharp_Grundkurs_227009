using M013;

namespace M013_Tests
{
	[TestClass]
	public class RechnerTests
	{
		//Rechtsklick auf Dependencies -> Add Project Reference -> Zu testende Projekt einbinden

		Rechner r;

		[TestInitialize]
		public void Init()
		{
			r = new();
		}

		[TestCleanup]
		public void Cleanup()
		{
			r = null;
		}

		[TestMethod]
		[TestCategory("AddiereTest")]
		public void TesteAddiere()
		{
			double x = r.Addiere(3, 4);
			Assert.AreEqual(7, x);
		}

		[TestMethod]
		[TestCategory("SubtrahiereTest")]
		public void TesteSubtrahiere()
		{
			double x = r.Subtrahiere(9, 4);
			Assert.AreEqual(5, x);
		}
	}
}