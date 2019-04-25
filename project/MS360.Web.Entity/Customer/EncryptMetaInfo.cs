using MS360.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS360.Web.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EncryptMetaInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EncryptMode EncryptMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EncryptMetaInfo()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordSalt"></param>
        public EncryptMetaInfo(string passwordSalt)
        {
            PasswordSalt = passwordSalt;
            EncryptMode = EncryptMode.SHA1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordSalt"></param>
        /// <param name="encryptMode"></param>
        public EncryptMetaInfo(string passwordSalt, EncryptMode encryptMode)
        {
            PasswordSalt = passwordSalt;
            EncryptMode = encryptMode;
        }
    }
}
