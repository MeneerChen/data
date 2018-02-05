using System;
using System.Threading.Tasks;

namespace data.Models
{
    public class AutoGenerateTask : IStartupTask
    {
        private readonly IHandleDataGeneration _handleDataGeneration;
        private readonly IProvideRandomData _randomData;

        public AutoGenerateTask(IHandleDataGeneration handleDataGeneration, IProvideRandomData randomData)
        {
            _handleDataGeneration = handleDataGeneration;
            _randomData = randomData;
        }

        public static Guid Revision { get; private set; } = Guid.NewGuid();

        public static Control Control { get; set; } = new Control
        {
            Enable = true,
            RandomWaitTime = new RandomWaitTime(2, 2)
        };

        public async Task Run()
        {
#pragma warning disable 4014
            Task.Run(async () =>
#pragma warning restore 4014
            {
                while (true)
                {
                    if (Control.Enable)
                    {
                        var data = await _randomData.ProvideAsync();
                        await _handleDataGeneration.GenerateAsync(data);
                        Revision = Guid.NewGuid();
                        await Task.Delay(Control.RandomWaitTime.Random * 1000);
                    }

                    await Task.Delay(500);
                }
            });
        }
    }
}