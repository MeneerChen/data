using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace data.Models
{
    public class SensorDataRepository : IProvideSensorData, IGenerateSensorData, IProvideLastSensorDataValue
    {
        private readonly IProvideSqliteConnections _sqliteConnections;

        public SensorDataRepository(IProvideSqliteConnections sqliteConnections)
        {
            _sqliteConnections = sqliteConnections;
        }

        async Task IGenerateSensorData.GenerateAsync(SensorData sensorData)
        {
            var sql = "INSERT INTO EVENTS (LIJNNUMMER, EVENT, BEGINTIJD, EINDTIJD) " +
                      $"VALUES (0,'{sensorData.SensorDataValue.Value}'," +
                      $"'{sensorData.SensorDataCreated:yyyy-MM-dd HH:mm:ss.fff}'," +
                      $"'{sensorData.SensorDataCreated:yyyy-MM-dd HH:mm:ss.fff}');";
            using (var connection = await _sqliteConnections.GetAsync())
            {
                await connection.ExecuteAsync(sql, commandType: CommandType.Text);
            }
        }

        async Task<SensorDataValue> IProvideLastSensorDataValue.ProvideAsync()
        {
            const string sql = "SELECT EVENT FROM EVENTS ORDER BY ID DESC LIMIT 1";
            using (var connection = await _sqliteConnections.GetAsync())
            {
                var result = await connection.QueryAsync(sql, commandType: CommandType.Text);
                return result.Select(x => new SensorDataValue(x.EVENT)).FirstOrDefault();
            }
        }

        async Task<IEnumerable<SensorDataEntity>> IProvideSensorData.ProvideAsync()
        {
            const string sql = "SELECT ID, EVENT, BEGINTIJD FROM EVENTS ORDER BY ID DESC LIMIT 10";
            using (var connection = await _sqliteConnections.GetAsync())
            {
                var result = await connection.QueryAsync(sql, commandType: CommandType.Text);
                return result.Select(x => new SensorDataEntity
                {
                    SensorDataId = new SensorDataId((int) x.ID),
                    SensorData = new SensorData
                    {
                        SensorDataValue = new SensorDataValue(x.EVENT),
                        SensorDataCreated = DateTime.Parse(x.BEGINTIJD)
                    }
                });
            }
        }
    }
}