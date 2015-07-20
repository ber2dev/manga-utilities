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

        private const string DATA_FILE_CONFIG = "dataFile";
        private const string DATA_FILE_DEFAULT_FILE_NAME = "muData.xml";
        
        #endregion

        #region Singleton
        
        private static readonly Lazy<MuEnvironment> LAZY_INSTANCE;

        public static MuEnvironment Instance
        {
            get { return LAZY_INSTANCE.Value; }
        }

        static MuEnvironment()
        {
            LAZY_INSTANCE = new Lazy<MuEnvironment>(() => new MuEnvironment());
        } 
        
        #endregion

        #region Constructors

        private MuEnvironment()
        {
            _dataFile = ConfigurationManager.AppSettings[DATA_FILE_CONFIG];
            if (string.IsNullOrWhiteSpace(_dataFile))
            {
                _dataFile = Path.Combine(Environment.CurrentDirectory, DATA_FILE_DEFAULT_FILE_NAME);
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
