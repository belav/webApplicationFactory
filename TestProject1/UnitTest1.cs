namespace TestProject1;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

public class AssessBehaviourOfAsyncLocal
{
    static readonly AsyncLocal<string> asyncLocalString = new();

    [Test]
    public void RunInParallel()
    {
        Console.WriteLine(asyncLocalString.Value);

        asyncLocalString.Value = "OutsideTask";

        var backgroundTask = new Task(() =>
        {
            Console.WriteLine("starting task");
            Assert.AreEqual(null, asyncLocalString.Value);
            Console.WriteLine(asyncLocalString.Value);
            asyncLocalString.Value = "Bobby";

            Console.WriteLine(asyncLocalString.Value);
        });
        backgroundTask.Start();
        backgroundTask.Wait();

        Console.WriteLine(asyncLocalString.Value);
    }
}
