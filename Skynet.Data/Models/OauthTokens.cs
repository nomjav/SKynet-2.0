using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class OauthTokens
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public int? Expire { get; set; }
        public string RefreshToken { get; set; }
    }
}
