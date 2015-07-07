using System;
using System.Configuration;
using System.IO;
using Mu.Core.Common;
using Mu.Core.Watch;

namespace Mu.Core
{
    public class MuEnvironment : IContext
    {
        #region Constants

        private const string DataFileConfig = "dataFile";
        private const string DataFileDefaultFileName = "muData.xml";
        
        #endregion

        #region Singleton
        
        private static readonly Lazy<MuEnvironment> LazyInstance;

        public static MuEnvironment Instance
        {
            get { return LazyInstance.Value; }
        }

        static MuEnvironment()
        {
            LazyInstance = new Lazy<MuEnvironment>(() => new MuEnvironment());
        } 
        
        #endregion

        #region Constructors

        private MuEnvironment()
        {
            _dataFile = ConfigurationManager.AppSettings[DataFileConfig];
            if (string.IsNullOrWhiteSpace(_dataFile))
            {
                _dataFile = Path.Combine(Environment.CurrentDirectory, DataFileDefaultFileName);
            }

            _alerts = new AlertCollection();
        } 
        
        #endregion

        #region Public

        public AlertCollection Alerts
        {
            get { return _alerts; }
        }

        public string DataFile
        {
            get { return _dataFile; }
        }

        public void Save()
        {
            Alerts.Save(this);
        }

        public void Load()
        {
            Alerts.Load(this);
        }
        
        #endregion

        #region Private

        private readonly AlertCollection _alerts;
        private readonly string _dataFile;

        private void Reset()
        {
            Alerts.Clear();
        }

        #endregion
    }
}
