using System;
using System.Collections.Generic;
using System.Text;

namespace WOWItemMaker
{
    public class ConnInfo
    {
        private static string _HostName;

        public static string HostName
        {
            get 
            {
                string host = ConnInfo._HostName;
                int pos = _HostName.LastIndexOf(':');
                if (pos > -1)
                {
                    host = host.Substring(0, pos);
                }
                return host; 
            }
            set { ConnInfo._HostName = value; }
        }

        public static uint Port
        {
            get 
            {
                uint port = 3306;
                int pos = _HostName.LastIndexOf(':');
                if (pos > -1)
                {
                    try
                    {
                        port = uint.Parse(_HostName.Substring(pos + 1));
                    }
                    catch { }
                }
                return port; 
            }
        }
        private static string _UserName;

        public static string UserName
        {
            get { return ConnInfo._UserName; }
            set { ConnInfo._UserName = value; }
        }
        private static string _PassWord;

        public static string PassWord
        {
            get { return ConnInfo._PassWord; }
            set { ConnInfo._PassWord = value; }
        }
        private static string _DataBase;

        public static string DataBase
        {
            get { return ConnInfo._DataBase; }
            set { ConnInfo._DataBase = value; }
        }
        private static bool _Stat;

        public static bool Stat
        {
            get { return ConnInfo._Stat; }
            set { ConnInfo._Stat = value; }
        }
        private static string _dbstruct;

        public static string Dbstruct
        {
            get { return _dbstruct; }
            set { _dbstruct = value; }
        }

        private static bool _saveConnInfo;

        public static bool SaveConnInfo
        {
            get { return _saveConnInfo; }
            set { _saveConnInfo = value; }
        }

        private static bool _savePwd;

        public static bool SavePwd
        {
            get { return _savePwd; }
            set { _savePwd = value; }
        }
    }
}
