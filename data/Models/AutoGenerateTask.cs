using System;
using System.Threading.Tasks;

namespace data.Models
{
    public class AutoGenerateTask : IStartupTask
    {
        private static bool _switchValue;
        private static int _fromSeconds = 60;
        private static int _toSeconds = 60;
        private static Guid _rivision = Guid.NewGuid();
        private readonly IHandleDataGeneration _handleDataGeneration;
        private readonly IProvideRandomData _randomData;

        public AutoGenerateTask(IHandleDataGeneration handleDataGeneration, IProvideRandomData randomData)
        {
            _handleDataGeneration = handleDataGeneration;
            _randomData = randomData;
        }

        public async Task Run()
        {
#pragma warning disable 4014
            Task.Run(async () =>
#pragma warning restore 4014
            {
                while (true)
                {
                    if (_switchValue)
                    {
                        var data = await _randomData.ProvideAsync();
                        await _handleDataGeneration.GenerateAsync(data);
                        _rivision = Guid.NewGuid();
                        var random = new Random().Next(_fromSeconds, _toSeconds);
                        await Task.Delay(random * 1000);
                    }

                    await Task.Delay(500);
                }
            });
        }

        public bool GetSwitchValue()
        {
            return _switchValue;
        }

        public void SetRandom(int from, int to)
        {
            _fromSeconds = from;
            _toSeconds = to;
        }

        public Guid GetRivision()
        {
            return _rivision;
        }

        public void Switch(bool value)
        {
            _switchValue = value;
        }
    }
}