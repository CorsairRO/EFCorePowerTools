﻿namespace EFCorePowerTools.Shared.Models
{
    using JetBrains.Annotations;
    using Microsoft.VisualStudio.Data.Services;
    using RevEng.Shared;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A model holding data about a database connection.
    /// </summary>
    public class DatabaseConnectionModel : INotifyPropertyChanged
    {
        private string _connectionName;
        private string _connectionString;
        private DatabaseType _databaseType;
        private IVsDataConnection _dataConnection;

        public string ConnectionName
        {
            get => _connectionName;
            set
            {
                if (value == _connectionName) return;
                _connectionName = value;
                OnPropertyChanged();
            }
        }

        public string DisplayName
        {
            get
            {
                if (DataConnection == null)
                {
                    return $"{ConnectionName} ({DatabaseType})";
                }

                return ConnectionName;
            }
        }

        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                if (value == _connectionString) return;
                _connectionString = value;
                OnPropertyChanged();
            }
        }

        public DatabaseType DatabaseType
        {
            get => _databaseType;
            set
            {
                if (value == _databaseType) return;
                _databaseType = value;
                OnPropertyChanged();
            }
        }

        public IVsDataConnection DataConnection
        {
            get => _dataConnection;
            set
            {
                if (value == _dataConnection) return;
                _dataConnection = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
